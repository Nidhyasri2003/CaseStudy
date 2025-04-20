using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util
{
    public static class DBPropertyUtil
    {
        public static string GetConnectionString()
        {
            // Replace with your actual server name and DB
            return "Server=JAYASRI ;Database=crimeanalysisDB;Integrated Security=True;TrustServerCertificate=True";
        }
    }
}
