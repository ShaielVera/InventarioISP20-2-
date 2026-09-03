namespace Desktop.Views
{
    partial class ArticulosView
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
            ListAlumnos = new ListBox();
            BtnAgregarAlumno = new Button();
            SuspendLayout();
            // 
            // ListAlumnos
            // 
            ListAlumnos.FormattingEnabled = true;
            ListAlumnos.ItemHeight = 25;
            ListAlumnos.Location = new Point(73, 58);
            ListAlumnos.Name = "ListAlumnos";
            ListAlumnos.Size = new Size(658, 179);
            ListAlumnos.TabIndex = 0;
            // 
            // BtnAgregarAlumno
            // 
            BtnAgregarAlumno.Location = new Point(322, 287);
            BtnAgregarAlumno.Name = "BtnAgregarAlumno";
            BtnAgregarAlumno.Size = new Size(167, 34);
            BtnAgregarAlumno.TabIndex = 1;
            BtnAgregarAlumno.Text = "Agregar alumno";
            BtnAgregarAlumno.UseVisualStyleBackColor = true;
            BtnAgregarAlumno.Click += BtnAgregarAlumno_Click;
            // 
            // ArticulosView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnAgregarAlumno);
            Controls.Add(ListAlumnos);
            Name = "ArticulosView";
            Text = "ArticulosView";
            ResumeLayout(false);
        }

        #endregion

        private ListBox ListAlumnos;
        private Button BtnAgregarAlumno;
    }
}