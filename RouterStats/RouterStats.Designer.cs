namespace RouterStats
{
    partial class RouterStats
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouterStats));
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.reinit = new System.Windows.Forms.Button();
            this.quit = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.ColumnCount = 3;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.panel.Location = new System.Drawing.Point(12, 44);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel.Name = "panel";
            this.panel.RowCount = 1;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.Size = new System.Drawing.Size(392, 274);
            this.panel.TabIndex = 0;
            // 
            // reinit
            // 
            this.reinit.Location = new System.Drawing.Point(12, 324);
            this.reinit.Name = "reinit";
            this.reinit.Size = new System.Drawing.Size(176, 23);
            this.reinit.TabIndex = 1;
            this.reinit.Text = "Reinitialiser les statistiques";
            this.reinit.UseVisualStyleBackColor = true;
            this.reinit.Click += new System.EventHandler(this.reinit_Click);
            // 
            // quit
            // 
            this.quit.Location = new System.Drawing.Point(229, 324);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(175, 23);
            this.quit.TabIndex = 2;
            this.quit.Text = "Quitter";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // header
            // 
            this.header.ColumnCount = 3;
            this.header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.header.Location = new System.Drawing.Point(13, 13);
            this.header.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.header.Name = "header";
            this.header.RowCount = 1;
            this.header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.header.Size = new System.Drawing.Size(391, 25);
            this.header.TabIndex = 3;
            // 
            // RouterStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 359);
            this.Controls.Add(this.header);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.reinit);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RouterStats";
            this.Text = "RouterStats TP-Link Maigret";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panel;
        private System.Windows.Forms.Button reinit;
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.TableLayoutPanel header;


    }
}

