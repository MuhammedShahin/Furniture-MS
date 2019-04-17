namespace The_Last
{
    partial class Cust_search
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listofSearch = new System.Windows.Forms.DataGridView();
            this.Searchbycat = new System.Windows.Forms.RadioButton();
            this.SearchbyModel = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.comboBox13 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.listofSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // listofSearch
            // 
            this.listofSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listofSearch.Location = new System.Drawing.Point(283, 3);
            this.listofSearch.Name = "listofSearch";
            this.listofSearch.Size = new System.Drawing.Size(435, 308);
            this.listofSearch.TabIndex = 100;
            // 
            // Searchbycat
            // 
            this.Searchbycat.AutoSize = true;
            this.Searchbycat.Location = new System.Drawing.Point(18, 68);
            this.Searchbycat.Name = "Searchbycat";
            this.Searchbycat.Size = new System.Drawing.Size(91, 17);
            this.Searchbycat.TabIndex = 99;
            this.Searchbycat.TabStop = true;
            this.Searchbycat.Text = "Search by cat";
            this.Searchbycat.UseVisualStyleBackColor = true;
            this.Searchbycat.CheckedChanged += new System.EventHandler(this.Searchbycat_CheckedChanged);
            // 
            // SearchbyModel
            // 
            this.SearchbyModel.AutoSize = true;
            this.SearchbyModel.Location = new System.Drawing.Point(18, 32);
            this.SearchbyModel.Name = "SearchbyModel";
            this.SearchbyModel.Size = new System.Drawing.Size(104, 17);
            this.SearchbyModel.TabIndex = 98;
            this.SearchbyModel.TabStop = true;
            this.SearchbyModel.Text = "Search by model";
            this.SearchbyModel.UseVisualStyleBackColor = true;
            this.SearchbyModel.CheckedChanged += new System.EventHandler(this.SearchbyModel_CheckedChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.PaleGreen;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(158, 109);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 43);
            this.button3.TabIndex = 97;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox14
            // 
            this.comboBox14.Enabled = false;
            this.comboBox14.FormattingEnabled = true;
            this.comboBox14.Location = new System.Drawing.Point(146, 64);
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(121, 21);
            this.comboBox14.TabIndex = 96;
            // 
            // comboBox13
            // 
            this.comboBox13.Enabled = false;
            this.comboBox13.FormattingEnabled = true;
            this.comboBox13.Location = new System.Drawing.Point(147, 32);
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new System.Drawing.Size(121, 21);
            this.comboBox13.TabIndex = 95;
            // 
            // Cust_search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listofSearch);
            this.Controls.Add(this.Searchbycat);
            this.Controls.Add(this.SearchbyModel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox14);
            this.Controls.Add(this.comboBox13);
            this.Name = "Cust_search";
            this.Size = new System.Drawing.Size(721, 317);
            ((System.ComponentModel.ISupportInitialize)(this.listofSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listofSearch;
        private System.Windows.Forms.RadioButton Searchbycat;
        private System.Windows.Forms.RadioButton SearchbyModel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox14;
        private System.Windows.Forms.ComboBox comboBox13;
    }
}
