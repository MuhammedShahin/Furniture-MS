namespace The_Last
{
    partial class Emp_update
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
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_update = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.combobox_update = new System.Windows.Forms.ComboBox();
            this.comboBox_ID = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(77, 152);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 49;
            this.label8.Text = "update";
            // 
            // textBox_update
            // 
            this.textBox_update.Location = new System.Drawing.Point(133, 151);
            this.textBox_update.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_update.Name = "textBox_update";
            this.textBox_update.Size = new System.Drawing.Size(126, 20);
            this.textBox_update.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "Choose to update";
            // 
            // combobox_update
            // 
            this.combobox_update.FormattingEnabled = true;
            this.combobox_update.Items.AddRange(new object[] {
            "Size",
            "Color",
            "Model",
            "Price",
            "Units in stock"});
            this.combobox_update.Location = new System.Drawing.Point(133, 97);
            this.combobox_update.Margin = new System.Windows.Forms.Padding(2);
            this.combobox_update.Name = "combobox_update";
            this.combobox_update.Size = new System.Drawing.Size(125, 21);
            this.combobox_update.TabIndex = 46;
            // 
            // comboBox_ID
            // 
            this.comboBox_ID.FormattingEnabled = true;
            this.comboBox_ID.Location = new System.Drawing.Point(133, 35);
            this.comboBox_ID.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_ID.Name = "comboBox_ID";
            this.comboBox_ID.Size = new System.Drawing.Size(126, 21);
            this.comboBox_ID.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(106, 40);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 16);
            this.label12.TabIndex = 44;
            this.label12.Text = "ID";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(298, 183);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 38);
            this.button2.TabIndex = 43;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Emp_update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_update);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combobox_update);
            this.Controls.Add(this.comboBox_ID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button2);
            this.Name = "Emp_update";
            this.Size = new System.Drawing.Size(460, 266);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_update;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combobox_update;
        private System.Windows.Forms.ComboBox comboBox_ID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button2;
    }
}
