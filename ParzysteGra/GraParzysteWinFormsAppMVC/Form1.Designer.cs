namespace GraParzysteWinFormsAppMVC
{
    partial class Form1
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
            this.richtxtbPoleGry = new System.Windows.Forms.RichTextBox();
            this.labelGracz1 = new System.Windows.Forms.Label();
            this.btnGracz1Graj = new System.Windows.Forms.Button();
            this.txtbGracz1 = new System.Windows.Forms.TextBox();
            this.txtbGracz2 = new System.Windows.Forms.TextBox();
            this.btnGracz2Graj = new System.Windows.Forms.Button();
            this.labelGracz2 = new System.Windows.Forms.Label();
            this.btnNowaGra = new System.Windows.Forms.Button();
            this.txtbMaxWartosc = new System.Windows.Forms.TextBox();
            this.btnPrzeslijParametry = new System.Windows.Forms.Button();
            this.labelMaxWartosc = new System.Windows.Forms.Label();
            this.txtbIloscLiczb = new System.Windows.Forms.TextBox();
            this.labelIloscLiczb = new System.Windows.Forms.Label();
            this.labelKomunikat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richtxtbPoleGry
            // 
            this.richtxtbPoleGry.Location = new System.Drawing.Point(12, 12);
            this.richtxtbPoleGry.Name = "richtxtbPoleGry";
            this.richtxtbPoleGry.Size = new System.Drawing.Size(776, 120);
            this.richtxtbPoleGry.TabIndex = 0;
            this.richtxtbPoleGry.Text = "";
            // 
            // labelGracz1
            // 
            this.labelGracz1.AutoSize = true;
            this.labelGracz1.Location = new System.Drawing.Point(406, 192);
            this.labelGracz1.Name = "labelGracz1";
            this.labelGracz1.Size = new System.Drawing.Size(47, 13);
            this.labelGracz1.TabIndex = 1;
            this.labelGracz1.Text = "Gracz 1:";
            this.labelGracz1.Visible = false;
            // 
            // btnGracz1Graj
            // 
            this.btnGracz1Graj.Location = new System.Drawing.Point(406, 231);
            this.btnGracz1Graj.Name = "btnGracz1Graj";
            this.btnGracz1Graj.Size = new System.Drawing.Size(100, 23);
            this.btnGracz1Graj.TabIndex = 3;
            this.btnGracz1Graj.Text = "Wybierz";
            this.btnGracz1Graj.UseVisualStyleBackColor = true;
            this.btnGracz1Graj.Visible = false;
            this.btnGracz1Graj.Click += new System.EventHandler(this.btnGracz1Graj_Click);
            // 
            // txtbGracz1
            // 
            this.txtbGracz1.Location = new System.Drawing.Point(406, 208);
            this.txtbGracz1.Name = "txtbGracz1";
            this.txtbGracz1.Size = new System.Drawing.Size(100, 20);
            this.txtbGracz1.TabIndex = 4;
            this.txtbGracz1.Visible = false;
            // 
            // txtbGracz2
            // 
            this.txtbGracz2.Location = new System.Drawing.Point(512, 208);
            this.txtbGracz2.Name = "txtbGracz2";
            this.txtbGracz2.Size = new System.Drawing.Size(100, 20);
            this.txtbGracz2.TabIndex = 7;
            this.txtbGracz2.Visible = false;
            // 
            // btnGracz2Graj
            // 
            this.btnGracz2Graj.Location = new System.Drawing.Point(512, 231);
            this.btnGracz2Graj.Name = "btnGracz2Graj";
            this.btnGracz2Graj.Size = new System.Drawing.Size(100, 23);
            this.btnGracz2Graj.TabIndex = 6;
            this.btnGracz2Graj.Text = "Wybierz";
            this.btnGracz2Graj.UseVisualStyleBackColor = true;
            this.btnGracz2Graj.Visible = false;
            // 
            // labelGracz2
            // 
            this.labelGracz2.AutoSize = true;
            this.labelGracz2.Location = new System.Drawing.Point(512, 192);
            this.labelGracz2.Name = "labelGracz2";
            this.labelGracz2.Size = new System.Drawing.Size(47, 13);
            this.labelGracz2.TabIndex = 5;
            this.labelGracz2.Text = "Gracz 2:";
            this.labelGracz2.Visible = false;
            // 
            // btnNowaGra
            // 
            this.btnNowaGra.Location = new System.Drawing.Point(12, 231);
            this.btnNowaGra.Name = "btnNowaGra";
            this.btnNowaGra.Size = new System.Drawing.Size(75, 23);
            this.btnNowaGra.TabIndex = 8;
            this.btnNowaGra.Text = "Nowa gra";
            this.btnNowaGra.UseVisualStyleBackColor = true;
            this.btnNowaGra.Click += new System.EventHandler(this.btnNowaGra_Click);
            // 
            // txtbMaxWartosc
            // 
            this.txtbMaxWartosc.Location = new System.Drawing.Point(149, 208);
            this.txtbMaxWartosc.Name = "txtbMaxWartosc";
            this.txtbMaxWartosc.Size = new System.Drawing.Size(100, 20);
            this.txtbMaxWartosc.TabIndex = 11;
            this.txtbMaxWartosc.Visible = false;
            // 
            // btnPrzeslijParametry
            // 
            this.btnPrzeslijParametry.Location = new System.Drawing.Point(149, 231);
            this.btnPrzeslijParametry.Name = "btnPrzeslijParametry";
            this.btnPrzeslijParametry.Size = new System.Drawing.Size(206, 23);
            this.btnPrzeslijParametry.TabIndex = 10;
            this.btnPrzeslijParametry.Text = "Prześlij parametry";
            this.btnPrzeslijParametry.UseVisualStyleBackColor = true;
            this.btnPrzeslijParametry.Visible = false;
            this.btnPrzeslijParametry.Click += new System.EventHandler(this.btnPrzeslijParametry_Click);
            // 
            // labelMaxWartosc
            // 
            this.labelMaxWartosc.AutoSize = true;
            this.labelMaxWartosc.Location = new System.Drawing.Point(149, 192);
            this.labelMaxWartosc.Name = "labelMaxWartosc";
            this.labelMaxWartosc.Size = new System.Drawing.Size(70, 13);
            this.labelMaxWartosc.TabIndex = 9;
            this.labelMaxWartosc.Text = "Max wartość:";
            this.labelMaxWartosc.Visible = false;
            // 
            // txtbIloscLiczb
            // 
            this.txtbIloscLiczb.Location = new System.Drawing.Point(255, 208);
            this.txtbIloscLiczb.Name = "txtbIloscLiczb";
            this.txtbIloscLiczb.Size = new System.Drawing.Size(100, 20);
            this.txtbIloscLiczb.TabIndex = 13;
            this.txtbIloscLiczb.Visible = false;
            // 
            // labelIloscLiczb
            // 
            this.labelIloscLiczb.AutoSize = true;
            this.labelIloscLiczb.Location = new System.Drawing.Point(255, 192);
            this.labelIloscLiczb.Name = "labelIloscLiczb";
            this.labelIloscLiczb.Size = new System.Drawing.Size(56, 13);
            this.labelIloscLiczb.TabIndex = 12;
            this.labelIloscLiczb.Text = "Ilość liczb:";
            this.labelIloscLiczb.Visible = false;
            // 
            // labelKomunikat
            // 
            this.labelKomunikat.AutoSize = true;
            this.labelKomunikat.Location = new System.Drawing.Point(17, 135);
            this.labelKomunikat.Name = "labelKomunikat";
            this.labelKomunikat.Size = new System.Drawing.Size(0, 13);
            this.labelKomunikat.TabIndex = 14;
            this.labelKomunikat.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 266);
            this.Controls.Add(this.labelKomunikat);
            this.Controls.Add(this.txtbIloscLiczb);
            this.Controls.Add(this.labelIloscLiczb);
            this.Controls.Add(this.txtbMaxWartosc);
            this.Controls.Add(this.btnPrzeslijParametry);
            this.Controls.Add(this.labelMaxWartosc);
            this.Controls.Add(this.btnNowaGra);
            this.Controls.Add(this.txtbGracz2);
            this.Controls.Add(this.btnGracz2Graj);
            this.Controls.Add(this.labelGracz2);
            this.Controls.Add(this.txtbGracz1);
            this.Controls.Add(this.btnGracz1Graj);
            this.Controls.Add(this.labelGracz1);
            this.Controls.Add(this.richtxtbPoleGry);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richtxtbPoleGry;
        private System.Windows.Forms.Label labelGracz1;
        private System.Windows.Forms.Button btnGracz1Graj;
        private System.Windows.Forms.TextBox txtbGracz1;
        private System.Windows.Forms.TextBox txtbGracz2;
        private System.Windows.Forms.Button btnGracz2Graj;
        private System.Windows.Forms.Label labelGracz2;
        private System.Windows.Forms.Button btnNowaGra;
        private System.Windows.Forms.TextBox txtbMaxWartosc;
        private System.Windows.Forms.Button btnPrzeslijParametry;
        private System.Windows.Forms.Label labelMaxWartosc;
        private System.Windows.Forms.TextBox txtbIloscLiczb;
        private System.Windows.Forms.Label labelIloscLiczb;
        private System.Windows.Forms.Label labelKomunikat;
    }
}

