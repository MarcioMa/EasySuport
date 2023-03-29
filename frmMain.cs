using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EasySuport
{
    public partial class frmMain : Form
    {

        SqlConnection dbConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Marcio\source\repos\EasySuport\dbRegistro.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        DataTable dataTable = new DataTable();
        int pos = 0;
        bool Atualizar;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        { 
            ExibirDados();

            //Configura tooltipstatus
            toolStripStatusLabel1.Text = "Data: " + DateTime.Now.ToString("dd/MM/yyyy");
            toolStripStatusLabel2.Text = "Hora: " + DateTime.Now.ToString("HH:mm");
            toolStripStatusLabel4.Text = "de { "+ dataTable.Rows.Count +" }";
        }

        public void ExibirDados()
        {
                dbConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT * FROM tb_Registro", dbConnection);
                dataAdapter.Fill(dataTable);
                dbConnection.Close();

            if (dataTable.Rows.Count > 0)
            {
                textBoxSolicitante.Text = dataTable.Rows[pos]["Solicitante"].ToString();
                textBoxCPF.Text = dataTable.Rows[pos]["CPF"].ToString();
                textBoxEmail.Text = dataTable.Rows[pos]["Email"].ToString();
                textBoxHospital.Text = dataTable.Rows[pos]["Hospital"].ToString();
                textBoxUnidade.Text = dataTable.Rows[pos]["Unidade"].ToString();
                textBoxSetor.Text = dataTable.Rows[pos]["Setor"].ToString();
                textBoxAndar.Text = dataTable.Rows[pos]["Andar"].ToString();
                textBoxRamal.Text = dataTable.Rows[pos]["Ramal"].ToString();
                textBoxProtocolo.Text = dataTable.Rows[pos]["Protocolo"].ToString();
                textBoxProblema.Text = dataTable.Rows[pos]["Problema"].ToString();
                textBoxCRM.Text = dataTable.Rows[pos]["CRM"].ToString();
                textBoxLogin.Text = dataTable.Rows[pos]["Login"].ToString();
                textBoxIPHST.Text = dataTable.Rows[pos]["HST_IP"].ToString();
                toolStripStatusLabel3.Text = "Registro: " + dataTable.Rows[pos]["id"].ToString();
            }
        }

        private void bntProximo_Click(object sender, EventArgs e)
        {
            if (pos < dataTable.Rows.Count -1)
            {
                pos += 1;
                ExibirDados();
            }  
        }

        private void bntVoltar_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos -= 1;
                ExibirDados();
            }
        }

        private void bntSalvar_Click(object sender, EventArgs e)
        { 
            try
            {
                dbConnection.Open();

                SqlCommand dbComando = new SqlCommand("SELECT * FROM tb_Registro WHERE Solicitante='" + textBoxSolicitante.Text + "'",dbConnection);
                SqlDataReader reader = dbComando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Atualizar = true;
                    }
                    reader.Close();
                }
                else
                {
                    Atualizar = false;
                    reader.Close();
                }

                if (Atualizar == true)
                {
                    if (MessageBox.Show("Deseja Atualizar o registro do usuario " + textBoxSolicitante.Text + " ? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sqlQuery = "UPDATE tb_Registro SET Email= @Email, Hospital=@Hospital, Unidade=@Unidade, Setor=@Setor, Andar=@Andar, Ramal=@Ramal, CRM=@CRM, Login=@Login, HST_IP=@HST_IP WHERE Solicitante='"+textBoxSolicitante.Text+"'";

                        SqlCommand sqlCommand = new SqlCommand(sqlQuery, dbConnection);
                        sqlCommand.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                        sqlCommand.Parameters.AddWithValue("@Hospital", textBoxHospital.Text);
                        sqlCommand.Parameters.AddWithValue("@Unidade", textBoxUnidade.Text);
                        sqlCommand.Parameters.AddWithValue("@Setor", textBoxSetor.Text);
                        sqlCommand.Parameters.AddWithValue("@Andar", textBoxAndar.Text);
                        sqlCommand.Parameters.AddWithValue("@Ramal", textBoxRamal.Text);
                        sqlCommand.Parameters.AddWithValue("@CRM", textBoxCRM.Text);
                        sqlCommand.Parameters.AddWithValue("@Login", textBoxLogin.Text);
                        sqlCommand.Parameters.AddWithValue("@HST_IP", textBoxIPHST.Text);

                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Registro atualizado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbConnection.Close();
                        ExibirDados();
                    }
                }
                //Atualizar = false
                else
                    {
                        SqlCommand dbCommand = new SqlCommand("INSERT INTO tb_Registro(Solicitante, CPF, Email, Hospital, Unidade, Setor, Andar, Ramal, Protocolo, Problema, CRM, Login, HST_IP) VALUES('" + textBoxSolicitante.Text + "', '" + textBoxCPF.Text + "', '" + textBoxEmail.Text + "', '" + textBoxHospital.Text + "', '" + textBoxUnidade.Text + "', '" + textBoxSetor.Text + "', '" + textBoxAndar.Text + "', '" + textBoxRamal.Text + "', '" + textBoxProtocolo.Text + "', '" + textBoxProblema.Text + "', '" + textBoxCRM.Text + "', '" + textBoxLogin.Text + "', '" + textBoxIPHST.Text + "')", dbConnection);
                        dbCommand.ExecuteNonQuery();
                        MessageBox.Show("Registro salvo com sucesso");
                    dbConnection.Close();
                    ExibirDados();
                }
                }
            catch (Exception)
            {
                throw;
            }
        }

        private void bntApagar_Click(object sender, EventArgs e)
        {

            if (textBoxSolicitante.Text == string.Empty && textBoxSolicitante.Text == "")
            {
                MessageBox.Show("Não existe registro selecionado!", "Aviso");
            }
            else
            {
                if (MessageBox.Show("Deseja apagar registro do usuario " + textBoxSolicitante.Text + " ? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        dbConnection.Open();
                        command = new SqlCommand("DELETE FROM tb_Registro WHERE Solicitante=@Solicitante ",dbConnection);

                        command.Parameters.AddWithValue("@Solicitante", textBoxSolicitante.Text);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Registro apagado com sucesso");
                        dataTable.Rows.Clear();
                        dbConnection.Close();
                        ExibirDados();

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public void limparFormulario()
        {
            textBoxSolicitante.Text = "";
            textBoxCPF.Text = "";
            textBoxHospital.Text = "";
            textBoxUnidade.Text = "";
            textBoxSetor.Text = "";
            textBoxAndar.Text= "";
            textBoxRamal.Text = "";
            textBoxProtocolo.Text = "";
            textBoxCRM.Text = "";
            textBoxLogin.Text = "";
            textBoxIPHST.Text = "";
            textBoxProblema.Text = "";
            textBoxEmail.Text = "";
        }

        private void bntPesquisar_Click(object sender, EventArgs e)
        {
            string valor = Interaction.InputBox("Informe o nome completo ou cpf", "Pesquisar");

            string sqlQuery = "SELECT * FROM tb_Registro WHERE Solicitante='"+ valor.ToString()+"'";

            dbConnection.Open();
            SqlCommand dbComando = new SqlCommand(sqlQuery, dbConnection);
            SqlDataReader reader = dbComando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    pos = Convert.ToInt32(reader["Id"].ToString());
                    textBoxSolicitante.Text = reader["Solicitante"].ToString();
                    textBoxCPF.Text = reader["CPF"].ToString();
                    textBoxEmail.Text = reader["Email"].ToString();
                    textBoxHospital.Text = reader["Hospital"].ToString();
                    textBoxUnidade.Text = reader["Unidade"].ToString();
                    textBoxSetor.Text = reader["Setor"].ToString();
                    textBoxAndar.Text = reader["Andar"].ToString();
                    textBoxRamal.Text = reader["Ramal"].ToString();
                    textBoxProtocolo.Text = reader["Protocolo"].ToString();
                    textBoxProblema.Text = reader["Problema"].ToString();
                    textBoxCRM.Text = reader["CRM"].ToString();
                    textBoxLogin.Text = reader["Login"].ToString();
                    textBoxIPHST.Text = reader["HST_IP"].ToString();
                    toolStripStatusLabel3.Text = "Registro: " + reader["Id"].ToString();
                }
                reader.Close();
                dbConnection.Close();
            }
            else
            {
                MessageBox.Show("Nenhum registro localizado para " + valor);
                reader.Close();
                dbConnection.Close();
            }
        }

        private void bntCopiaSolicitante_Click(object sender, EventArgs e)
        {
            textBoxSolicitante.SelectionStart = 0;
            textBoxSolicitante.SelectionLength = textBoxSolicitante.Text.Length;

            if (textBoxSolicitante.Text != "")
            {
                Clipboard.SetText(textBoxSolicitante.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiarCPF_Click(object sender, EventArgs e)
        {
            textBoxCPF.SelectionStart = 0;
            textBoxCPF.SelectionLength = textBoxCPF.Text.Length;

            if (textBoxCPF.Text != "")
            {
                Clipboard.SetText(textBoxCPF.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiarEmail_Click(object sender, EventArgs e)
        {
                textBoxEmail.SelectionStart = 0;
                textBoxEmail.SelectionLength = textBoxEmail.Text.Length;

                if (textBoxEmail.Text != "")
                {
                    Clipboard.SetText(textBoxEmail.SelectedText.ToString());
                    MessageBox.Show("informação copiada!", "Aviso");
                }
        }

        private void bntCopiarCRM_Click(object sender, EventArgs e)
        {
            textBoxCRM.SelectionStart = 0;
            textBoxCRM.SelectionLength = textBoxCRM.Text.Length;

            if (textBoxCRM.Text != "")
            {
                Clipboard.SetText(textBoxCRM.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiarHospital_Click(object sender, EventArgs e)
        {
            textBoxHospital.SelectionStart = 0;
            textBoxHospital.SelectionLength = textBoxHospital.Text.Length;

            if (textBoxHospital.Text != "")
            {
                Clipboard.SetText(textBoxHospital.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiaLogin_Click(object sender, EventArgs e)
        {
            textBoxLogin.SelectionStart = 0;
            textBoxLogin.SelectionLength = textBoxLogin.Text.Length;

            if (textBoxLogin.Text != "")
            {
                Clipboard.SetText(textBoxLogin.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiarUnidade_Click(object sender, EventArgs e)
        {
            textBoxUnidade.SelectionStart = 0;
            textBoxUnidade.SelectionLength = textBoxUnidade.Text.Length;

            if (textBoxUnidade.Text != "")
            {
                Clipboard.SetText(textBoxUnidade.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiarAndar_Click(object sender, EventArgs e)
        {
            textBoxAndar.SelectionStart = 0;
            textBoxAndar.SelectionLength = textBoxAndar.Text.Length;

            if (textBoxAndar.Text != "")
            {
                Clipboard.SetText(textBoxAndar.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiarSetor_Click(object sender, EventArgs e)
        {
            textBoxSetor.SelectionStart = 0;
            textBoxSetor.SelectionLength = textBoxSetor.Text.Length;

            if (textBoxSetor.Text != "")
            {
                Clipboard.SetText(textBoxSetor.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiarRamal_Click(object sender, EventArgs e)
        {
            textBoxRamal.SelectionStart = 0;
            textBoxRamal.SelectionLength = textBoxRamal.Text.Length;

            if (textBoxRamal.Text != "")
            {
                Clipboard.SetText(textBoxRamal.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiarProtocolo_Click(object sender, EventArgs e)
        {
            textBoxProtocolo.SelectionStart = 0;
            textBoxProtocolo.SelectionLength = textBoxProtocolo.Text.Length;

            if (textBoxProtocolo.Text != "")
            {
                Clipboard.SetText(textBoxProtocolo.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiarIP_Click(object sender, EventArgs e)
        {
            textBoxIPHST.SelectionStart = 0;
            textBoxIPHST.SelectionLength = textBoxIPHST.Text.Length;

            if (textBoxIPHST.Text != "")
            {
                Clipboard.SetText(textBoxIPHST.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiarProblema_Click(object sender, EventArgs e)
        {
            textBoxProblema.SelectionStart = 0;
            textBoxProblema.SelectionLength = textBoxProblema.Text.Length;

            if (textBoxProblema.Text != "")
            {
                Clipboard.SetText(textBoxProblema.SelectedText.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntCopiaTudo_Click(object sender, EventArgs e)
        {
            string CopiaTudo = 
                "Solicitante: " + textBoxSolicitante.Text + 
                Environment.NewLine + "CPF: " + textBoxCPF.Text +
                Environment.NewLine + "E-mail: " + textBoxEmail.Text +
                Environment.NewLine + "Hospital: " + textBoxHospital.Text + 
                Environment.NewLine + "Unidade: "+textBoxUnidade.Text +
                Environment.NewLine + "Setor: " + textBoxSetor.Text +
                Environment.NewLine + "Andar: " + textBoxAndar.Text +
                Environment.NewLine + "Ramal: " + textBoxRamal.Text +
                Environment.NewLine + "Protocolo: " + textBoxProtocolo.Text +
                Environment.NewLine + "CRM: " + textBoxCRM.Text +
                Environment.NewLine + "Login: " + textBoxLogin.Text +
                Environment.NewLine + "IP/HST/PRN: " + textBoxIPHST.Text +
                Environment.NewLine + "Descrição: " + textBoxProblema.Text +
                "";

            if (CopiaTudo != string.Empty)
            {
                Clipboard.SetText(CopiaTudo.ToString());
                MessageBox.Show("informação copiada!", "Aviso");
            }
        }

        private void bntEnviarCodigo_Click(object sender, EventArgs e)
        {
            if (this.Width == 648)
            {
                this.Width = 1070;
                bntEnviarCodigo.Text = "Fechar extra";
                bntRelatorio.Visible = true;
                bntEnviarEmail.Visible = true;
                tabControl.Visible = true;
            }
            else
            {
                this.Width = 648;
                bntEnviarCodigo.Text = "Abrir extra";
                bntRelatorio.Visible = false;
                bntEnviarEmail.Visible = false;
                tabControl.Visible = false;
             }
        }

        private void bntEnviarEmail_Click(object sender, EventArgs e)
        {
            string target = "https://outlook.live.com/mail/";

            Microsoft.Win32.RegistryKey key =
           Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\microsoft\\windows\\currentversion\\app paths\\OUTLOOK.EXE");
            string path = (string) key.GetValue("Path");

            if (path != null)
            {
                System.Diagnostics.Process.Start("OUTLOOK.EXE");
            }
            else
            {
                if (MessageBox.Show("Confirma abertura outlook via web?","Outlook Web", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(target);
                }
                else
                {
                    MessageBox.Show("Processo de e-mail cancelado", "Aviso");
                }
            }
        }

        private void bntAjustaIndex_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja ajusta index agora?", "Ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbConnection.Open();
                string Query = "insert into #temp From TbRegistro set identity_insert TbRegistro ON truncate table TbRegistro alter table #temp drop column Id set identity_insert TbRegistro OFF insert into TbRegistro select * from #temp";
                command = new SqlCommand(Query, dbConnection);
                command.ExecuteNonQuery();
                dbConnection.Close();
                MessageBox.Show("Ajuste realizado com sucesso!", "Aviso");
            }           
        }
    }
}
