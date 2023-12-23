using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ItilBooking.Models.Account.Login;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Dal;
using Microsoft.EntityFrameworkCore;
using System.Text;
using ItilBooking.Models.Account.Register;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ItilBooking.Infrastructure.Validators;
using Microsoft.IdentityModel.Tokens;
using Project1.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace ItilBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly Context context;
        public AccountController(Context context)
        {
            this.context = context;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(
            RegisterForm model)
        {
            if(string.IsNullOrEmpty(model.Login) || model.Login.Length < 5 || model.Login.Length > 50 || model.Login.Any(x => !char.IsLetterOrDigit(x)))
            {
                return BadRequest("Логин должен быть длиной от 5 до 50 символов и состоять из букв или цифр");
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                return BadRequest("Имя пользователя не может быть пустым");
            }

            if (string.IsNullOrEmpty(model.Surname))
            {
                return BadRequest("Фамилия пользователя не может быть пустым");
            }

            if (!PasswordValidator.TryParse(model.Password, out var password))
            {
                return BadRequest("Неправильный формат пароля");
            }

            if (!EmailValidator.TryParse(model.Email, out var email))
            {
                return BadRequest("Неправильный формат почты");
            }

            if (!PhoneValidator.TryParse(model.Phone, out var phone))
            {
                return BadRequest("Неправильный формат телефона");
            }

            var userByLogin = await context.Users
                .AsNoTracking()
                .Select(x => x.Login)
                .FirstOrDefaultAsync(x => x == model.Login);

            if (userByLogin is not null)
            {
                return BadRequest("Пользователь с таким логином уже существует");
            }

            var userByEmail = await context.Users
                .AsNoTracking()
                .Select(x => x.Email)
                .FirstOrDefaultAsync(x => x == model.Email);

            if (userByEmail is not null)
            {
                return BadRequest("Пользователь с такой почтой уже существует");
            }

            var userByPhone = await context.Users
                .AsNoTracking()
                .Select(x => x.Phone)
                .FirstOrDefaultAsync(x => x == phone);

            if (userByPhone is not null)
            {
                return BadRequest("Пользователь с таким телефоном уже существует");
            }

            string fullname = model.Name + " " + model.Surname;
            if (!string.IsNullOrEmpty(model.Patronymic))
            {
                fullname += " " + model.Patronymic;
            }

            context.Users
                .Add(new Dal.Entities.User()
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    Login = model.Login,
                    Name = model.Name,
                    Surname = model.Surname,
                    Patronymic = model.Patronymic,
                    FullName = fullname,
                    PasswordHash = MD5Hash(password),
                    Phone = phone
                });

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("token")]
        public async Task<IActionResult> Token(
            [FromBody, BindRequired] LoginForm model)
        {
            var authenticateResult = await AuthenticateUser(model.Login, model.Password);
            if (!authenticateResult.IsSuccses)
            {
                return StatusCode(403, authenticateResult.ErrorDescription);
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: authenticateResult.Identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = authenticateResult.Identity.Name
            };

            return Ok(response);
        }

        private async Task<Models.Account.AuthenticateResult> AuthenticateUser(string login, string password)
        {
            var result = new Models.Account.AuthenticateResult();
            result.IsSuccses = false;
            var user = await context.Users
                .Select(x => new
                {
                    x.Login,
                    x.PasswordHash,
                    x.Id
                })
                .FirstOrDefaultAsync(x => x.Login == login);

            if (user == null)
            {
                result.ErrorDescription = "Не найден аккаунт с таким логином";
                return result;
            }

            if (user!.PasswordHash != MD5Hash(password))
            {
                result.ErrorDescription = "Пароль не совпадает";
                return result;
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString())
                };
            result.Identity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            result.IsSuccses = true;
            return result;
        }

        private string MD5Hash(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                var temp = Convert.ToHexString(hashBytes).ToLower();

                return temp;
            }
        }
    }
}
