using System;
using System.Collections.Generic;
using System.Data;

namespace ListToDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<KeyValuePair<int, string>>();
            
            list.Add(new KeyValuePair<int, string>(1, "100"));
            list.Add(new KeyValuePair<int, string>(1, "200"));
            list.Add(new KeyValuePair<int, string>(2, "56789"));
            list.Add(new KeyValuePair<int, string>(3, "30"));
            list.Add(new KeyValuePair<int, string>(3, "10"));
            list.Add(new KeyValuePair<int, string>(4, "210"));

            DataTable table = new DataTable("ValueTable");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Value", typeof(string));
            table.Columns.Add("Value2", typeof(string));

            foreach (var element in list)
            {
                Console.WriteLine(element.Key + " " + element.Value);
                DataRow[] Id = table.Select("Id = '" + element.Key + "'");

                if(Id.Length == 0)
                {
                    table.Rows.Add(element.Key, element.Value, null);
                }
                else
                {
                    foreach(DataRow row in Id)
                    {
                        row["value2"] = element.Value;
                        table.AcceptChanges();
                        row.SetModified();
                    }
                }              
            }

            Console.ReadLine();
        }
    }
}
