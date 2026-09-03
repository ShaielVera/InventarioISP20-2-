namespace Desktop
{
    partial class MenuPrincipalView
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
            BtnSaludo = new FontAwesome.Sharp.IconButton();
            menuStrip1 = new MenuStrip();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            SubMenuArticulos = new FontAwesome.Sharp.IconMenuItem();
            SubmenuCategorias = new FontAwesome.Sharp.IconMenuItem();
            subMenuClientesSupabase = new FontAwesome.Sharp.IconMenuItem();
            subMenuClientes = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            SubMenuSalirDelSistema = new FontAwesome.Sharp.IconMenuItem();
            SubMenuPruebasGemini = new FontAwesome.Sharp.IconMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnSaludo
            // 
            BtnSaludo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnSaludo.BackColor = SystemColors.ActiveCaption;
            BtnSaludo.Cursor = Cursors.Hand;
            BtnSaludo.IconChar = FontAwesome.Sharp.IconChar.House;
            BtnSaludo.IconColor = Color.Black;
            BtnSaludo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSaludo.IconSize = 35;
            BtnSaludo.ImageAlign = ContentAlignment.MiddleLeft;
            BtnSaludo.Location = new Point(12, 466);
            BtnSaludo.Name = "BtnSaludo";
            BtnSaludo.Size = new Size(161, 54);
            BtnSaludo.TabIndex = 0;
            BtnSaludo.Text = "Saludo";
            BtnSaludo.UseVisualStyleBackColor = false;
            BtnSaludo.Click += BtnSaludo_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { iconMenuItem1, iconMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(957, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { SubMenuArticulos, SubmenuCategorias, subMenuClientesSupabase, subMenuClientes, SubMenuPruebasGemini });
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.House;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(118, 29);
            iconMenuItem1.Text = "Principal";
            // 
            // SubMenuArticulos
            // 
            SubMenuArticulos.IconChar = FontAwesome.Sharp.IconChar.Bars;
            SubMenuArticulos.IconColor = Color.Black;
            SubMenuArticulos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuArticulos.Name = "SubMenuArticulos";
            SubMenuArticulos.Size = new Size(361, 34);
            SubMenuArticulos.Text = "Articulos";
            SubMenuArticulos.Click += SubMenuArticulos_Click;
            // 
            // SubmenuCategorias
            // 
            SubmenuCategorias.IconChar = FontAwesome.Sharp.IconChar.Neuter;
            SubmenuCategorias.IconColor = Color.Black;
            SubmenuCategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubmenuCategorias.Name = "SubmenuCategorias";
            SubmenuCategorias.Size = new Size(361, 34);
            SubmenuCategorias.Text = "Categorías";
            SubmenuCategorias.Click += SubmenuCategorias_Click;
            // 
            // subMenuClientesSupabase
            // 
            subMenuClientesSupabase.IconChar = FontAwesome.Sharp.IconChar.User;
            subMenuClientesSupabase.IconColor = Color.Black;
            subMenuClientesSupabase.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuClientesSupabase.Name = "subMenuClientesSupabase";
            subMenuClientesSupabase.Size = new Size(361, 34);
            subMenuClientesSupabase.Text = "Clientes con paquete Supabase";
            subMenuClientesSupabase.Click += subMenuClientesSupabase_Click;
            // 
            // subMenuClientes
            // 
            subMenuClientes.IconChar = FontAwesome.Sharp.IconChar.User;
            subMenuClientes.IconColor = Color.Black;
            subMenuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuClientes.Name = "subMenuClientes";
            subMenuClientes.Size = new Size(361, 34);
            subMenuClientes.Text = "Clientes";
            subMenuClientes.Click += subMenuClientes_Click;
            // 
            // iconMenuItem2
            // 
            iconMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { SubMenuSalirDelSistema });
            iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            iconMenuItem2.IconColor = Color.Black;
            iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem2.Name = "iconMenuItem2";
            iconMenuItem2.Size = new Size(85, 29);
            iconMenuItem2.Text = "Salir";
            // 
            // SubMenuSalirDelSistema
            // 
            SubMenuSalirDelSistema.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            SubMenuSalirDelSistema.IconColor = Color.Black;
            SubMenuSalirDelSistema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuSalirDelSistema.Name = "SubMenuSalirDelSistema";
            SubMenuSalirDelSistema.Size = new Size(241, 34);
            SubMenuSalirDelSistema.Text = "Salir del sistema";
            SubMenuSalirDelSistema.Click += SubMenuSalirDelSistema_Click;
            // 
            // SubMenuPruebasGemini
            // 
            SubMenuPruebasGemini.IconChar = FontAwesome.Sharp.IconChar.None;
            SubMenuPruebasGemini.IconColor = Color.Black;
            SubMenuPruebasGemini.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuPruebasGemini.Name = "SubMenuPruebasGemini";
            SubMenuPruebasGemini.Size = new Size(361, 34);
            SubMenuPruebasGemini.Text = "Pruebas con IA - Gemini";
            SubMenuPruebasGemini.Click += SubMenuPruebasGemini_Click;
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 532);
            Controls.Add(BtnSaludo);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipalView";
            Text = "Sistema de Inventario ISP20 - 2do año TSDS";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton BtnSaludo;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem SubMenuSalirDelSistema;
        private FontAwesome.Sharp.IconMenuItem SubMenuArticulos;
        private FontAwesome.Sharp.IconMenuItem SubmenuCategorias;
        private FontAwesome.Sharp.IconMenuItem subMenuClientes;
        private FontAwesome.Sharp.IconMenuItem subMenuClientesSupabase;
        private FontAwesome.Sharp.IconMenuItem SubMenuPruebasGemini;
    }
}
