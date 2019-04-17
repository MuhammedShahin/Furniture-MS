namespace The_Last
{
    partial class Admin_Delete
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
            this.label30 = new System.Windows.Forms.Label();
            this.Branch_IDs = new System.Windows.Forms.ComboBox();
            this.Emp_IDs = new System.Windows.Forms.ComboBox();
            this.cust_IDs = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.radio_Branch = new System.Windows.Forms.RadioButton();
            this.radio_Emp = new System.Windows.Forms.RadioButton();
            this.radio_cust = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(136, 72);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(24, 13);
            this.label30.TabIndex = 85;
            this.label30.Text = "ID :";
            // 
            // Branch_IDs
            // 
            this.Branch_IDs.Enabled = false;
            this.Branch_IDs.FormattingEnabled = true;
            this.Branch_IDs.Location = new System.Drawing.Point(172, 230);
            this.Branch_IDs.Name = "Branch_IDs";
            this.Branch_IDs.Size = new System.Drawing.Size(121, 21);
            this.Branch_IDs.TabIndex = 84;
            // 
            // Emp_IDs
            // 
            this.Emp_IDs.Enabled = false;
            this.Emp_IDs.FormattingEnabled = true;
            this.Emp_IDs.Location = new System.Drawing.Point(172, 150);
            this.Emp_IDs.Name = "Emp_IDs";
            this.Emp_IDs.Size = new System.Drawing.Size(121, 21);
            this.Emp_IDs.TabIndex = 83;
            // 
            // cust_IDs
            // 
            this.cust_IDs.Enabled = false;
            this.cust_IDs.FormattingEnabled = true;
            this.cust_IDs.Location = new System.Drawing.Point(172, 68);
            this.cust_IDs.Name = "cust_IDs";
            this.cust_IDs.Size = new System.Drawing.Size(121, 21);
            this.cust_IDs.TabIndex = 82;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(142, 233);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 13);
            this.label19.TabIndex = 81;
            this.label19.Text = "ID :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(142, 154);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 13);
            this.label20.TabIndex = 80;
            this.label20.Text = "ID :";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PaleGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(356, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 43);
            this.button2.TabIndex = 79;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radio_Branch
            // 
            this.radio_Branch.AutoSize = true;
            this.radio_Branch.Location = new System.Drawing.Point(145, 207);
            this.radio_Branch.Name = "radio_Branch";
            this.radio_Branch.Size = new System.Drawing.Size(59, 17);
            this.radio_Branch.TabIndex = 78;
            this.radio_Branch.TabStop = true;
            this.radio_Branch.Text = "Branch";
            this.radio_Branch.UseVisualStyleBackColor = true;
            this.radio_Branch.CheckedChanged += new System.EventHandler(this.radio_Branch_CheckedChanged);
            // 
            // radio_Emp
            // 
            this.radio_Emp.AutoSize = true;
            this.radio_Emp.Location = new System.Drawing.Point(145, 127);
            this.radio_Emp.Name = "radio_Emp";
            this.radio_Emp.Size = new System.Drawing.Size(71, 17);
            this.radio_Emp.TabIndex = 77;
            this.radio_Emp.TabStop = true;
            this.radio_Emp.Text = "Empolyee";
            this.radio_Emp.UseVisualStyleBackColor = true;
            this.radio_Emp.CheckedChanged += new System.EventHandler(this.radio_Emp_CheckedChanged);
            // 
            // radio_cust
            // 
            this.radio_cust.AutoSize = true;
            this.radio_cust.Location = new System.Drawing.Point(145, 45);
            this.radio_cust.Name = "radio_cust";
            this.radio_cust.Size = new System.Drawing.Size(69, 17);
            this.radio_cust.TabIndex = 76;
            this.radio_cust.TabStop = true;
            this.radio_cust.Text = "Customer";
            this.radio_cust.UseVisualStyleBackColor = true;
            this.radio_cust.CheckedChanged += new System.EventHandler(this.radio_cust_CheckedChanged);
            // 
            // Admin_Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label30);
            this.Controls.Add(this.Branch_IDs);
            this.Controls.Add(this.Emp_IDs);
            this.Controls.Add(this.cust_IDs);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radio_Branch);
            this.Controls.Add(this.radio_Emp);
            this.Controls.Add(this.radio_cust);
            this.Name = "Admin_Delete";
            this.Size = new System.Drawing.Size(569, 313);
            this.Load += new System.EventHandler(this.Admin_Delete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox Branch_IDs;
        private System.Windows.Forms.ComboBox Emp_IDs;
        private System.Windows.Forms.ComboBox cust_IDs;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radio_Branch;
        private System.Windows.Forms.RadioButton radio_Emp;
        private System.Windows.Forms.RadioButton radio_cust;
    }
}
