﻿using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Collections.Generic;

namespace kitbox_user_interface_V1
{

    public class QueryKitbox
    {

        public static List<string> SpecsBoxList(MySqlConnection conn, string SelectSQL, string WhereSQL)
        {
            List<string> result = new List<string>();
            string sql = "Select " + SelectSQL +" from kitbox where " + WhereSQL;
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            {
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        string WhereSQLAnswer = reader.GetString(reader.GetOrdinal(SelectSQL));
                        if (!result.Contains(WhereSQLAnswer))
                        {
                            result.Add(WhereSQLAnswer);
                        }
                    }
                }
            }
            return result;
        }

        public static List<string> ColumnList(MySqlConnection conn, string Column)
        {
            List<string> result = new List<string>();
            string sql = "Select " + Column + " from kitbox";
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            {
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        string WhereSQLAnswer = reader.GetString(reader.GetOrdinal(Column));
                        result.Add(WhereSQLAnswer);
                    }
                }
            }
            return result;
        }

        public static void UpdateDbComponents(MySqlConnection conn, string SetSQL, string WhereSQL)
        {
            string sql = "Update kitbox set " + SetSQL + " where " + WhereSQL;
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.UpdateCommand = cmd;
                adapter.UpdateCommand.ExecuteNonQuery();
            }
        }
    }
}
