namespace serverFile
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
            this.lbConnection = new System.Windows.Forms.ListBox();
            this.LBStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbConnection
            // 
            this.lbConnection.FormattingEnabled = true;
            this.lbConnection.ItemHeight = 20;
            this.lbConnection.Location = new System.Drawing.Point(75, 82);
            this.lbConnection.Name = "lbConnection";
            this.lbConnection.Size = new System.Drawing.Size(602, 124);
            this.lbConnection.TabIndex = 0;
            // 
            // LBStatus
            // 
            this.LBStatus.AutoSize = true;
            this.LBStatus.Location = new System.Drawing.Point(71, 27);
            this.LBStatus.Name = "LBStatus";
            this.LBStatus.Size = new System.Drawing.Size(56, 20);
            this.LBStatus.TabIndex = 1;
            this.LBStatus.Text = "Status";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(725, 301);
            this.Controls.Add(this.LBStatus);
            this.Controls.Add(this.lbConnection);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lbConnections;
        private System.Windows.Forms.ListBox lbConnection;
        private System.Windows.Forms.Label LBStatus;
    }
}

