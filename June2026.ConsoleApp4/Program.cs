using System.Data;
using Dapper;
using June2026.ConsoleApp4;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");
DapperService service = new DapperService();
service.Read();
//service.Create();
//service.Update();
service.Delete();

Console.ReadLine();