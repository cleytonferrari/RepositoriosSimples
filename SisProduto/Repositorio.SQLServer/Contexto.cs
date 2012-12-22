using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.SQLServer
{
    public class Contexto
    {
        private readonly SqlConnection minhaConexao;

        public Contexto()
        {
            minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["SisProduto"].ConnectionString);
            minhaConexao.Open();
        }

        public bool ExecutaComando(string strQuery)
        {

            var cmdComando = new SqlCommand
                                 {
                                     CommandText = strQuery,
                                     CommandType = CommandType.Text,
                                     Connection = minhaConexao
                                 };

            cmdComando.ExecuteNonQuery();
            return true;
        }

        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            return cmdComando.ExecuteReader();
        }

    }
}
