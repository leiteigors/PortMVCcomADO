using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCcomADO.Rep
{
    public class TimeRepositorio
    {
        private SqlConnection sqlConn;

        private void Connection()
        {
            string cnxSTR = ConfigurationManager.ConnectionStrings["ConnStringDb1"].ToString();
            sqlConn = new SqlConnection(cnxSTR); 
        }

        public bool AdicionarTime(Models.Time time)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("InserirTime", sqlConn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Time", time.nome);
                command.Parameters.AddWithValue("@Estado", time.estado);
                command.Parameters.AddWithValue("@Cores", time.cores);

                sqlConn.Open();

                try
                {
                    i = command.ExecuteNonQuery();

                    if (i >= 1) { return true; } else { return false; }
                }
                catch (Exception e)
                {
                    string err = e.Message;
                    return false;
                }
                
            }
        }

        public List<Models.Time> ObterTimes()

        {
            Connection();

            List<Models.Time> tList = new List<Models.Time>();



            using (SqlCommand command = new SqlCommand("ObterTimes", sqlConn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                
                sqlConn.Open();

                SqlDataReader rd = command.ExecuteReader();

                while (rd.Read())

                {
                    Models.Time time = new Models.Time()
                    {
                        id = Convert.ToInt32(rd["TimeId"]),
                        nome = Convert.ToString(rd["Time"]),
                        estado = Convert.ToString(rd["Estado"]),
                        cores = Convert.ToString(rd["Cores"])
                    };

                    tList.Add(time);

                }
                sqlConn.Close();

                return tList;
            }
        }

        public Models.Time ObterPorId(int Id)

        {
            Connection();



            using (SqlCommand command = new SqlCommand("ObterPorId", sqlConn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@timeId", Id);
                
                sqlConn.Open();

                try
                {
                    SqlDataReader rd = command.ExecuteReader();

                    Models.Time myTime = new Models.Time();
                    while (rd.Read())
                    {
                        myTime.id = Convert.ToInt32(rd["TimeId"]);
                        myTime.nome = Convert.ToString(rd["Time"]);
                        myTime.estado = Convert.ToString(rd["Estado"]);
                        myTime.cores = Convert.ToString(rd["Cores"]);
                    }
                    sqlConn.Close();

                    return myTime;

                } catch (Exception e)
                {
                    string err = e.Message;
                    return null;
                }
                
            }
        }

        public bool AtualizarTime(Models.Time time)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("AtualizarTime", sqlConn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TimeId", time.id);
                command.Parameters.AddWithValue("@Time", time.nome);
                command.Parameters.AddWithValue("@Estado", time.estado);
                command.Parameters.AddWithValue("@Cores", time.cores);

                sqlConn.Open();

                i = command.ExecuteNonQuery();

                return i >= 1;
            }
        }

        public bool ExcluirTime(int id)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("ExcluirPorId", sqlConn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TimeId", id);
                
                sqlConn.Open();
                try
                {
                    i = command.ExecuteNonQuery();
                    if (i >= 1) { return true; } else { return false; }
                }
                catch (Exception e)
                {
                    string err = e.Message;
                    return false;
                }
                
            }
        }

    }
}