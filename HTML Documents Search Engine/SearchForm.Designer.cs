namespace HTML_Documents_Search_Engine
{
    partial class SearchForm
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.m_KeyWordLabel = new MetroFramework.Controls.MetroLabel();
            this.m_KeyWorkTextBox = new MetroFramework.Controls.MetroTextBox();
            this.m_SearchButton = new MetroFramework.Controls.MetroButton();
            this.m_ResultTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.tableLayoutPanel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(22, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1035, 450);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_ResultTextBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1035, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.m_KeyWordLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_KeyWorkTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_SearchButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1029, 52);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // m_KeyWordLabel
            // 
            this.m_KeyWordLabel.AutoSize = true;
            this.m_KeyWordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_KeyWordLabel.Location = new System.Drawing.Point(3, 0);
            this.m_KeyWordLabel.Name = "m_KeyWordLabel";
            this.m_KeyWordLabel.Size = new System.Drawing.Size(199, 52);
            this.m_KeyWordLabel.TabIndex = 0;
            this.m_KeyWordLabel.Text = "Enter Search Keyword";
            this.m_KeyWordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_KeyWorkTextBox
            // 
            // 
            // 
            // 
            this.m_KeyWorkTextBox.CustomButton.Image = null;
            this.m_KeyWorkTextBox.CustomButton.Location = new System.Drawing.Point(686, 2);
            this.m_KeyWorkTextBox.CustomButton.Name = "";
            this.m_KeyWorkTextBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.m_KeyWorkTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.m_KeyWorkTextBox.CustomButton.TabIndex = 1;
            this.m_KeyWorkTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.m_KeyWorkTextBox.CustomButton.UseSelectable = true;
            this.m_KeyWorkTextBox.CustomButton.Visible = false;
            this.m_KeyWorkTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_KeyWorkTextBox.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.m_KeyWorkTextBox.Lines = new string[0];
            this.m_KeyWorkTextBox.Location = new System.Drawing.Point(209, 12);
            this.m_KeyWorkTextBox.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.m_KeyWorkTextBox.MaxLength = 32767;
            this.m_KeyWorkTextBox.Name = "m_KeyWorkTextBox";
            this.m_KeyWorkTextBox.PasswordChar = '\0';
            this.m_KeyWorkTextBox.PromptText = "Search Keyword";
            this.m_KeyWorkTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.m_KeyWorkTextBox.SelectedText = "";
            this.m_KeyWorkTextBox.SelectionLength = 0;
            this.m_KeyWorkTextBox.SelectionStart = 0;
            this.m_KeyWorkTextBox.ShortcutsEnabled = true;
            this.m_KeyWorkTextBox.Size = new System.Drawing.Size(712, 28);
            this.m_KeyWorkTextBox.TabIndex = 1;
            this.m_KeyWorkTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_KeyWorkTextBox.UseSelectable = true;
            this.m_KeyWorkTextBox.WaterMark = "Search Keyword";
            this.m_KeyWorkTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.m_KeyWorkTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // m_SearchButton
            // 
            this.m_SearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_SearchButton.Location = new System.Drawing.Point(929, 12);
            this.m_SearchButton.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.m_SearchButton.Name = "m_SearchButton";
            this.m_SearchButton.Size = new System.Drawing.Size(96, 28);
            this.m_SearchButton.TabIndex = 2;
            this.m_SearchButton.Text = "Search";
            this.m_SearchButton.UseSelectable = true;
            this.m_SearchButton.Click += new System.EventHandler(this.m_SearchButton_Click);
            // 
            // m_ResultTextBox
            // 
            // 
            // 
            // 
            this.m_ResultTextBox.CustomButton.Image = null;
            this.m_ResultTextBox.CustomButton.Location = new System.Drawing.Point(645, 2);
            this.m_ResultTextBox.CustomButton.Name = "";
            this.m_ResultTextBox.CustomButton.Size = new System.Drawing.Size(381, 381);
            this.m_ResultTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.m_ResultTextBox.CustomButton.TabIndex = 1;
            this.m_ResultTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.m_ResultTextBox.CustomButton.UseSelectable = true;
            this.m_ResultTextBox.CustomButton.Visible = false;
            this.m_ResultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ResultTextBox.Lines = new string[] {
        "metroTextBox2"};
            this.m_ResultTextBox.Location = new System.Drawing.Point(3, 61);
            this.m_ResultTextBox.MaxLength = 32767;
            this.m_ResultTextBox.Multiline = true;
            this.m_ResultTextBox.Name = "m_ResultTextBox";
            this.m_ResultTextBox.PasswordChar = '\0';
            this.m_ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_ResultTextBox.SelectedText = "";
            this.m_ResultTextBox.SelectionLength = 0;
            this.m_ResultTextBox.SelectionStart = 0;
            this.m_ResultTextBox.ShortcutsEnabled = true;
            this.m_ResultTextBox.Size = new System.Drawing.Size(1029, 386);
            this.m_ResultTextBox.TabIndex = 1;
            this.m_ResultTextBox.Text = "metroTextBox2";
            this.m_ResultTextBox.UseSelectable = true;
            this.m_ResultTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.m_ResultTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 530);
            this.Controls.Add(this.metroPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "SearchForm";
            this.Padding = new System.Windows.Forms.Padding(22, 60, 22, 20);
            this.Resizable = false;
            this.Text = "HTML Documents Search Engine";
            this.metroPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroLabel m_KeyWordLabel;
        private MetroFramework.Controls.MetroTextBox m_KeyWorkTextBox;
        private MetroFramework.Controls.MetroTextBox m_ResultTextBox;
        private MetroFramework.Controls.MetroButton m_SearchButton;
    }
}

