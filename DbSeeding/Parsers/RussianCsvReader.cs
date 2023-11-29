using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace DbSeeding.Parsers
{
    public static class RussianCsvReader
    {
        public static T[] ReadWithHeaders<T, TMap>(byte[] content)
            where TMap : ClassMap<T>
        {
            System.Text.Encoding encoding = CodePagesEncodingProvider.Instance.GetEncoding(1251);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = encoding,
                HasHeaderRecord = true,
                Delimiter = ";",
                TrimOptions = TrimOptions.Trim | TrimOptions.InsideQuotes
            };

            string text = encoding.GetString(content);

            using TextReader reader = new StringReader(text);
            using var csvReader = new CsvReader(reader, csvConfig);

            csvReader.Context.RegisterClassMap<TMap>();

            return csvReader.GetRecords<T>().ToArray();
        }
    }
}
