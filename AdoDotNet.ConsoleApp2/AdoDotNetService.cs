using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace adonet.ConsoleApp2
{
    internal class AdoDotNetService
    {
        private readonly SqlConnectionStringBuilder sb;
        public AdoDotNetService()
        {
            sb = new SqlConnectionStringBuilder
            {
                DataSource = "LAPTOP-OI6UJSEI", //server name
                InitialCatalog = "JuneC#", //database name
                /*sb.UserID = "sa"; 
                sb.Password = "sasa@12";*/
                IntegratedSecurity = true,
                TrustServerCertificate = true
            };
        }
        public void Read() 
        {
            Console.WriteLine($"connection string:{sb.ConnectionString}");
            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            Console.WriteLine("Opening...");

            connection.Open();
            Console.WriteLine("Opened");

            string query = @"SELECT [StuId]
      ,[StuName]
      ,[FatherName]
      ,[StuNo]
      ,[Email]
      ,[DateofBirth]
      ,[PhNo]
      ,[IsDelete]
  FROM [dbo].[Tbl_Stu];";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Console.WriteLine($"Total rows retrive:{dt.Rows.Count}");
            /*DataSet ds = new DataSet();
            adapter.Fill(ds);*/

            Console.WriteLine("connection Close");
            connection.Close();
            Console.WriteLine("closed");

            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine(item["StuId"]);
                Console.WriteLine(item["StuName"]);
                Console.WriteLine(item["FatherName"]);
                DateTime dtDob = Convert.ToDateTime(item["DateofBirth"]);
                Console.WriteLine(dtDob.ToString("yyyy-MM-dd"));
            }
        }

        public void Create()
        {
            /*SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = "LAPTOP-OI6UJSEI"; //server name
            sb.InitialCatalog = "JuneC#"; //database name
            sb.IntegratedSecurity = true;
            sb.TrustServerCertificate = true;*/

            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[Tbl_Stu] 
    ([StuName], [FatherName], [StuNo], [Email], [DateofBirth], [PhNo], [IsDelete])
VALUES
    ('Aung Myo Thu', 'U Ba Myint', 'STU-2026-001', 'aungmyothu@gmail.com', '2004-05-12', '09450123456', 0),
    ('Su Myat Noe', 'U Tin Win', 'STU-2026-002', 'sumyatnoe@gmail.com', '2005-08-22', '09254987654', 0),
    ('Min Khant Kyaw', 'U Kyaw Swar', 'STU-2026-003', 'minkhantkyaw@gmail.com', '2004-11-03', '09798123456', 0),
    ('Hnin Thazin Oo', 'U Myo Min', 'STU-2026-004', 'hninthazin@gmail.com', '2005-01-15', '09965432109', 0),
    ('Zin Min Htet', 'U Htein Lin', 'STU-2026-005', 'zinminhtet@gmail.com', '2004-03-30', '09420987654', 0);";
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Update()
        {
            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();

            string query = @"UPDATE [dbo].[Tbl_Stu]
SET [PhNo] = '09455667788',
    [Email] = 'aungmyothu.new@gmail.com'
WHERE [StuId] = 1;";
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete()
        {
            
            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();

            string query = @"DELETE FROM [dbo].[Tbl_Stu]
WHERE [StuId] BETWEEN 1007 AND 1011;";
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
