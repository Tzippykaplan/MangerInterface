using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manger
{
     class CategoryData
    {
        public int InsertDataCategory(String connectionString)
        {
            int rowsAffected=0;
            bool answer = false;
            while (answer==false)
            {
                string category;
                Console.WriteLine("insert category name");
                category=Console.ReadLine();

                string query = ("INSERT INTO Categories(category)"+"VALUES(@Category)");
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@Category", SqlDbType.NChar, 10).Value=category;
                    cn.Open();
                    rowsAffected += cmd.ExecuteNonQuery();
                    cn.Close();
                    Console.WriteLine("do you want to continue ? (y/n)");
                    string currentAnswer = Console.ReadLine();
                    answer=currentAnswer=="n" ? true : false;

                }
            }
            return rowsAffected;
        
            
        }
    }
}
