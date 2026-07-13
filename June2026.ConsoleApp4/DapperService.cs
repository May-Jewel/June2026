using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace June2026.ConsoleApp4
{
    internal class DapperService
    {
         private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = "LAPTOP-OI6UJSEI", //server name
            InitialCatalog = "JuneC#", //database name
            /*sb.UserID = "sa"; 
            sb.Password = "sasa@12";*/
            IntegratedSecurity = true,
            TrustServerCertificate = true
        };
        public void Read() 
        {
            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();
                //db.Query("SELECT * FROM [dbo].[Tbl_Stu];").ToList();
                List<Student> lst = db.Query<Student>("SELECT * FROM [dbo].[Tbl_Stu];").ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine($"Id: {item.StuId}, Name: {item.StuName}");
                }
                int result = db.Execute(("Delete From Tbl_Stu where StuId = 11"));
                Console.WriteLine($"Rows affected: {result}");
            }
        }
        public void Create()
        {
            
        }
        public void Update() { }
        public void Delete() 
        {
            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute(("Delete From Tbl_Stu where StuId = 1006"));
                Console.WriteLine($"Rows affected: {result}");
            }
        }
    }
}
