namespace SuperAdventure
{
    partial class ProPRG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProPRG));
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.lblSelAct = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.btnWeap = new System.Windows.Forms.Button();
            this.btnPot = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblXP = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblLVL = new System.Windows.Forms.Label();
            this.lblHP2 = new System.Windows.Forms.Label();
            this.lblXP2 = new System.Windows.Forms.Label();
            this.lblGold2 = new System.Windows.Forms.Label();
            this.lblLVL2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbLocation
            // 
            resources.ApplyResources(this.rtbLocation, "rtbLocation");
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            // 
            // rtbMessages
            // 
            resources.ApplyResources(this.rtbMessages, "rtbMessages");
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            // 
            // lblSelAct
            // 
            resources.ApplyResources(this.lblSelAct, "lblSelAct");
            this.lblSelAct.Name = "lblSelAct";
            // 
            // cboWeapons
            // 
            this.cboWeapons.FormattingEnabled = true;
            resources.ApplyResources(this.cboWeapons, "cboWeapons");
            this.cboWeapons.Name = "cboWeapons";
            // 
            // cboPotions
            // 
            this.cboPotions.FormattingEnabled = true;
            resources.ApplyResources(this.cboPotions, "cboPotions");
            this.cboPotions.Name = "cboPotions";
            // 
            // btnWeap
            // 
            resources.ApplyResources(this.btnWeap, "btnWeap");
            this.btnWeap.Name = "btnWeap";
            this.btnWeap.UseVisualStyleBackColor = true;
            this.btnWeap.Click += new System.EventHandler(this.btnWeap_Click);
            // 
            // btnPot
            // 
            resources.ApplyResources(this.btnPot, "btnPot");
            this.btnPot.Name = "btnPot";
            this.btnPot.UseVisualStyleBackColor = true;
            this.btnPot.Click += new System.EventHandler(this.btnPot_Click);
            // 
            // btnNorth
            // 
            resources.ApplyResources(this.btnNorth, "btnNorth");
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            // 
            // btnEast
            // 
            resources.ApplyResources(this.btnEast, "btnEast");
            this.btnEast.Name = "btnEast";
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            // 
            // btnSouth
            // 
            resources.ApplyResources(this.btnSouth, "btnSouth");
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // btnWest
            // 
            resources.ApplyResources(this.btnWest, "btnWest");
            this.btnWest.Name = "btnWest";
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            resources.ApplyResources(this.dgvInventory, "dgvInventory");
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            resources.ApplyResources(this.dgvQuests, "dgvQuests");
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersVisible = false;
            // 
            // lblHP
            // 
            resources.ApplyResources(this.lblHP, "lblHP");
            this.lblHP.Name = "lblHP";
            // 
            // lblXP
            // 
            resources.ApplyResources(this.lblXP, "lblXP");
            this.lblXP.Name = "lblXP";
            // 
            // lblGold
            // 
            resources.ApplyResources(this.lblGold, "lblGold");
            this.lblGold.Name = "lblGold";
            // 
            // lblLVL
            // 
            resources.ApplyResources(this.lblLVL, "lblLVL");
            this.lblLVL.Name = "lblLVL";
            // 
            // lblHP2
            // 
            resources.ApplyResources(this.lblHP2, "lblHP2");
            this.lblHP2.Name = "lblHP2";
            // 
            // lblXP2
            // 
            resources.ApplyResources(this.lblXP2, "lblXP2");
            this.lblXP2.Name = "lblXP2";
            // 
            // lblGold2
            // 
            resources.ApplyResources(this.lblGold2, "lblGold2");
            this.lblGold2.Name = "lblGold2";
            // 
            // lblLVL2
            // 
            resources.ApplyResources(this.lblLVL2, "lblLVL2");
            this.lblLVL2.Name = "lblLVL2";
            // 
            // ProPRG
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLVL2);
            this.Controls.Add(this.lblGold2);
            this.Controls.Add(this.lblXP2);
            this.Controls.Add(this.lblHP2);
            this.Controls.Add(this.lblLVL);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblXP);
            this.Controls.Add(this.lblHP);
            this.Controls.Add(this.dgvQuests);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.btnPot);
            this.Controls.Add(this.btnWeap);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.lblSelAct);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.rtbLocation);
            this.Name = "ProPRG";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.Label lblSelAct;
        private System.Windows.Forms.ComboBox cboWeapons;
        private System.Windows.Forms.ComboBox cboPotions;
        private System.Windows.Forms.Button btnWeap;
        private System.Windows.Forms.Button btnPot;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridView dgvQuests;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.Label lblXP;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblLVL;
        private System.Windows.Forms.Label lblHP2;
        private System.Windows.Forms.Label lblXP2;
        private System.Windows.Forms.Label lblGold2;
        private System.Windows.Forms.Label lblLVL2;
    }
}

