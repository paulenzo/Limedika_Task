namespace WinFormsApp.View
{
    partial class MainView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.importClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePostCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importClientsToolStripMenuItem,
            this.updatePostCodesToolStripMenuItem,
            this.clientListToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // importClientsToolStripMenuItem
            // 
            this.importClientsToolStripMenuItem.Name = "importClientsToolStripMenuItem";
            this.importClientsToolStripMenuItem.Size = new System.Drawing.Size(150, 20);
            this.importClientsToolStripMenuItem.Text = "Importuoti klientus";
            this.importClientsToolStripMenuItem.Click += new System.EventHandler(this.importClientsToolStripMenuItem_Click);
            // 
            // updatePostCodesToolStripMenuItem
            // 
            this.updatePostCodesToolStripMenuItem.Name = "updatePostCodesToolStripMenuItem";
            this.updatePostCodesToolStripMenuItem.Size = new System.Drawing.Size(150, 20);
            this.updatePostCodesToolStripMenuItem.Text = "Atnaujinti pašto indeksus";
            this.updatePostCodesToolStripMenuItem.Click += new System.EventHandler(this.updatePostCodesToolStripMenuItem_Click);
            // 
            // clientListToolStripMenuItem
            // 
            this.clientListToolStripMenuItem.Name = "clientListToolStripMenuItem";
            this.clientListToolStripMenuItem.Size = new System.Drawing.Size(150, 20);
            this.clientListToolStripMenuItem.Text = "Klientų sąrašas";
            this.clientListToolStripMenuItem.Click += new System.EventHandler(this.clientListToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 200);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "Praktinė užduotis";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem importClientsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem updatePostCodesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem clientListToolStripMenuItem;
    private System.Windows.Forms.Label label1;
    }
}

