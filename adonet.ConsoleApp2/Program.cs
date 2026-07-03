using System.Data;
using adonet.ConsoleApp2;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoDotNetService service = new AdoDotNetService();
//service.Read();
//service.Create();
//service.Update();
service.Delete();

Console.ReadLine();