
namespace EasySuport
{
    partial class FrmBackup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bntProcura = new System.Windows.Forms.Button();
            this.textBoxProcurar = new System.Windows.Forms.TextBox();
            this.bntRestaurar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cBoxRestaurar = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxServidor = new System.Windows.Forms.TextBox();
            this.textBoxDB = new System.Windows.Forms.TextBox();
            this.bntBackup = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bntApagar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bntProcura
            // 
            this.bntProcura.Location = new System.Drawing.Point(239, 25);
            this.bntProcura.Name = "bntProcura";
            this.bntProcura.Size = new System.Drawing.Size(91, 26);
            this.bntProcura.TabIndex = 6;
            this.bntProcura.Text = "Procurar...";
            this.bntProcura.UseVisualStyleBackColor = true;
            this.bntProcura.Click += new System.EventHandler(this.bntProcura_Click);
            // 
            // textBoxProcurar
            // 
            this.textBoxProcurar.BackColor = System.Drawing.Color.White;
            this.textBoxProcurar.Location = new System.Drawing.Point(16, 25);
            this.textBoxProcurar.Name = "textBoxProcurar";
            this.textBoxProcurar.ReadOnly = true;
            this.textBoxProcurar.Size = new System.Drawing.Size(218, 26);
            this.textBoxProcurar.TabIndex = 8;
            this.textBoxProcurar.TextChanged += new System.EventHandler(this.textBoxProcurar_TextChanged);
            // 
            // bntRestaurar
            // 
            this.bntRestaurar.Enabled = false;
            this.bntRestaurar.Location = new System.Drawing.Point(16, 57);
            this.bntRestaurar.Name = "bntRestaurar";
            this.bntRestaurar.Size = new System.Drawing.Size(314, 28);
            this.bntRestaurar.TabIndex = 9;
            this.bntRestaurar.Text = "Iniciar";
            this.bntRestaurar.UseVisualStyleBackColor = true;
            this.bntRestaurar.Click += new System.EventHandler(this.bntRestaurar_Click);
            // 
            // cBoxRestaurar
            // 
            this.cBoxRestaurar.FormattingEnabled = true;
            this.cBoxRestaurar.Location = new System.Drawing.Point(6, 57);
            this.cBoxRestaurar.Name = "cBoxRestaurar";
            this.cBoxRestaurar.Size = new System.Drawing.Size(255, 28);
            this.cBoxRestaurar.TabIndex = 10;
            this.cBoxRestaurar.SelectedIndexChanged += new System.EventHandler(this.cBoxRestaurar_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxProcurar);
            this.groupBox1.Controls.Add(this.bntRestaurar);
            this.groupBox1.Controls.Add(this.bntProcura);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 98);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Restaurar Backup";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database";
            // 
            // textBoxServidor
            // 
            this.textBoxServidor.BackColor = System.Drawing.Color.White;
            this.textBoxServidor.Location = new System.Drawing.Point(12, 56);
            this.textBoxServidor.Name = "textBoxServidor";
            this.textBoxServidor.ReadOnly = true;
            this.textBoxServidor.Size = new System.Drawing.Size(137, 26);
            this.textBoxServidor.TabIndex = 2;
            this.textBoxServidor.Text = ".\\SQLEXPRESS";
            // 
            // textBoxDB
            // 
            this.textBoxDB.BackColor = System.Drawing.Color.White;
            this.textBoxDB.Location = new System.Drawing.Point(155, 56);
            this.textBoxDB.Name = "textBoxDB";
            this.textBoxDB.ReadOnly = true;
            this.textBoxDB.Size = new System.Drawing.Size(171, 26);
            this.textBoxDB.TabIndex = 3;
            this.textBoxDB.Text = "dbRegistro";
            // 
            // bntBackup
            // 
            this.bntBackup.Location = new System.Drawing.Point(12, 88);
            this.bntBackup.Name = "bntBackup";
            this.bntBackup.Size = new System.Drawing.Size(314, 29);
            this.bntBackup.TabIndex = 4;
            this.bntBackup.Text = "Criar";
            this.bntBackup.UseVisualStyleBackColor = true;
            this.bntBackup.Click += new System.EventHandler(this.bntBackup_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxServidor);
            this.groupBox2.Controls.Add(this.textBoxDB);
            this.groupBox2.Controls.Add(this.bntBackup);
            this.groupBox2.Location = new System.Drawing.Point(12, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 132);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criar Backup";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bntApagar);
            this.groupBox3.Controls.Add(this.cBoxRestaurar);
            this.groupBox3.Location = new System.Drawing.Point(363, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 236);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista de backups armazenados";
            // 
            // bntApagar
            // 
            this.bntApagar.Enabled = false;
            this.bntApagar.Location = new System.Drawing.Point(6, 22);
            this.bntApagar.Name = "bntApagar";
            this.bntApagar.Size = new System.Drawing.Size(255, 29);
            this.bntApagar.TabIndex = 5;
            this.bntApagar.Text = "Remover da lista";
            this.bntApagar.UseVisualStyleBackColor = true;
            this.bntApagar.Click += new System.EventHandler(this.bntApagar_Click);
            // 
            // FrmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 253);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBackup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmBackup";
            this.Load += new System.EventHandler(this.FrmBackup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bntProcura;
        private System.Windows.Forms.TextBox textBoxProcurar;
        private System.Windows.Forms.Button bntRestaurar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cBoxRestaurar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxServidor;
        private System.Windows.Forms.TextBox textBoxDB;
        private System.Windows.Forms.Button bntBackup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bntApagar;
    }
}