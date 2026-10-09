namespace Tienda
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Producto = new Label();
            label2 = new Label();
            Cantidad = new Label();
            tb_id_producto = new TextBox();
            txtCantidad = new TextBox();
            btnAgregar = new Button();
            lista = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)lista).BeginInit();
            SuspendLayout();
            // 
            // Producto
            // 
            Producto.AutoSize = true;
            Producto.Location = new Point(334, 41);
            Producto.Name = "Producto";
            Producto.Size = new Size(73, 25);
            Producto.TabIndex = 0;
            Producto.Text = "TIENDA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 119);
            label2.Name = "label2";
            label2.Size = new Size(138, 25);
            label2.TabIndex = 1;
            label2.Text = "ID del producto";
            label2.Click += label2_Click;
            // 
            // Cantidad
            // 
            Cantidad.AutoSize = true;
            Cantidad.Location = new Point(86, 215);
            Cantidad.Name = "Cantidad";
            Cantidad.Size = new Size(83, 25);
            Cantidad.TabIndex = 2;
            Cantidad.Text = "Cantidad";
            Cantidad.Click += Cantidad_Click;
            // 
            // tb_id_producto
            // 
            tb_id_producto.Location = new Point(228, 119);
            tb_id_producto.Name = "tb_id_producto";
            tb_id_producto.Size = new Size(150, 31);
            tb_id_producto.TabIndex = 3;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(228, 215);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(150, 31);
            txtCantidad.TabIndex = 4;
            txtCantidad.TextChanged += txtCantidad_TextChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(409, 166);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(112, 34);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lista
            // 
            lista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            lista.Location = new Point(150, 358);
            lista.Name = "lista";
            lista.RowHeadersWidth = 62;
            lista.Size = new Size(623, 225);
            lista.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(596, 330);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(397, 589);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 8;
            button1.Text = "Pagar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(112, 170);
            label3.Name = "label3";
            label3.Size = new Size(85, 25);
            label3.TabIndex = 9;
            label3.Text = "Producto";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 669);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(lista);
            Controls.Add(btnAgregar);
            Controls.Add(txtCantidad);
            Controls.Add(tb_id_producto);
            Controls.Add(Cantidad);
            Controls.Add(label2);
            Controls.Add(Producto);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)lista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Producto;
        private Label label2;
        private Label Cantidad;
        private TextBox tb_id_producto;
        private TextBox txtCantidad;
        private Button btnAgregar;
        private DataGridView lista;
        private Label label1;
        private Button button1;
        private Label label3;
    }
}
