using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Old Stuff

            //var me = new PersonnelData();

            /*
            me.BirthDay = Helper.Convert("01/11/1975", DateTime.Now);
            me.Money = Helper.Convert("20", decimal.Zero);
            */

            /*
            me.BirthDay = Helper.Parse<DateTime>("01/11/1975");
            me.Money = Helper.Parse<Decimal>("20");
            me.Number = Helper.Parse<int>("");
            */

            /*
            using(var sqlConn = new SqlConnection(@"server=DEV-2K8SQL3.dev.lan\DEV3;database=Protksql_db;user id=protkapp;password=pr0tk@ppdev3;Connect Timeout=1800;"))
            {
                sqlConn.Open();

                using(var cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"select getDate() as Birthday, null as Money, 20 as Number;";

                    using(var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            me.BirthDay = Helper.ConvertDbObject<DateTime>(reader["Birthday"]);
                            me.Money = Helper.ConvertDbObject<Decimal>(reader["Money"]);
                            me.Number = Helper.ConvertDbObject<int>(reader["Number"]);
                        }
                    }
                }
            }

            Console.WriteLine(me.BirthDay);
            Console.WriteLine(me.Money);
            */

            /*
            long number = 4294967295;
            int smallernumber = (int) number;

            Console.WriteLine("{0} = {1}", number, smallernumber);
            */

            #endregion

            var items = new List<Data>
                            {
                                new Data {Name = "bob", Gender = "male", Zipcode = "21112"},
                                new Data {Name = "sarah", Gender = "female", Zipcode = "21046"},
                                new Data {Name = "steven", Gender = "male", Zipcode = "21112"},
                                new Data {Name = "joe", Gender = "male", Zipcode = "21046"},
                                new Data {Name = "karen", Gender = "female", Zipcode = "21075"}
                            };

            var group = items.GroupBy(i => i.Zipcode, i => i, (key, g) => new { Zipcode = key, Items = g.ToList() });
            
            Console.ReadKey();
        }
    }

    public class Data
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Zipcode { get; set; }
    }

    public class PersonnelData
    {
        public DateTime? BirthDay { get; set; }
        public decimal? Money { get; set; }
        public int? Number { get; set; }
    }

    public class Helper
    {
        public static bool TryParse<T>(string input, out T? output) where T : struct
        {
            var parameterTypes = new[] {typeof (string), typeof (T).MakeByRefType()};
            var parseMethod = typeof(T).GetMethod("TryParse", parameterTypes);

            var methodParameters = new object[] { input, null };
            var result = parseMethod.Invoke(null, methodParameters);

            output = (bool) result ? (T) methodParameters[1] : new T?();

            return (bool) result;
        }

        public static T? Parse<T>(string input) where T : struct
        {
            T? output;
            TryParse(input, out output);

            return output;
        }

        public static T? ConvertDbObject<T>(object dbValue) where T : struct
        {
            if (dbValue == null || dbValue == DBNull.Value)
                return new T?();

            return (T)dbValue;
        }
    }
}
