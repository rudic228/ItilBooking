using Dal.Entities;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace DbSeeding.Parsers.Rooms
{
    public class RoomParser
    {
        public IEnumerable<Room> GetRooms()
        {
            var content = ResourceHelper.GetEmbeddedResourceAsBytes(@"Data\Csv\Rooms.csv");
            var entries = RussianCsvReader.ReadWithHeaders<RoomRecord, RoomMap>(content);
            foreach (var entry in entries) 
            {
                yield return new Room()
                {
                    Id = GetId(entry),
                    Area = entry.Area,
                    Category = entry.Category,
                    Level = entry.Level,
                    Number = entry.Number,
                    Price = entry.Price,
                };
            }

        }

        private Guid GetId(RoomRecord record)
        {
            var keys = new
            {
                record.Number
            };

            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(keys));

            using var md5 = MD5.Create();

            return new Guid(md5.ComputeHash(bytes));
        }
    }
}
