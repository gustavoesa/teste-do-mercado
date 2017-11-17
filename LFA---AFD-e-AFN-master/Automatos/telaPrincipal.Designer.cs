namespace Automatos
{
    partial class telaPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCarregaAutomato = new System.Windows.Forms.Button();
            this.txtCaminhoAutomato = new System.Windows.Forms.TextBox();
            this.rTxtAutomatoCarregado = new System.Windows.Forms.RichTextBox();
            this.lblAutomaCarregado = new System.Windows.Forms.Label();
            this.lblMostraErro = new System.Windows.Forms.Label();
            this.txtCaminhoPalavras = new System.Windows.Forms.TextBox();
            this.btnCarregaPalavras = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rTxtAutomatoConvertido = new System.Windows.Forms.RichTextBox();
            this.lblAutomatoConvertido = new System.Windows.Forms.Label();
            this.btnConverteAFD = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnCarregaAutomato
            // 
            this.btnCarregaAutomato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregaAutomato.Location = new System.Drawing.Point(12, 2);
            this.btnCarregaAutomato.Name = "btnCarregaAutomato";
            this.btnCarregaAutomato.Size = new System.Drawing.Size(151, 33);
            this.btnCarregaAutomato.TabIndex = 0;
            this.btnCarregaAutomato.Text = "Carregar Autômato";
            this.btnCarregaAutomato.UseVisualStyleBackColor = true;
            this.btnCarregaAutomato.Click += new System.EventHandler(this.btnCarregaAutomato_Click);
            // 
            // txtCaminhoAutomato
            // 
            this.txtCaminhoAutomato.Enabled = false;
            this.txtCaminhoAutomato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaminhoAutomato.Location = new System.Drawing.Point(12, 41);
            this.txtCaminhoAutomato.Name = "txtCaminhoAutomato";
            this.txtCaminhoAutomato.ReadOnly = true;
            this.txtCaminhoAutomato.Size = new System.Drawing.Size(151, 22);
            this.txtCaminhoAutomato.TabIndex = 1;
            // 
            // rTxtAutomatoCarregado
            // 
            this.rTxtAutomatoCarregado.Location = new System.Drawing.Point(12, 123);
            this.rTxtAutomatoCarregado.Name = "rTxtAutomatoCarregado";
            this.rTxtAutomatoCarregado.ReadOnly = true;
            this.rTxtAutomatoCarregado.Size = new System.Drawing.Size(378, 113);
            this.rTxtAutomatoCarregado.TabIndex = 2;
            this.rTxtAutomatoCarregado.Text = "";
            // 
            // lblAutomaCarregado
            // 
            this.lblAutomaCarregado.AutoSize = true;
            this.lblAutomaCarregado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutomaCarregado.Location = new System.Drawing.Point(12, 104);
            this.lblAutomaCarregado.Name = "lblAutomaCarregado";
            this.lblAutomaCarregado.Size = new System.Drawing.Size(133, 16);
            this.lblAutomaCarregado.TabIndex = 3;
            this.lblAutomaCarregado.Text = "Autômato Carregado";
            // 
            // lblMostraErro
            // 
            this.lblMostraErro.AutoSize = true;
            this.lblMostraErro.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostraErro.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMostraErro.Location = new System.Drawing.Point(12, 77);
            this.lblMostraErro.Name = "lblMostraErro";
            this.lblMostraErro.Size = new System.Drawing.Size(87, 16);
            this.lblMostraErro.TabIndex = 4;
            this.lblMostraErro.Text = "Formato Inválido";
            this.lblMostraErro.Visible = false;
            this.lblMostraErro.Click += new System.EventHandler(this.lblErro_Click);
            // 
            // txtCaminhoPalavras
            // 
            this.txtCaminhoPalavras.Enabled = false;
            this.txtCaminhoPalavras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaminhoPalavras.Location = new System.Drawing.Point(249, 37);
            this.txtCaminhoPalavras.Name = "txtCaminhoPalavras";
            this.txtCaminhoPalavras.ReadOnly = true;
            this.txtCaminhoPalavras.Size = new System.Drawing.Size(151, 22);
            this.txtCaminhoPalavras.TabIndex = 6;
            // 
            // btnCarregaPalavras
            // 
            this.btnCarregaPalavras.Enabled = false;
            this.btnCarregaPalavras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregaPalavras.Location = new System.Drawing.Point(249, 2);
            this.btnCarregaPalavras.Name = "btnCarregaPalavras";
            this.btnCarregaPalavras.Size = new System.Drawing.Size(151, 33);
            this.btnCarregaPalavras.TabIndex = 5;
            this.btnCarregaPalavras.Text = "Carregar Palavras";
            this.btnCarregaPalavras.UseVisualStyleBackColor = true;
            this.btnCarregaPalavras.Click += new System.EventHandler(this.btnCarregaPalavras_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // richAFN
            // 
            this.rTxtAutomatoConvertido.Location = new System.Drawing.Point(12, 269);
            this.rTxtAutomatoConvertido.Name = "richAFN";
            this.rTxtAutomatoConvertido.ReadOnly = true;
            this.rTxtAutomatoConvertido.Size = new System.Drawing.Size(388, 113);
            this.rTxtAutomatoConvertido.TabIndex = 9;
            this.rTxtAutomatoConvertido.Text = "";
            this.rTxtAutomatoConvertido.Visible = false;
            // 
            // lblAutomatoConvertido
            // 
            this.lblAutomatoConvertido.AutoSize = true;
            this.lblAutomatoConvertido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutomatoConvertido.Location = new System.Drawing.Point(12, 250);
            this.lblAutomatoConvertido.Name = "lblAutomatoConvertido";
            this.lblAutomatoConvertido.Size = new System.Drawing.Size(131, 16);
            this.lblAutomatoConvertido.TabIndex = 10;
            this.lblAutomatoConvertido.Text = "Autômato convertido";
            this.lblAutomatoConvertido.Visible = false;
            // 
            // button1
            // 
            this.btnConverteAFD.Location = new System.Drawing.Point(259, 240);
            this.btnConverteAFD.Name = "button1";
            this.btnConverteAFD.Size = new System.Drawing.Size(131, 23);
            this.btnConverteAFD.TabIndex = 11;
            this.btnConverteAFD.Text = "Converter para AFD";
            this.btnConverteAFD.UseVisualStyleBackColor = true;
            this.btnConverteAFD.Visible = false;
            this.btnConverteAFD.Click += new System.EventHandler(this.button1_Click);
            // 
            // telaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 458);
            this.Controls.Add(this.btnConverteAFD);
            this.Controls.Add(this.lblAutomatoConvertido);
            this.Controls.Add(this.rTxtAutomatoConvertido);
            this.Controls.Add(this.txtCaminhoPalavras);
            this.Controls.Add(this.btnCarregaPalavras);
            this.Controls.Add(this.lblMostraErro);
            this.Controls.Add(this.lblAutomaCarregado);
            this.Controls.Add(this.rTxtAutomatoCarregado);
            this.Controls.Add(this.txtCaminhoAutomato);
            this.Controls.Add(this.btnCarregaAutomato);
            this.Name = "telaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leitor de Autômatos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCarregaAutomato;
        private System.Windows.Forms.TextBox txtCaminhoAutomato;
        private System.Windows.Forms.RichTextBox rTxtAutomatoCarregado;
        private System.Windows.Forms.Label lblAutomaCarregado;
        private System.Windows.Forms.Label lblMostraErro;
        private System.Windows.Forms.TextBox txtCaminhoPalavras;
        private System.Windows.Forms.Button btnCarregaPalavras;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox rTxtAutomatoConvertido;
        private System.Windows.Forms.Label lblAutomatoConvertido;
        private System.Windows.Forms.Button btnConverteAFD;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

