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
    public partial class MediciForm : Form
    {
        public MediciForm()
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
        public TextBox StipendioTxtBox
        {
            get { return this.stipendioTxtBox; }
            set { this.stipendioTxtBox = value; }
        }
        public DateTimePicker DataNascitaPicker
        {
            get { return this.dataNascitaPicker; }
            set { this.dataNascitaPicker = value; }
        }

        public TextBox SpecializzazioneTxtBox
        {
            get { return this.specializzazioneTxtBox; }
            set { this.specializzazioneTxtBox = value; }
        }
        public TextBox MediciId
        {
            get { return this.mediciId; }
            set { this.mediciId = value; }
        }
        public Label MediciIdLbl
        {
            get { return this.mediciIdLbl; }
        }


    }
}
