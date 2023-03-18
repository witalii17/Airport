using System.Data;
using System.Data.SqlClient;
namespace Airport
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            try
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(@"Please,  type the number:
                    1.  airline flight information
                    2.  flights pricelist
                    3.  passengers list
                    4.  exit
          
                    ");
                    try
                    {
                        a = (int)uint.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                Airline_imfo();
                                Console.WriteLine("");
                                break;
                            case 2:
                                Flights_pr();
                                Console.WriteLine("");
                                break;
                            case 3:
                                //Passengers();
                                Console.WriteLine("");
                                break;
                            case 4:
                                Environment.Exit(0);
                                Console.WriteLine("");
                                break;
                            default:
                                Console.WriteLine("Invalid option");
                                break;
                        }
                        Console.ReadLine();
                        Console.Clear();

                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("Error " + e.Message);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Press Spacebar to exit; press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #region airline flight information
            static void Airline_imfo()
            {
                int b;
                try
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"Please,  type the number:
                    1.  Add airline flight information
                    2.  airline flight information
                    3.  search airline flight information
                    4.  exit
          
                    ");
                        try
                        {
                            b = (int)uint.Parse(Console.ReadLine());
                            switch (b)
                            {
                                case 1:
                                    Add_Airline_imfo();
                                    Console.WriteLine("");
                                    break;
                                case 2:
                                    Airline_imfo();
                                    Console.WriteLine("");
                                    break;
                                case 3:
                                    Search_code();
                                    Console.WriteLine("");
                                    break;
                                case 4:
                                    exit();
                                    Console.WriteLine("");
                                    break;
                                default:
                                    Console.WriteLine("Invalid option");
                                    break;
                            }
                            Console.ReadLine();
                            Console.Clear();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error " + e.Message);
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" Press Spacebar to exit; press any key to continue");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                static void Airline_imfo()
                {



                    string connection = "Server=DESKTOP-VITALII ;Initial Catalog=DataBase;Integrated Security=True ";
                    string query = "select * FROM FlightInformation";
                    using (SqlConnection dbconn = new SqlConnection(connection))
                    {
                        dbconn.Open();
                        SqlCommand command = new SqlCommand(query, dbconn);
                        SqlDataReader reader = command.ExecuteReader();
                        try
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0,3} {1,20}{2,10}{3,10}{4,5}{5,5}{6,10}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }

                        /*SqlDataAdapter adapter = new SqlDataAdapter(query, dbconn);
                        DataSet personalInfoDataSet = new DataSet();
                        adapter.Fill(personalInfoDataSet);*/
                    }
                }
            }

            static void Add_Airline_imfo()
            {
                Console.WriteLine("Введите date:");
                string date = Console.ReadLine();

                Console.WriteLine("Введите flight_number:");
                int flight_number = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Введите cityArrive:");
                string cityArrive = Console.ReadLine();

                Console.WriteLine("Введите terminal:");
                int terminal = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Введите flight_status:");
                int flight_status = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Введите cityDeparture:");
                string cityDeparture = Console.ReadLine();

                string connection2 = "Server=DESKTOP-VITALII ;Initial Catalog=DataBase;Integrated Security=True ";
                using (SqlConnection connection3 = new SqlConnection(connection2))
                {
                    connection3.Open();
                    string add_sql = "INSERT INTO FlightInformation VALUES(@date,@flight_number,@cityArrive,@terminal,@flight_status,@cityDeparture)";

                    using (SqlCommand command = new SqlCommand(add_sql, connection3))

                    {

                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@flight_number", flight_number);
                        command.Parameters.AddWithValue("@cityArrive", cityArrive);
                        command.Parameters.AddWithValue("@terminal", terminal);
                        command.Parameters.AddWithValue("@flight_status", flight_status);
                        command.Parameters.AddWithValue("@cityDeparture", cityDeparture);
                        int number = command.ExecuteNonQuery();
                        Console.WriteLine("Добавлено объектов: {0}", number);
                    }

                }
                Console.ReadKey();

            }
            static void exit()
            {
                Environment.Exit(0);
            }
            #endregion





            #region Flights_pr
            static void Flights_pr()
            {
                string connection = "Server=DESKTOP-VITALII ;Initial Catalog=DataBase;Integrated Security=True ";
                string query = "select * FROM FlightsPricelist";
                using (SqlConnection dbconn = new SqlConnection(connection))
                {
                    dbconn.Open();
                    SqlCommand command = new SqlCommand(query, dbconn);
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0,3} {1,20}{2,10}{3,10}", reader[0], reader[1], reader[2], reader[3]);
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }

                    /*SqlDataAdapter adapter = new SqlDataAdapter(query, dbconn);
                    DataSet personalInfoDataSet = new DataSet();
                    adapter.Fill(personalInfoDataSet);*/
                }
            }
            #endregion

            #region search
            static void Search_code()
            {
                Console.WriteLine("Введите city Arrive:");
                string cityArrive = Console.ReadLine();
                string connection = "Server=DESKTOP-VITALII ;Initial Catalog=DataBase;Integrated Security=True ";
                string query = $"select * FROM FlightInformation WHERE cityArrive like N'%{cityArrive}%'";
                using (SqlConnection dbconn = new SqlConnection(connection))
                {
                    dbconn.Open();
                    SqlCommand command = new SqlCommand(query, dbconn);
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0,3} {1,20}{2,10}{3,10}", reader[0], reader[1], reader[2], reader[3]);
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }

                }
                #endregion
            }

        }
    }
}