namespace meuprimeirocrud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        pessoas pes = new pessoas();
        private void btn_inserir_Click(object sender, EventArgs e)
        {
            try
            {
                pes.set_nome(txt_nome.Text);
                pes.set_endereco(txt_endereco.Text);
                pes.set_celular(txt_celular.Text);
                pes.inserir();
                dgv_dados.DataSource = pes.consultar();
            }
            finally
            {
                MessageBox.Show("Informações inseridas com sucesso");
                txt_nome.Clear();
                txt_endereco.Clear();
                txt_celular.Clear();
                txt_nome.Focus();
            }
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            dgv_dados.DataSource= pes.consultar();
            //alteração dos registros
            dgv_dados.Columns["nome"].HeaderText = txt_nome.Text;
            dgv_dados.Columns["endereco"].HeaderText = txt_endereco.Text;
            dgv_dados.Columns["celular"].HeaderText = txt_celular.Text;
            txt_nome.Focus();
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            try
            {
                pes.set_nome(txt_nome.Text);
                pes.set_endereco(txt_endereco.Text);
                pes.set_celular(txt_celular.Text);
                pes.alterar();
                dgv_dados.DataSource = pes.consultar();
            }
            finally
            {
                MessageBox.Show("Informações alteradas com sucesso!");
            }
        }

        private void dgv_dados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int codigoIDX = dgv_dados.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgv_dados.Rows[codigoIDX];

            string nomepessoa = Convert.ToString(selectedRow.Cells["nome"].Value);

            string enderecopessoa = Convert.ToString(selectedRow.Cells["endereco"].Value);

            string celularpessoa = Convert.ToString(selectedRow.Cells["celular"].Value);

            txt_nome.Text = nomepessoa;
            txt_endereco.Text = enderecopessoa;
            txt_celular.Text = celularpessoa;
            
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txt_nome.Clear();
            txt_endereco.Clear();
            txt_celular.Clear();
            txt_nome.Focus();
        }
    }
}