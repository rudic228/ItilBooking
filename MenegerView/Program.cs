using Npgsql;

namespace MenegerView
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormWork());

            //String connectionString = "Host=localhost;Port=5432;Database=ItilBooking;Username=postgres;Password=1111;Include Error Detail=true;";
            //NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionString);
            //npgsqlConnection.Open();
        }
    }
}