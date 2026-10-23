namespace Tienda
{
    partial class Form2
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
            btnGuardar = new Button();
            btnAbrir = new Button();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(318, 88);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 34);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar Registro";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // btnAbrir
            // 
            btnAbrir.Location = new Point(318, 206);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(112, 34);
            btnAbrir.TabIndex = 1;
            btnAbrir.Text = "Abrir archivo";
            btnAbrir.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAbrir);
            Controls.Add(btnGuardar);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGuardar;
        private Button btnAbrir;
    }
}