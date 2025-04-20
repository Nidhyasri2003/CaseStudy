using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

namespace util
{
    public static class DBConnUtil
    {
        private static readonly string connectionString = DBPropertyUtil.GetConnectionString();

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}