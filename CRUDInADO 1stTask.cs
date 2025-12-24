


using System;
using Microsoft.Data.SqlClient;
namespace CRUDInADO
{
    class Program
    {
        static void Main(string[] args)
        {
            insertData();
            
            UpdateStudent();
            Delete();
            GetAllStudents();

            Console.ReadKey();
        }


        static void insertOne(SqlConnection con , string name,int age,string email)
        {
            using(SqlCommand cmd = new SqlCommand("INSERT INTO  Student(name,email,Age) VALUES (@name,@email,@Age)",con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@Age", age);

                cmd.ExecuteNonQuery();
            }

        }
        static void insertData()
        {
                          string cs = "data Source = .; Database = Students; Integrated Security = True; TrustServerCertificate = True";
            using (SqlConnection con = new SqlConnection(cs))
            {

            

                con.Open();


                insertOne(con, "suhail", 20, "suhail@gmail.com");
                insertOne(con, "miqqan", 21, "miqqan@gmail.com");
                insertOne(con, "bebar", 19, "bebar@gmail.com");
                insertOne(con, "shaabi", 21, "shaabi@gmail.com");
                insertOne(con, "baiiz", 22, "baiz@gmail.com");
                insertOne(con, "diya", 25, "diya@gmail.com");
                insertOne(con, "bilaal", 24, "bilaal@gmail.com");


            



            
                
                Console.WriteLine("student inserted succesfuly");
            }

        }


        static void GetAllStudents()
        {
            string cs = "data Source = .; Database = Students; Integrated Security = True; TrustServerCertificate = True";
            using (SqlConnection con = new SqlConnection(cs)) 
                using(SqlCommand cmd = new SqlCommand("SELECT id,name , Age ,email FROM Student ", con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["id"]},{dr["name"]} | {dr["email"]} | {dr["Age"]}");

                }
            }



        }

        static void UpdateStudent()
        {
            string cs = "data Source = .; Database = Students; Integrated Security = True; TrustServerCertificate = True";
            using(SqlConnection con = new SqlConnection(cs))
                using(SqlCommand cmd = new SqlCommand(@"UPDATE Student SET name=@name, Age=@Age ,email=@email WHERE id = @id",con))
            {
                cmd.Parameters.AddWithValue("@id", 3);
                cmd.Parameters.AddWithValue("@name", "mishal bebar");
                cmd.Parameters.AddWithValue("@Age", 30);
                cmd.Parameters.AddWithValue("@email", "mishal@gmail.com");
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("student updated succesfuly");

            }

        }

        static void Delete()
        {
            string cs = "data Source = .; Database = Students; Integrated Security = True; TrustServerCertificate = True";
            using (SqlConnection con = new SqlConnection(cs))
                using(SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE id = @id",con))
            {
                cmd.Parameters.AddWithValue("@id", 1);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("student deleted succesfuly");

            }
        }

    }
}