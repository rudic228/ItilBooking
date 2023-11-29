using CsvHelper.Configuration;

namespace DbSeeding.Parsers.Rooms
{
    public class RoomMap : ClassMap<RoomRecord>
    {
        public RoomMap() 
        {
            Map(x => x.Number).Name("Номер");
            Map(x => x.Price).Name("Цена");
            Map(x => x.Area).Name("Площадь");
            Map(x => x.Category).Name("Категория");
            Map(x => x.Level).Name("Этаж");
        }
    }
}
