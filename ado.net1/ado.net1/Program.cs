using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace ado.net1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Insert();
            //Delete(3);
            //Update(1);
            //GetData(2);
            //GetAllDatas();
            //List<Student> students = GetAllDatas();
            //foreach (var student in students)
            //{
            //    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Grant: {student.Grant}");
            //}
        }
        static void Insert()
        {
            string connection = "Server=DESKTOP-N5N9E4H\\SQLEXPRESS;Database=AdoNetTask;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection sqlConnection = new SqlConnection(connection);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into Students values ('new std1', 'new stdsurname1', 55, 630, 2)", sqlConnection);
            int check = cmd.ExecuteNonQuery();
            if (check > 0)
            {
                Console.WriteLine("inserted");
            }
            else
            {
                Console.WriteLine("error");
            }
            sqlConnection.Close();
        }
        static void Delete(int id)
        {
            string connection = "Server=DESKTOP-N5N9E4H\\SQLEXPRESS;Database=AdoNetTask;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection sqlConnection = new SqlConnection(connection);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand($"delete from Students where Id = {id}", sqlConnection);
            int check = cmd.ExecuteNonQuery();
            if (check > 0)
            {
                Console.WriteLine("deleted");
            }
            else
            {
                Console.WriteLine("error");
            }
            sqlConnection.Close();
        }
        static void Update(int id)
        {
            string connection = "Server=DESKTOP-N5N9E4H\\SQLEXPRESS;Database=AdoNetTask;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection sqlConnection = new SqlConnection(connection);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand($"update Students set Name = 'updatedstd1' where Id = {id}", sqlConnection);
            int check = cmd.ExecuteNonQuery();
            if (check > 0)
            {
                Console.WriteLine("updated");
            }
            else
            {
                Console.WriteLine("error");
            }
            sqlConnection.Close();
        }

        //GETDATA islemir

        //static void GetData(int id)
        //{
        //    string connection = "Server=DESKTOP-N5N9E4H\\SQLEXPRESS;Database=AdoNetTask;Trusted_Connection=True;TrustServerCertificate=True";
        //    SqlConnection sqlConnection = new SqlConnection(connection);

        //    sqlConnection.Open();
        //    using (SqlCommand cmd = new SqlCommand("select * from table where Id = 1", sqlConnection))
        //    {
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.HasRows)
        //        {
        //            Console.WriteLine((string)reader[0]);
        //        }
        //        //cmd.ExecuteReader(); 
        //    }        
        //    sqlConnection.Close();
        //}

        public static List<Student> GetAllDatas()
        {
            
            List<Student> students = new List<Student>();
            DataTable datatable = SQLHelper.ReadAll("select * from Students");
            foreach (DataRow item in datatable.Rows)
            {
                students.Add(new Student()
                {
                    Id = (int)item["Id"],
                    Name = (string)item["Name"],
                    Surname = (string)item["Surname"],
                    Age = (int)item["Age"],
                    Grant = (decimal)item["Grant"]
                });
            }
            return students;
        }
    }
}
