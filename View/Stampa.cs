using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioneSocietaSportiva.View
{
    public partial class StampaForm : Form
    {
        public StampaForm()
        {
            InitializeComponent();
        }

        public Button AnnullaBtn
        {
            get { return this.annulaBtn; }
        }
        public Button SalvaBtn
        {
            get { return this.salvaBtn; }
        }

        public TextBox NomeTxtBox
        {
            get { return this.nomeTxtBox; }
            set { this.nomeTxtBox = value; }
        }
        public TextBox CognomeTxtBox
        {
            get { return this.cognomeTxtBox; }
            set { this.cognomeTxtBox = value; }
        }
        public TextBox EmailTxtBox
        {
            get { return this.emailTxtBox; }
            set { this.emailTxtBox = value; }
        }
        public TextBox NumeroDiCellulareTxtBox
        {
            get { return this.numTxtBox; }
            set { this.numTxtBox = value; }
        }
        public RadioButton MaleRadio
        {
            get { return this.maleRadio; }
            set { this.maleRadio = value; }
        }
        public RadioButton FemaleRadio
        {
            get { return this.femalRadio; }
            set { this.femalRadio = value; }
        }
        public TextBox QuotaTxtBox
        {
            get { return this.stipendioTxtBox; }
            set { this.stipendioTxtBox = value; }
        }
        public DateTimePicker DataNascitaPicker
        {
            get { return this.dataNascitaPicker; }
            set { this.dataNascitaPicker = value; }
        }
        public TextBox StipendioTxtBox
        {
            get { return this.stipendioTxtBox; }
            set { this.stipendioTxtBox = value; }
        }

        public Label StampaIdLbl
        {
            get { return this.stampaIdLbl; }
        }
        public TextBox StampaId
        {
            get { return this.stampaId; }
            set { this.stampaId = value; }
        }
    }
}
