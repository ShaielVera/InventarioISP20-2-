namespace Desktop.Views
{
    partial class ProbandoIA_Gemini
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
            TxtConsulta = new TextBox();
            BtnEnviar = new Button();
            label1 = new Label();
            TxtRespuesta = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // TxtConsulta
            // 
            TxtConsulta.Location = new Point(122, 71);
            TxtConsulta.Name = "TxtConsulta";
            TxtConsulta.Size = new Size(512, 31);
            TxtConsulta.TabIndex = 0;
            // 
            // BtnEnviar
            // 
            BtnEnviar.Location = new Point(675, 71);
            BtnEnviar.Name = "BtnEnviar";
            BtnEnviar.Size = new Size(112, 34);
            BtnEnviar.TabIndex = 1;
            BtnEnviar.Text = "Enviar";
            BtnEnviar.UseVisualStyleBackColor = true;
            BtnEnviar.Click += BtnEnviar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(122, 33);
            label1.Name = "label1";
            label1.Size = new Size(164, 25);
            label1.TabIndex = 2;
            label1.Text = "Ingrese su consulta";
            // 
            // TxtRespuesta
            // 
            TxtRespuesta.Location = new Point(122, 164);
            TxtRespuesta.Multiline = true;
            TxtRespuesta.Name = "TxtRespuesta";
            TxtRespuesta.Size = new Size(665, 242);
            TxtRespuesta.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 136);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 4;
            label2.Text = "Respuesta";
            // 
            // ProbandoIA_Gemini
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 493);
            Controls.Add(label2);
            Controls.Add(TxtRespuesta);
            Controls.Add(label1);
            Controls.Add(BtnEnviar);
            Controls.Add(TxtConsulta);
            Name = "ProbandoIA_Gemini";
            Text = "ProbandoIA_Gemini";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtConsulta;
        private Button BtnEnviar;
        private Label label1;
        private TextBox TxtRespuesta;
        private Label label2;
    }
}