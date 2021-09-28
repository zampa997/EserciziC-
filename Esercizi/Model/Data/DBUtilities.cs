using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Esercizi.Model.Data
{
    public static class DBUtilities
    {
        public static int GetInt32(this SqlDataReader reader, string name)
        {
            return reader.GetInt32(reader.GetOrdinal(name));
        }
        public static string GetString(this SqlDataReader reader, string name)
        {
            return reader.GetString(reader.GetOrdinal(name));
        }
        public static bool? GetBoolean(this SqlDataReader reader, string name)
        {
            return reader.GetBoolean(reader.GetOrdinal(name));
        }
        public static bool GetNBoolean(this SqlDataReader reader, string name) //N=NON NULLABLE OK?
        {
            return reader.GetBoolean(reader.GetOrdinal(name));
        }
    }
}
