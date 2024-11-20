using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Manger
{
     class ProductsData
    {
        public int InsertDataProduct(String connectionString)
        {
            int rowsAffected = 0;
            bool answer = false;
            while (answer==false)
            {
                string imgeUrl,product_Descreption,product_Name;
                int category_Id,price;
                Console.WriteLine("insert product_Name name");
                product_Name=Console.ReadLine();
                Console.WriteLine("insert product_Descreption name");
                product_Descreption=Console.ReadLine();
                Console.WriteLine("insert ImgeUrl");
                imgeUrl=Console.ReadLine();
                Console.WriteLine("insert category_Id ");
                category_Id=int.Parse(Console.ReadLine());
                Console.WriteLine("insert Price ");
                price=int.Parse(Console.ReadLine());

                string query = ("INSERT INTO Products(imgeUrl,price,product_Descreption,product_Name,category_Id)"+"VALUES(@ImgeUrl,@Price,@Product_Descreption,@Product_Name,@Category_Id)");
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@ImgeUrl", SqlDbType.NVarChar, 50).Value=imgeUrl;
                    cmd.Parameters.Add("@Price", SqlDbType.Money).Value=price;
                    cmd.Parameters.Add("@Product_Descreption", SqlDbType.NVarChar, 50).Value=product_Descreption;
                    cmd.Parameters.Add("@Product_Name", SqlDbType.NChar, 10).Value=product_Name;
                    cmd.Parameters.Add("@Category_Id", SqlDbType.Int).Value=category_Id;
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
        public void readAllData(String connectionString)
        {
            string queryString = "select * from Products join Categories on Category_Id =Categories.ID ";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, cn);
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",
                             reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]);
                    }
                    reader.Close();

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();


            }
        }
    }
}

