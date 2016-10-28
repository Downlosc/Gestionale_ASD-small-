namespace GestioneSocietaSportiva.View
{
    partial class GestioneSportivaHome
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
            this.mainTab = new System.Windows.Forms.TabControl();
            this.dirigentiTab = new System.Windows.Forms.TabPage();
            this.dirigentiGridView = new System.Windows.Forms.DataGridView();
            this.eliminaDirigentiBtn = new System.Windows.Forms.Button();
            this.modificaDirigentiBtn = new System.Windows.Forms.Button();
            this.creaDirigentiBtn = new System.Windows.Forms.Button();
            this.sportiviTab = new System.Windows.Forms.TabPage();
            this.sportiviGridView = new System.Windows.Forms.DataGridView();
            this.eliminaSportiviBtn = new System.Windows.Forms.Button();
            this.modificaSportiviBtn = new System.Windows.Forms.Button();
            this.creaSportiviBtn = new System.Windows.Forms.Button();
            this.stampTab = new System.Windows.Forms.TabPage();
            this.stampGridView = new System.Windows.Forms.DataGridView();
            this.eliminaStampaBtn = new System.Windows.Forms.Button();
            this.modificaStampaBtn = new System.Windows.Forms.Button();
            this.creaStampaBtn = new System.Windows.Forms.Button();
            this.mediciTab = new System.Windows.Forms.TabPage();
            this.mediciGridView = new System.Windows.Forms.DataGridView();
            this.eliminaMediciBtn = new System.Windows.Forms.Button();
            this.modificaMediciBtn = new System.Windows.Forms.Button();
            this.creaMediciBtn = new System.Windows.Forms.Button();
            this.mainTab.SuspendLayout();
            this.dirigentiTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dirigentiGridView)).BeginInit();
            this.sportiviTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sportiviGridView)).BeginInit();
            this.stampTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stampGridView)).BeginInit();
            this.mediciTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediciGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.dirigentiTab);
            this.mainTab.Controls.Add(this.sportiviTab);
            this.mainTab.Controls.Add(this.stampTab);
            this.mainTab.Controls.Add(this.mediciTab);
            this.mainTab.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.mainTab.Location = new System.Drawing.Point(12, 12);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.ShowToolTips = true;
            this.mainTab.Size = new System.Drawing.Size(642, 289);
            this.mainTab.TabIndex = 0;
            // 
            // dirigentiTab
            // 
            this.dirigentiTab.Controls.Add(this.dirigentiGridView);
            this.dirigentiTab.Controls.Add(this.eliminaDirigentiBtn);
            this.dirigentiTab.Controls.Add(this.modificaDirigentiBtn);
            this.dirigentiTab.Controls.Add(this.creaDirigentiBtn);
            this.dirigentiTab.Location = new System.Drawing.Point(4, 22);
            this.dirigentiTab.Name = "dirigentiTab";
            this.dirigentiTab.Padding = new System.Windows.Forms.Padding(3);
            this.dirigentiTab.Size = new System.Drawing.Size(634, 263);
            this.dirigentiTab.TabIndex = 0;
            this.dirigentiTab.Text = "Dirigenti";
            this.dirigentiTab.UseVisualStyleBackColor = true;
            // 
            // dirigentiGridView
            // 
            this.dirigentiGridView.AllowUserToAddRows = false;
            this.dirigentiGridView.AllowUserToDeleteRows = false;
            this.dirigentiGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dirigentiGridView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dirigentiGridView.Location = new System.Drawing.Point(6, 6);
            this.dirigentiGridView.Name = "dirigentiGridView";
            this.dirigentiGridView.ReadOnly = true;
            this.dirigentiGridView.Size = new System.Drawing.Size(507, 243);
            this.dirigentiGridView.TabIndex = 4;
            // 
            // eliminaDirigentiBtn
            // 
            this.eliminaDirigentiBtn.Location = new System.Drawing.Point(539, 125);
            this.eliminaDirigentiBtn.Name = "eliminaDirigentiBtn";
            this.eliminaDirigentiBtn.Size = new System.Drawing.Size(75, 23);
            this.eliminaDirigentiBtn.TabIndex = 2;
            this.eliminaDirigentiBtn.Text = "ELIMINA";
            this.eliminaDirigentiBtn.UseVisualStyleBackColor = true;
            // 
            // modificaDirigentiBtn
            // 
            this.modificaDirigentiBtn.Location = new System.Drawing.Point(539, 78);
            this.modificaDirigentiBtn.Name = "modificaDirigentiBtn";
            this.modificaDirigentiBtn.Size = new System.Drawing.Size(75, 23);
            this.modificaDirigentiBtn.TabIndex = 1;
            this.modificaDirigentiBtn.Text = "MODIFICA";
            this.modificaDirigentiBtn.UseVisualStyleBackColor = true;
            // 
            // creaDirigentiBtn
            // 
            this.creaDirigentiBtn.Location = new System.Drawing.Point(539, 31);
            this.creaDirigentiBtn.Name = "creaDirigentiBtn";
            this.creaDirigentiBtn.Size = new System.Drawing.Size(75, 23);
            this.creaDirigentiBtn.TabIndex = 0;
            this.creaDirigentiBtn.Text = "CREA";
            this.creaDirigentiBtn.UseVisualStyleBackColor = true;
            // 
            // sportiviTab
            // 
            this.sportiviTab.Controls.Add(this.sportiviGridView);
            this.sportiviTab.Controls.Add(this.eliminaSportiviBtn);
            this.sportiviTab.Controls.Add(this.modificaSportiviBtn);
            this.sportiviTab.Controls.Add(this.creaSportiviBtn);
            this.sportiviTab.Location = new System.Drawing.Point(4, 22);
            this.sportiviTab.Name = "sportiviTab";
            this.sportiviTab.Padding = new System.Windows.Forms.Padding(3);
            this.sportiviTab.Size = new System.Drawing.Size(634, 263);
            this.sportiviTab.TabIndex = 1;
            this.sportiviTab.Text = "Sportivi";
            this.sportiviTab.UseVisualStyleBackColor = true;
            // 
            // sportiviGridView
            // 
            this.sportiviGridView.AllowUserToAddRows = false;
            this.sportiviGridView.AllowUserToDeleteRows = false;
            this.sportiviGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sportiviGridView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.sportiviGridView.Location = new System.Drawing.Point(6, 6);
            this.sportiviGridView.Name = "sportiviGridView";
            this.sportiviGridView.ReadOnly = true;
            this.sportiviGridView.Size = new System.Drawing.Size(507, 243);
            this.sportiviGridView.TabIndex = 9;
            // 
            // eliminaSportiviBtn
            // 
            this.eliminaSportiviBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.eliminaSportiviBtn.Location = new System.Drawing.Point(546, 129);
            this.eliminaSportiviBtn.Name = "eliminaSportiviBtn";
            this.eliminaSportiviBtn.Size = new System.Drawing.Size(75, 23);
            this.eliminaSportiviBtn.TabIndex = 7;
            this.eliminaSportiviBtn.Text = "ELIMINA";
            this.eliminaSportiviBtn.UseVisualStyleBackColor = true;
            // 
            // modificaSportiviBtn
            // 
            this.modificaSportiviBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.modificaSportiviBtn.Location = new System.Drawing.Point(546, 82);
            this.modificaSportiviBtn.Name = "modificaSportiviBtn";
            this.modificaSportiviBtn.Size = new System.Drawing.Size(75, 23);
            this.modificaSportiviBtn.TabIndex = 6;
            this.modificaSportiviBtn.Text = "MODIFICA";
            this.modificaSportiviBtn.UseVisualStyleBackColor = true;
            // 
            // creaSportiviBtn
            // 
            this.creaSportiviBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.creaSportiviBtn.Location = new System.Drawing.Point(546, 35);
            this.creaSportiviBtn.Name = "creaSportiviBtn";
            this.creaSportiviBtn.Size = new System.Drawing.Size(75, 23);
            this.creaSportiviBtn.TabIndex = 5;
            this.creaSportiviBtn.Text = "CREA";
            this.creaSportiviBtn.UseVisualStyleBackColor = true;
            // 
            // stampTab
            // 
            this.stampTab.Controls.Add(this.stampGridView);
            this.stampTab.Controls.Add(this.eliminaStampaBtn);
            this.stampTab.Controls.Add(this.modificaStampaBtn);
            this.stampTab.Controls.Add(this.creaStampaBtn);
            this.stampTab.Location = new System.Drawing.Point(4, 22);
            this.stampTab.Name = "stampTab";
            this.stampTab.Padding = new System.Windows.Forms.Padding(3);
            this.stampTab.Size = new System.Drawing.Size(634, 263);
            this.stampTab.TabIndex = 2;
            this.stampTab.Text = "Stampa";
            this.stampTab.UseVisualStyleBackColor = true;
            // 
            // stampGridView
            // 
            this.stampGridView.AllowUserToAddRows = false;
            this.stampGridView.AllowUserToDeleteRows = false;
            this.stampGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stampGridView.Location = new System.Drawing.Point(13, 10);
            this.stampGridView.Name = "stampGridView";
            this.stampGridView.ReadOnly = true;
            this.stampGridView.Size = new System.Drawing.Size(507, 243);
            this.stampGridView.TabIndex = 9;
            // 
            // eliminaStampaBtn
            // 
            this.eliminaStampaBtn.Location = new System.Drawing.Point(546, 129);
            this.eliminaStampaBtn.Name = "eliminaStampaBtn";
            this.eliminaStampaBtn.Size = new System.Drawing.Size(75, 23);
            this.eliminaStampaBtn.TabIndex = 7;
            this.eliminaStampaBtn.Text = "ELIMINA";
            this.eliminaStampaBtn.UseVisualStyleBackColor = true;
            // 
            // modificaStampaBtn
            // 
            this.modificaStampaBtn.Location = new System.Drawing.Point(546, 82);
            this.modificaStampaBtn.Name = "modificaStampaBtn";
            this.modificaStampaBtn.Size = new System.Drawing.Size(75, 23);
            this.modificaStampaBtn.TabIndex = 6;
            this.modificaStampaBtn.Text = "MODIFICA";
            this.modificaStampaBtn.UseVisualStyleBackColor = true;
            // 
            // creaStampaBtn
            // 
            this.creaStampaBtn.Location = new System.Drawing.Point(546, 35);
            this.creaStampaBtn.Name = "creaStampaBtn";
            this.creaStampaBtn.Size = new System.Drawing.Size(75, 23);
            this.creaStampaBtn.TabIndex = 5;
            this.creaStampaBtn.Text = "CREA";
            this.creaStampaBtn.UseVisualStyleBackColor = true;
            // 
            // mediciTab
            // 
            this.mediciTab.Controls.Add(this.mediciGridView);
            this.mediciTab.Controls.Add(this.eliminaMediciBtn);
            this.mediciTab.Controls.Add(this.modificaMediciBtn);
            this.mediciTab.Controls.Add(this.creaMediciBtn);
            this.mediciTab.Location = new System.Drawing.Point(4, 22);
            this.mediciTab.Name = "mediciTab";
            this.mediciTab.Padding = new System.Windows.Forms.Padding(3);
            this.mediciTab.Size = new System.Drawing.Size(634, 263);
            this.mediciTab.TabIndex = 3;
            this.mediciTab.Text = "Staff Medico";
            this.mediciTab.UseVisualStyleBackColor = true;
            // 
            // mediciGridView
            // 
            this.mediciGridView.AllowUserToAddRows = false;
            this.mediciGridView.AllowUserToDeleteRows = false;
            this.mediciGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mediciGridView.Location = new System.Drawing.Point(13, 10);
            this.mediciGridView.Name = "mediciGridView";
            this.mediciGridView.ReadOnly = true;
            this.mediciGridView.Size = new System.Drawing.Size(507, 243);
            this.mediciGridView.TabIndex = 9;
            // 
            // eliminaMediciBtn
            // 
            this.eliminaMediciBtn.Location = new System.Drawing.Point(546, 129);
            this.eliminaMediciBtn.Name = "eliminaMediciBtn";
            this.eliminaMediciBtn.Size = new System.Drawing.Size(75, 23);
            this.eliminaMediciBtn.TabIndex = 7;
            this.eliminaMediciBtn.Text = "ELIMINA";
            this.eliminaMediciBtn.UseVisualStyleBackColor = true;
            // 
            // modificaMediciBtn
            // 
            this.modificaMediciBtn.Location = new System.Drawing.Point(546, 82);
            this.modificaMediciBtn.Name = "modificaMediciBtn";
            this.modificaMediciBtn.Size = new System.Drawing.Size(75, 23);
            this.modificaMediciBtn.TabIndex = 6;
            this.modificaMediciBtn.Text = "MODIFICA";
            this.modificaMediciBtn.UseVisualStyleBackColor = true;
            // 
            // creaMediciBtn
            // 
            this.creaMediciBtn.Location = new System.Drawing.Point(546, 35);
            this.creaMediciBtn.Name = "creaMediciBtn";
            this.creaMediciBtn.Size = new System.Drawing.Size(75, 23);
            this.creaMediciBtn.TabIndex = 5;
            this.creaMediciBtn.Text = "CREA";
            this.creaMediciBtn.UseVisualStyleBackColor = true;
            // 
            // GestioneSportivaHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 313);
            this.Controls.Add(this.mainTab);
            this.Name = "GestioneSportivaHome";
            this.Text = "GestioneSportivaHome";
            this.mainTab.ResumeLayout(false);
            this.dirigentiTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dirigentiGridView)).EndInit();
            this.sportiviTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sportiviGridView)).EndInit();
            this.stampTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stampGridView)).EndInit();
            this.mediciTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mediciGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage sportiviTab;
        private System.Windows.Forms.TabPage stampTab;
        private System.Windows.Forms.TabPage dirigentiTab;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage mediciTab;
        private System.Windows.Forms.Button eliminaDirigentiBtn;
        private System.Windows.Forms.Button modificaDirigentiBtn;
        private System.Windows.Forms.Button creaDirigentiBtn;
        private System.Windows.Forms.DataGridView dirigentiGridView;
        private System.Windows.Forms.DataGridView sportiviGridView;
        private System.Windows.Forms.Button eliminaSportiviBtn;
        private System.Windows.Forms.Button modificaSportiviBtn;
        private System.Windows.Forms.Button creaSportiviBtn;
        private System.Windows.Forms.DataGridView stampGridView;
        private System.Windows.Forms.Button eliminaStampaBtn;
        private System.Windows.Forms.Button modificaStampaBtn;
        private System.Windows.Forms.Button creaStampaBtn;
        private System.Windows.Forms.DataGridView mediciGridView;
        private System.Windows.Forms.Button eliminaMediciBtn;
        private System.Windows.Forms.Button modificaMediciBtn;
        private System.Windows.Forms.Button creaMediciBtn;
    }
}