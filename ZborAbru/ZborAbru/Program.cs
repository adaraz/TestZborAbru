using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLE = AbraOLELib;

namespace ZborAbru
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new OLE.Application();
            var ids = string.Join(",", Enumerable.Range(1, 435).Select(x => x.ToString().PadLeft(10, '0')));
            var sql = app.CreateSQLStatement();
            sql.SQL = $"select value from string_split(:ids, ',')";
            sql.BindParam("ids", ids);
            sql.Execute();
            Console.Write(sql.RowsAffected);
            Console.ReadKey();
        }
    }
}
