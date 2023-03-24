using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace meuprimeirocrud
{
    internal class conexao
    {
        public MySqlConnection conectar;
        public string servidor;
        public string database;
        public string usuario;
        public string senha;
        public string porta;

        public conexao()
        {
            inicializar();
        }
        public void inicializar()
        {
            servidor = "127.0.0.1";
            database = "meuprimeiroCRUD";
            usuario= "root";
            senha= "";
            porta= "3306";

            string conexaostring;
            conexaostring="SERVER="+servidor+";"+"DATABASE="+database+";"+"UID="+usuario+";"+"PASSWORD="+senha+";"+"PORT="+porta+";";

            conectar= new MySqlConnection(conexaostring);

        }
        public bool abrirconexao()
        {
            try
            {
                conectar.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                switch(ex.Number)
                {
                    case 0: System.Windows.Forms.MessageBox.Show("Não foi possível conectar ao banco"); break;
                    case 1045: System.Windows.Forms.MessageBox.Show("Usuario ou senha invalido! Verifique"); break;
                }
                return false;
            } 
        }
        public bool fecharconexao()
        {
            try
            {
                conectar.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
