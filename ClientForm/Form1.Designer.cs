namespace ClientForm
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btHora = new System.Windows.Forms.Button();
            this.btFecha = new System.Windows.Forms.Button();
            this.btTodo = new System.Windows.Forms.Button();
            this.btApagar = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btConectar = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btHora
            // 
            this.btHora.Location = new System.Drawing.Point(12, 12);
            this.btHora.Name = "btHora";
            this.btHora.Size = new System.Drawing.Size(102, 53);
            this.btHora.TabIndex = 0;
            this.btHora.Tag = "HORA";
            this.btHora.Text = "HORA";
            this.btHora.UseVisualStyleBackColor = true;
            this.btHora.Click += new System.EventHandler(this.Click_Boton);
            // 
            // btFecha
            // 
            this.btFecha.Location = new System.Drawing.Point(120, 12);
            this.btFecha.Name = "btFecha";
            this.btFecha.Size = new System.Drawing.Size(102, 53);
            this.btFecha.TabIndex = 1;
            this.btFecha.Tag = "FECHA";
            this.btFecha.Text = "FECHA";
            this.btFecha.UseVisualStyleBackColor = true;
            this.btFecha.Click += new System.EventHandler(this.Click_Boton);
            // 
            // btTodo
            // 
            this.btTodo.Location = new System.Drawing.Point(12, 71);
            this.btTodo.Name = "btTodo";
            this.btTodo.Size = new System.Drawing.Size(102, 53);
            this.btTodo.TabIndex = 3;
            this.btTodo.Tag = "TODO";
            this.btTodo.Text = "TODO";
            this.btTodo.UseVisualStyleBackColor = true;
            this.btTodo.Click += new System.EventHandler(this.Click_Boton);
            // 
            // btApagar
            // 
            this.btApagar.Location = new System.Drawing.Point(120, 71);
            this.btApagar.Name = "btApagar";
            this.btApagar.Size = new System.Drawing.Size(102, 53);
            this.btApagar.TabIndex = 2;
            this.btApagar.Tag = "APAGAR";
            this.btApagar.Text = "APAGAR";
            this.btApagar.UseVisualStyleBackColor = true;
            this.btApagar.Click += new System.EventHandler(this.Click_Boton);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 131);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 17);
            this.lblResult.TabIndex = 4;
            // 
            // btConectar
            // 
            this.btConectar.Location = new System.Drawing.Point(499, 26);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(155, 53);
            this.btConectar.TabIndex = 5;
            this.btConectar.Text = "Cambiar IP o puerto";
            this.btConectar.UseVisualStyleBackColor = true;
            this.btConectar.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(367, 15);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 22);
            this.txtIP.TabIndex = 6;
            this.txtIP.Text = "127.0.0.1";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(367, 59);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(100, 22);
            this.txtPuerto.TabIndex = 7;
            this.txtPuerto.Text = "31416";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(315, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Puerto";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btConectar);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btTodo);
            this.Controls.Add(this.btApagar);
            this.Controls.Add(this.btFecha);
            this.Controls.Add(this.btHora);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Server Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btHora;
        private System.Windows.Forms.Button btFecha;
        private System.Windows.Forms.Button btTodo;
        private System.Windows.Forms.Button btApagar;
        public System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btConectar;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

