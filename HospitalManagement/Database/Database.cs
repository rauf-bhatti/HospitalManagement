using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using HospitalManagement.Models;
using Npgsql;


namespace HospitalManagement.Database
{
    class Database
    {
        private NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);

        public dynamic RunQuery(string query, int flag) //Flag is set if the query is expected to return any value. Flag = 1 incase result expected, Flag = 0 if not.
        {
            try
            {
                connection.Open();
                NpgsqlCommand _cmd = new NpgsqlCommand(query, connection);

                if (flag == 1)
                {
                    return _cmd.ExecuteReader();
                }
                else
                {
                    return _cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException e)
            {
                return e.ErrorCode;
            }

        }

    }
}
