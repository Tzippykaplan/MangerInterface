using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Manger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "data source=srv2\\pupils;initial catalog=327581567_Shop;Integrated Security=SSPI;Persist Security " +
                "Info=False;TrustServerCertificate=true";
            CategoryData cd = new CategoryData();
            //cd.InsertDataCategory(connectionString);
            ProductsData pd = new ProductsData();
            //pd.InsertDataProduct(connectionString);
            pd.readAllData(connectionString);

        }
    }
}
