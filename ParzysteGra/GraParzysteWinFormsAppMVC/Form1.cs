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
        bool CzyPierwszyGracz = true;
        private ErrorProvider chosenValuesErrorProvider;
        private ErrorProvider maxValueInSequenceErrorProvider;
        private ErrorProvider amountOfValuesInSequenceErrorProvider;

        public Form1()
        {
            InitializeComponent();

            chosenValuesErrorProvider = new ErrorProvider();
            chosenValuesErrorProvider.SetIconAlignment(txtbPodajWartosci, ErrorIconAlignment.MiddleRight);
            chosenValuesErrorProvider.SetIconPadding(txtbPodajWartosci, 2);
            chosenValuesErrorProvider.BlinkRate = 500;
            chosenValuesErrorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            txtbPodajWartosci.TextChanged += new EventHandler(txtbPodajWartosci_TextChanged);

            maxValueInSequenceErrorProvider = new ErrorProvider();
            maxValueInSequenceErrorProvider.SetIconAlignment(txtbMaxWartosc, ErrorIconAlignment.MiddleLeft);
            maxValueInSequenceErrorProvider.SetIconPadding(txtbMaxWartosc, 2);
            maxValueInSequenceErrorProvider.BlinkRate = 500;
            maxValueInSequenceErrorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            txtbMaxWartosc.TextChanged += new EventHandler(txtbMaxWartosc_TextChanged);

            amountOfValuesInSequenceErrorProvider = new ErrorProvider();
            amountOfValuesInSequenceErrorProvider.SetIconAlignment(txtbIloscLiczb, ErrorIconAlignment.MiddleRight);
            amountOfValuesInSequenceErrorProvider.SetIconPadding(txtbIloscLiczb, 2);
            amountOfValuesInSequenceErrorProvider.BlinkRate = 500;
            amountOfValuesInSequenceErrorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            txtbIloscLiczb.TextChanged += new EventHandler(txtbIloscLiczb_TextChanged);
        }

        private void btnNowaGra_Click(object sender, EventArgs e)
        {
            lblPodajWartosci.Visible = false;
            txtbPodajWartosci.Visible = false;
            btnWybierzWartosci.Visible = false;

            lblNickGracz2.Visible = true;
            txtbNickGracz2.Visible = true;

            lblNickGracz1.Visible = true;
            txtbNickGracz1.Visible = true;

            labelMaxWartosc.Visible = true;
            labelIloscLiczb.Visible = true;
            txtbIloscLiczb.Visible = true;
            txtbMaxWartosc.Visible = true;

            labelKomunikat.Visible = true;

            btnPrzeslijParametry.Visible = true;
            btnPrzeslijParametry.Enabled = false;

            richtxtbPoleGry.Text = "Podaj parametry gry oraz imiona graczy i potwierdź przyciskiem.";
            labelKomunikat.Text = "";

            txtbMaxWartosc.Text = "";
            txtbIloscLiczb.Text = "";
        }

        private void btnPrzeslijParametry_Click(object sender, EventArgs e)
        {
            gra = new ModelGame();

            gra.MaxWartosc = Convert.ToInt32(txtbMaxWartosc.Text);
            gra.IloscLiczb = Convert.ToInt32(txtbIloscLiczb.Text);

            gra.Gracz1.Name = txtbNickGracz1.Text;
            gra.Gracz2.Name = txtbNickGracz2.Text;

            richtxtbPoleGry.Clear();
            gra.LosujCiag();

            StringBuilder sb = new StringBuilder();
            sb.Append("Wylosowany ciąg: ");
            foreach (var item in gra.TabWylosowaneLiczbyAsReadOnly)
            {
                sb.Append(item + " | ");
            }
            richtxtbPoleGry.Text = sb.ToString();
            labelKomunikat.Text = $"{gra.Gracz1.Name}: Wybierz podciąg spójny, parzysty. Liczby oddziel spacją.";

            lblPodajWartosci.Visible = true;
            txtbPodajWartosci.Visible = true;
            btnWybierzWartosci.Visible = true;
            btnWybierzWartosci.Enabled = false;

            lblNickGracz1.Visible = false;
            lblNickGracz2.Visible = false;
            txtbNickGracz1.Visible = false;
            txtbNickGracz2.Visible = false;

            labelMaxWartosc.Visible = false;
            txtbMaxWartosc.Visible = false;
            labelIloscLiczb.Visible = false;
            txtbIloscLiczb.Visible = false;

            btnPrzeslijParametry.Visible = false;
        }

        private void btnWybierzWartosci_Click(object sender, EventArgs e)
        {
            if (CzyPierwszyGracz)
            {
                CzyPierwszyGracz = false;
                Rozgrywka(gra.Gracz1);
                labelKomunikat.Text = $"{gra.Gracz2.Name}: Wybierz podciąg spójny, parzysty. Liczby oddziel spacją.";

            }
            else
            {
                CzyPierwszyGracz = true;
                Rozgrywka(gra.Gracz2);
                labelKomunikat.Text = $"{gra.Gracz1.Name}: Wybierz podciąg spójny, parzysty. Liczby oddziel spacją.";
            }
            txtbPodajWartosci.Clear();
        }

        private void SprawdzPoprawnoscLiczbICzyMoznaGracDalej(ModelPlayer gracz)
        {
            string liczby = txtbPodajWartosci.Text;

            gracz.WybierzLiczby(liczby);

            richtxtbPoleGry.AppendText("\n----------------------------------------------------------------");
            richtxtbPoleGry.AppendText("\nWybrano liczby: " + liczby);
            richtxtbPoleGry.AppendText("\n----------------------------------------------------------------");

            if (!(gra.SprawdzCzyWybranoPoprawneLiczby(gracz)))
            {
                gra.Wygrany = "\nPrzegrałeś! Wybrany podciąg nie spełnia warunków: parzystości, spójności lub nie istnieje.";
                richtxtbPoleGry.Text = ("\nKONIEC GRY: " + gra.Wygrany.ToUpper());
                labelKomunikat.Text = "";
                return;
            }

            gra.WyrzucWybraneLiczby(gracz);

            richtxtbPoleGry.AppendText("\nAktualna postać ciągu: ");
            richtxtbPoleGry.AppendText("\n");
            StringBuilder sb = new StringBuilder();
            foreach (var item in gra.TabWylosowaneLiczbyAsReadOnly)
            {
                richtxtbPoleGry.AppendText(item + " | ");
            }
            richtxtbPoleGry.AppendText("\n----------------------------------------------------------------");

            if (!(gra.SprawdzCzyMoznaKontynuowac(gracz)))
            {
                gra.Wygrany = gracz.Name;
            }
        }

        private void Rozgrywka(ModelPlayer gracz)
        {
            if (gra.CzySaJeszczeRuchy && gra.CzyWybranoPoprawneLiczbyDoWyrzucenia)
            {
                SprawdzPoprawnoscLiczbICzyMoznaGracDalej(gracz);
            }
            if (gra.CzySaJeszczeRuchy == false)
            {
                richtxtbPoleGry.Text = ("KONIEC GRY, WYGRYWA: " + gra.Wygrany.ToUpper());
                btnWybierzWartosci.Enabled = false;
                labelKomunikat.Text = "";

                lblPodajWartosci.Visible = false;
                txtbPodajWartosci.Visible = false;
                btnWybierzWartosci.Visible = false;
                labelKomunikat.Visible = false;
            }
        }

        #region DataValidationHandlers
        private bool ValuesValid()
        {
            string liczby;

            liczby = txtbPodajWartosci.Text;
            if (int.TryParse(liczby.Replace(" ", string.Empty), out int result1) && txtbPodajWartosci.Text.Length > 0) //jeśli po usunięciu przerw w stringu, da się sparsować na inta to znaczy, że wpisano same liczby. Clever :D
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void txtbPodajWartosci_TextChanged(object sender, EventArgs e)
        {
            if (ValuesValid())
            {
                chosenValuesErrorProvider.SetError(txtbPodajWartosci, string.Empty);
                btnWybierzWartosci.Enabled = true;
            }
            else
            {
                chosenValuesErrorProvider.SetError(txtbPodajWartosci, "Nieprawidłowy format danych. Wpisz tylko liczby całkowite oddzielone spacją.");
                btnWybierzWartosci.Enabled = false;
            }
        }

        private bool MaxChosenValueInSequenceValid()
        {
            string liczby;

            liczby = txtbMaxWartosc.Text;
            if (int.TryParse(liczby.Replace(" ", string.Empty), out int result) && txtbMaxWartosc.Text.Length > 0 && result <= 100 && result >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void txtbMaxWartosc_TextChanged(object sender, EventArgs e)
        {
            if (MaxChosenValueInSequenceValid())
            {
                maxValueInSequenceErrorProvider.SetError(txtbMaxWartosc, string.Empty);
                btnPrzeslijParametry.Enabled = true;
            }
            else
            {
                maxValueInSequenceErrorProvider.SetError(txtbMaxWartosc, "Nieprawidłowy format danych. Tylko liczba całkowita z zakresu <2,100>");
                btnPrzeslijParametry.Enabled = false;
            }
        }

        private bool AmountOfValuesInSequenceValid()
        {
            string liczby;
            liczby = txtbIloscLiczb.Text;

            if (int.TryParse(liczby.Replace(" ", string.Empty), out int result) && txtbIloscLiczb.Text.Length > 0 && result <= 100 && result >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void txtbIloscLiczb_TextChanged(object sender, EventArgs e)
        {
            if (AmountOfValuesInSequenceValid())
            {
                amountOfValuesInSequenceErrorProvider.SetError(txtbIloscLiczb, string.Empty);
                btnPrzeslijParametry.Enabled = true;
            }
            else
            {
                amountOfValuesInSequenceErrorProvider.SetError(txtbIloscLiczb, "Nieprawidłowy format danych.Tylko liczba całkowita z zakresu <3,100>");
                btnPrzeslijParametry.Enabled = false;
            }
        }
        #endregion
    }
}