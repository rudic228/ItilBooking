using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project1.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // ��������, ����� �� �������������� �������� ��� ��������� ������
            ValidateIssuer = true,
            // ������, �������������� ��������
            ValidIssuer = AuthOptions.ISSUER,

            // ����� �� �������������� ����������� ������
            ValidateAudience = true,
            // ��������� ����������� ������
            ValidAudience = AuthOptions.AUDIENCE,
            // ����� �� �������������� ����� �������������
            ValidateLifetime = true,

            // ��������� ����� ������������
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // ��������� ����� ������������
            ValidateIssuerSigningKey = true,
        };
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Dal.Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

string corsPolicy = "MyCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, policy =>
    {
        policy.WithOrigins("https://localhost:44442")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie("Cookies", options => {
//        //options.LoginPath = "/Account/Login";
//        options.LogoutPath = "/Logout";
//        options.AccessDeniedPath = "/AccessDenied";
//    });

builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
app.UseCors(corsPolicy);

app.Run();
