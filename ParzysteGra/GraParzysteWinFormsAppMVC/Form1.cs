using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelGraParzysteLib;

namespace GraParzysteWinFormsAppMVC
{
    public partial class Form1 : Form
    {
        private ModelGame gra;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNowaGra_Click(object sender, EventArgs e)
        {
            labelGracz1.Visible = true;
            labelGracz2.Visible = true;
            btnGracz1Graj.Visible = true;
            btnGracz2Graj.Visible = true;
            txtbGracz1.Visible = true;
            txtbGracz2.Visible = true;
            labelMaxWartosc.Visible = true;
            labelIloscLiczb.Visible = true;
            txtbIloscLiczb.Visible = true;
            txtbMaxWartosc.Visible = true;
            btnPrzeslijParametry.Visible = true;
            labelKomunikat.Visible = true;
            richtxtbPoleGry.Text = "Podaj parametry gry oraz imiona graczy i potwierdź przyciskiem.";
        }

        private void btnPrzeslijParametry_Click(object sender, EventArgs e)
        {
            gra = new ModelGame();

            int maxWartosc = 0;
            int iloscLiczb = 0;

            try
            {
                maxWartosc = Convert.ToInt32(txtbMaxWartosc.Text);
                iloscLiczb = Convert.ToInt32(txtbIloscLiczb.Text);
                gra.Gracz1.Name = txtbGracz1.Text;
                gra.Gracz2.Name = txtbGracz2.Text;
            }
            catch (FormatException)
            {
                labelKomunikat.Text = "Błędne parametry";
            }
            catch (OverflowException)
            {
                labelKomunikat.Text = "Za duża liczba";
            }

            richtxtbPoleGry.Clear();
            txtbGracz1.Clear();
            txtbGracz2.Clear();

            while (!(gra.CzyWybranoPoprawnaIloscLiczbDoWylosowania))
            {
                labelKomunikat.Text = "Podaj ilość liczb do wylosowania. Minimum 3 liczby.";
                gra.WybierzIloscLiczbDoWylosowania(iloscLiczb);
                labelKomunikat.Text = "----------------------------------------------------------------";
            }

            while (!(gra.CzyWybranoPoprawnaMaxWartoscDoWylosowania))
            {
                labelKomunikat.Text = "Podaj max wartość losowanej liczby. Minimum liczba 2.";
                gra.WybierzMaxWartoscLosowanejLiczby(maxWartosc);
                labelKomunikat.Text = "----------------------------------------------------------------";
            }

            gra.LosujCiag();



            StringBuilder sb = new StringBuilder();
            foreach (var item in gra.TabWylosowaneLiczbyAsReadOnly)
            {
                sb.Append(item + " ");
            }

            richtxtbPoleGry.Text = sb.ToString();
             
        }

        private void btnGracz1Graj_Click(object sender, EventArgs e)
        {

        }
    }
}
