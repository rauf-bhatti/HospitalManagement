﻿using System;
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


        public dynamic RunValidationQuery(string query)
        {
            dynamic resultToReturn;
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                NpgsqlCommand _cmd = new NpgsqlCommand(query, connection);

                resultToReturn = _cmd.ExecuteScalar();

                connection.Close();
                return resultToReturn;
            }
            catch (NpgsqlException e)
            {
                connection.Close();
                return e.ErrorCode;
            }

        }

        public dynamic RunReceiveQuery(string query, int flag) //Flag is set if the query is expected to return any value. Flag = 1 incase result expected, Flag = 0 if not.
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                NpgsqlCommand _cmd = new NpgsqlCommand(query, connection);

                return _cmd.ExecuteReader();
            }
            catch (NpgsqlException e)
            {
                connection.Close();
                return e.ErrorCode;
            }

        }

    }
}
