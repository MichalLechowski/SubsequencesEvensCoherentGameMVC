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
            this.btnWybierzWartosci = new System.Windows.Forms.Button();
            this.txtbPodajWartosci = new System.Windows.Forms.TextBox();
            this.btnNowaGra = new System.Windows.Forms.Button();
            this.txtbMaxWartosc = new System.Windows.Forms.TextBox();
            this.btnPrzeslijParametry = new System.Windows.Forms.Button();
            this.labelMaxWartosc = new System.Windows.Forms.Label();
            this.txtbIloscLiczb = new System.Windows.Forms.TextBox();
            this.labelIloscLiczb = new System.Windows.Forms.Label();
            this.labelKomunikat = new System.Windows.Forms.Label();
            this.lblPodajWartosci = new System.Windows.Forms.Label();
            this.txtbNickGracz2 = new System.Windows.Forms.TextBox();
            this.lblNickGracz2 = new System.Windows.Forms.Label();
            this.txtbNickGracz1 = new System.Windows.Forms.TextBox();
            this.lblNickGracz1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richtxtbPoleGry
            // 
            this.richtxtbPoleGry.HideSelection = false;
            this.richtxtbPoleGry.Location = new System.Drawing.Point(12, 12);
            this.richtxtbPoleGry.Name = "richtxtbPoleGry";
            this.richtxtbPoleGry.Size = new System.Drawing.Size(776, 120);
            this.richtxtbPoleGry.TabIndex = 0;
            this.richtxtbPoleGry.Text = "";
            // 
            // btnWybierzWartosci
            // 
            this.btnWybierzWartosci.Location = new System.Drawing.Point(401, 231);
            this.btnWybierzWartosci.Name = "btnWybierzWartosci";
            this.btnWybierzWartosci.Size = new System.Drawing.Size(100, 23);
            this.btnWybierzWartosci.TabIndex = 3;
            this.btnWybierzWartosci.Text = "Wybierz";
            this.btnWybierzWartosci.UseVisualStyleBackColor = true;
            this.btnWybierzWartosci.Visible = false;
            this.btnWybierzWartosci.Click += new System.EventHandler(this.btnWybierzWartosci_Click);
            // 
            // txtbPodajWartosci
            // 
            this.txtbPodajWartosci.Location = new System.Drawing.Point(401, 208);
            this.txtbPodajWartosci.Name = "txtbPodajWartosci";
            this.txtbPodajWartosci.Size = new System.Drawing.Size(100, 20);
            this.txtbPodajWartosci.TabIndex = 4;
            this.txtbPodajWartosci.Visible = false;
            this.txtbPodajWartosci.TextChanged += new System.EventHandler(this.txtbPodajWartosci_TextChanged);
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
            this.txtbMaxWartosc.TextChanged += new System.EventHandler(this.txtbMaxWartosc_TextChanged);
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
            this.txtbIloscLiczb.TextChanged += new System.EventHandler(this.txtbIloscLiczb_TextChanged);
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
            // lblPodajWartosci
            // 
            this.lblPodajWartosci.AutoSize = true;
            this.lblPodajWartosci.Location = new System.Drawing.Point(401, 192);
            this.lblPodajWartosci.Name = "lblPodajWartosci";
            this.lblPodajWartosci.Size = new System.Drawing.Size(79, 13);
            this.lblPodajWartosci.TabIndex = 1;
            this.lblPodajWartosci.Text = "Podaj wartości:";
            this.lblPodajWartosci.Visible = false;
            // 
            // txtbNickGracz2
            // 
            this.txtbNickGracz2.Location = new System.Drawing.Point(255, 167);
            this.txtbNickGracz2.Name = "txtbNickGracz2";
            this.txtbNickGracz2.Size = new System.Drawing.Size(100, 20);
            this.txtbNickGracz2.TabIndex = 18;
            this.txtbNickGracz2.Text = "Gracz2";
            this.txtbNickGracz2.Visible = false;
            // 
            // lblNickGracz2
            // 
            this.lblNickGracz2.AutoSize = true;
            this.lblNickGracz2.Location = new System.Drawing.Point(255, 151);
            this.lblNickGracz2.Name = "lblNickGracz2";
            this.lblNickGracz2.Size = new System.Drawing.Size(70, 13);
            this.lblNickGracz2.TabIndex = 17;
            this.lblNickGracz2.Text = "Nick gracz 2:";
            this.lblNickGracz2.Visible = false;
            // 
            // txtbNickGracz1
            // 
            this.txtbNickGracz1.Location = new System.Drawing.Point(149, 167);
            this.txtbNickGracz1.Name = "txtbNickGracz1";
            this.txtbNickGracz1.Size = new System.Drawing.Size(100, 20);
            this.txtbNickGracz1.TabIndex = 16;
            this.txtbNickGracz1.Text = "Gracz1";
            this.txtbNickGracz1.Visible = false;
            // 
            // lblNickGracz1
            // 
            this.lblNickGracz1.AutoSize = true;
            this.lblNickGracz1.Location = new System.Drawing.Point(149, 151);
            this.lblNickGracz1.Name = "lblNickGracz1";
            this.lblNickGracz1.Size = new System.Drawing.Size(70, 13);
            this.lblNickGracz1.TabIndex = 15;
            this.lblNickGracz1.Text = "Nick gracz 1:";
            this.lblNickGracz1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 266);
            this.Controls.Add(this.txtbNickGracz2);
            this.Controls.Add(this.lblNickGracz2);
            this.Controls.Add(this.txtbNickGracz1);
            this.Controls.Add(this.lblNickGracz1);
            this.Controls.Add(this.labelKomunikat);
            this.Controls.Add(this.txtbIloscLiczb);
            this.Controls.Add(this.labelIloscLiczb);
            this.Controls.Add(this.txtbMaxWartosc);
            this.Controls.Add(this.btnPrzeslijParametry);
            this.Controls.Add(this.labelMaxWartosc);
            this.Controls.Add(this.btnNowaGra);
            this.Controls.Add(this.txtbPodajWartosci);
            this.Controls.Add(this.btnWybierzWartosci);
            this.Controls.Add(this.lblPodajWartosci);
            this.Controls.Add(this.richtxtbPoleGry);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richtxtbPoleGry;
        private System.Windows.Forms.Button btnWybierzWartosci;
        private System.Windows.Forms.TextBox txtbPodajWartosci;
        private System.Windows.Forms.Button btnNowaGra;
        private System.Windows.Forms.TextBox txtbMaxWartosc;
        private System.Windows.Forms.Button btnPrzeslijParametry;
        private System.Windows.Forms.Label labelMaxWartosc;
        private System.Windows.Forms.TextBox txtbIloscLiczb;
        private System.Windows.Forms.Label labelIloscLiczb;
        private System.Windows.Forms.Label labelKomunikat;
        private System.Windows.Forms.Label lblPodajWartosci;
        private System.Windows.Forms.TextBox txtbNickGracz2;
        private System.Windows.Forms.Label lblNickGracz2;
        private System.Windows.Forms.TextBox txtbNickGracz1;
        private System.Windows.Forms.Label lblNickGracz1;
    }
}

