using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjetoFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = null;
        private string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wesll\OneDrive\Documentos\projeto_bd.mdf;Integrated Security=True;Connect Timeout=30";
        private string strSql = string.Empty;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            strSql = "insert into clientes (Id, Nome, Endereco, Bairro, Cidade, CEP, UF, Telefone) values (@Id, @Nome, @Endereco, @Bairro, @Cidade, @CEP, @UF, @Telefone)";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("Id", SqlDbType.Int).Value = txtId.Text;
            comando.Parameters.Add("Nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("Endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            comando.Parameters.Add("Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            comando.Parameters.Add("CEP", SqlDbType.VarChar).Value = mskCEP.Text;
            comando.Parameters.Add("UF", SqlDbType.VarChar).Value = txtUF.Text;
            comando.Parameters.Add("Telefone", SqlDbType.VarChar).Value = mskTelefone.Text;

            try
            {

                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cliente Cadastrado");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                sqlCon.Close();
            }
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            

        }

        private void tsbAlterar_Click(object sender, EventArgs e)
        {

        }

        private void tsbPesquisar_Click(object sender, EventArgs e)
        {
            strSql = "select * from clientes where Id=@Id";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@Id", SqlDbType.Int).Value = tstIdBuscar.Text;

            try
            {
                if (tstIdBuscar.Text == string.Empty)
                {
                    throw new Exception("Por favor, digite um ID");
                }
                sqlCon.Open();
                SqlDataReader dr = comando.ExecuteReader();
                

                if (dr.HasRows == false)
                {
                    throw new Exception("Id não cadastrado!");
                    dr.Read();

                }

                txtId.Text = Convert.ToString(dr["Id"]);
                txtNome.Text = Convert.ToString(dr["Nome"]);
                txtEndereco.Text = Convert.ToString(dr["Endereco"]);
                txtBairro.Text = Convert.ToString(dr["Bairro"]);
                txtCidade.Text = Convert.ToString(dr["Cidade"]);
                mskCEP.Text = Convert.ToString(dr["CEP"]);
                txtUF.Text = Convert.ToString(dr["UF"]);
                mskTelefone.Text = Convert.ToString(dr["Telefone"]);
                    
            }
                catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }

            finally
            {
                sqlCon.Close();
            }

            }

    }
}
