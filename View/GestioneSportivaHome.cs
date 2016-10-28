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
    public partial class GestioneSportivaHome : Form
    {
        public GestioneSportivaHome()
        {

            InitializeComponent();

        }
        public TabPage DirigentiView
        {
            get { return this.dirigentiTab; }
            set { this.dirigentiTab = value; }
        }
        public TabPage SportiviView
        {
            get { return this.sportiviTab; }
            set { this.sportiviTab = value; }
        }
        public TabPage StampaView
        {
            get { return this.stampTab; }
            set { this.stampTab = value; }
        }
        public TabPage MediciView
        {
            get { return this.mediciTab; }
            set { this.mediciTab = value; }
        }

        public Button CreaDirigentiBtn
        {
            get { return this.creaDirigentiBtn; }
        }

        public Button ModificaDirigentibtn
        {
            get { return this.modificaDirigentiBtn; }
        }

        public Button EliminaDirigentiBtn
        {
            get { return this.eliminaDirigentiBtn; }
        }
        public Button CreaSportivitiBtn
        {
            get { return this.creaSportiviBtn; }
        }

        public Button ModificaSportivibtn
        {
            get { return this.modificaSportiviBtn; }
        }

        public Button EliminaSportiviBtn
        {
            get { return this.eliminaSportiviBtn; }
        }
        public Button CreaStampaBtn
        {
            get { return this.creaStampaBtn; }
        }

        public Button ModificaStampabtn
        {
            get { return this.modificaStampaBtn; }
        }

        public Button EliminaStampaBtn
        {
            get { return this.eliminaStampaBtn; }
        }
        public Button CreaMediciBtn
        {
            get { return this.creaMediciBtn; }
        }

        public Button ModificaMedicibtn
        {
            get { return this.modificaMediciBtn; }
        }

        public Button EliminaMediciBtn
        {
            get { return this.eliminaMediciBtn; }
        }

        public DataGridView DirigentiGridView
        {
            get { return this.dirigentiGridView; }
            set { this.dirigentiGridView = value; }
        }

        public DataGridView SportiviGridView
        {
            get { return this.sportiviGridView; }
            set { this.sportiviGridView = value; }
        }

        public DataGridView StampaGridView
        {
            get { return this.stampGridView; }
            set { this.stampGridView = value; }
        }

        public DataGridView MediciGridView
        {
            get { return this.mediciGridView; }
            set { this.mediciGridView = value; }
        }


    }


}
