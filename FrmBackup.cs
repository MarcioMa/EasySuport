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

namespace EasySuport
{
    public partial class FrmBackup : Form
    {
        DataTable dataTable = new DataTable();

        public FrmBackup()
        {
            InitializeComponent();
        }

        private void FrmBackup_Load(object sender, EventArgs e)
        {
            try
            {
                CarregaDatabase();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cBoxRestaurar_DropDown(object sender, EventArgs e)
        {
            CarregaDatabase();
        }

        private void CarregaDatabase()
        {
            using (var dbConnection = new System.Data.SqlClient.SqlConnection(@"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=dbRegistro;Integrated Security=True"))
            {
                dbConnection.Open();

                using (var command = new System.Data.SqlClient.SqlCommand("SELECT physical_device_name FROM msdb.dbo.backupmediafamily " +
                "INNER JOIN msdb.dbo.backupset ON msdb.dbo.backupmediafamily.media_set_id = msdb.dbo.backupset.media_set_id " +
                "WHERE (msdb.dbo.backupset.database_name LIKE @DatabaseName)", dbConnection))
                {
                    command.Parameters.AddWithValue("DatabaseName", textBoxDB.Text);

                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                        dataTable.Columns.Add("FriendlyName");

                        foreach (DataRow row in dataTable.Rows)
                        {
                            row["FriendlyName"] = System.IO.Path.GetFileName(row["physical_device_name"].ToString());
                        }

                        if (cBoxRestaurar.DataSource != null && cBoxRestaurar.DataSource is DataTable)
                        {
                            var oldTable = ((DataTable)cBoxRestaurar.DataSource);
                            cBoxRestaurar.DataSource = null;
                            oldTable.Dispose();
                        }
                        cBoxRestaurar.DataSource = dataTable;
                        cBoxRestaurar.DisplayMember = "FriendlyName";
                        cBoxRestaurar.ValueMember = "physical_device_name";
                        dbConnection.Close();

                    }
                }
            }
        }

        private void bntBackup_Click(object sender, EventArgs e)
        {
            var server = new Microsoft.SqlServer.Management.Smo.Server(textBoxServidor.Text);
            var backup = new Microsoft.SqlServer.Management.Smo.Backup();
            backup.Database = textBoxDB.Text;
            backup.Incremental = false;
            string nomeArquivoBackup = string.Format("{0}_{1:yyyyMMdd_HHmmss}.bak", textBoxDB.Text, DateTime.Now);
            backup.Devices.AddDevice(nomeArquivoBackup, Microsoft.SqlServer.Management.Smo.DeviceType.File);
            backup.SqlBackup(server);
            MessageBox.Show(string.Format("Backup '{0}' concluído com sucesso.", nomeArquivoBackup), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBoxProcurar_TextChanged(object sender, EventArgs e)
        {

            if (textBoxProcurar.Text == string.Empty)
            {
                bntProcura.Enabled = false;
            }
            else
            {
                 bntProcura.Enabled = true;
            }
        }

        private void bntProcura_Click(object sender, EventArgs e)
        {
            if (textBoxProcurar.Text != @"C:\") openFileDialog1.InitialDirectory = textBoxProcurar.Text;

            openFileDialog1.Filter = "SQL backup (*.bak)|*.bak";
            openFileDialog1.FilterIndex = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxProcurar.Text = openFileDialog1.FileName;
                bntRestaurar.Enabled = true;
            }
            else
            {
                textBoxProcurar.Text = "";
            }
        }

        private void bntRestaurar_Click(object sender, EventArgs e)
        {
            bntRestaurar.Enabled = false;
        }

        private void bntApagar_Click(object sender, EventArgs e)
        {
            using (var dbConnection = new System.Data.SqlClient.SqlConnection(@"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=dbRegistro;Integrated Security=True"))
            {
                dbConnection.Open();

                if (MessageBox.Show("Deseja remover este registro?", "Ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dataTable.Rows[cBoxRestaurar.SelectedIndex].Delete();
                    cBoxRestaurar.Refresh();
                    MessageBox.Show("Registro apagado com sucesso!", "Aviso");
                }

                dbConnection.Close();
            }
        }

        private void cBoxRestaurar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxRestaurar.SelectedItem == null)
            {
                bntApagar.Enabled = false;
            }
            else
            {
                bntApagar.Enabled = true;
            }
        }
    }
}
