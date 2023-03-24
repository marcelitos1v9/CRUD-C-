using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace meuprimeirocrud
{
    internal class pessoas : conexao
    {
        private int _idx;
        private string _nome;
        private string _endereco;
        private string _celular;

        public void set_idx(int idx)
        {
            this._idx = idx;
        }
        public int get_idx()
        {
            return this._idx;
        }

        public void set_nome(string nome)
        {
            this._nome = nome;
        }
        public string get_nome()
        {
            return this._nome;
        }
        public void set_endereco(string endereco)
        {
            this._endereco = endereco;
        }
        public string get_endereco()
        {
            return this._endereco;
        }
        public void set_celular(string celular)
        {
            this._celular = celular;
        }
        public string get_celular()
        {
            return this._celular;
        }
        public void inserir()
        {
            string query = "INSERT INTO PESSOAS(NOME,ENDERECO,CELULAR) VALUES('" + get_nome() + "','" + get_endereco() + "','" + get_celular() + "')";

            if (this.abrirconexao() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharconexao();
            }
        }
        public void excluir()
        {
            string query = "DELETE FROM PESSOAS WHERE CELULAR='" + get_celular() + "'";
            if (this.abrirconexao() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharconexao();
            }
        }
        public void alterar()
        {
            string query = "UPDATE PESSOAS SET NOME='" + get_nome() + "',ENDERECO='" + get_endereco() + "'WHERE CELULAR='" + get_celular() + "'";
            if (this.abrirconexao() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharconexao();
            }
        }
        public DataTable consultar()
        {
            this.abrirconexao();
            string mSQL = "SELECT * FROM PESSOAS";
            MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            this.fecharconexao();
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
