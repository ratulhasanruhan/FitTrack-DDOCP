namespace FitTrack_DDOCP.Forms
{
    partial class ActivityEntryForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSelectActivity = new System.Windows.Forms.Label();
            this.cmbActivity = new System.Windows.Forms.ComboBox();
            this.lblMetric1 = new System.Windows.Forms.Label();
            this.txtMetric1 = new System.Windows.Forms.TextBox();
            this.lblMetric2 = new System.Windows.Forms.Label();
            this.txtMetric2 = new System.Windows.Forms.TextBox();
            this.lblMetric3 = new System.Windows.Forms.Label();
            this.txtMetric3 = new System.Windows.Forms.TextBox();
            this.panelCalories = new System.Windows.Forms.Panel();
            this.lblCaloriesValue = new System.Windows.Forms.Label();
            this.lblCaloriesLabel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelCalories.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(550, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(226, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Fitness Activity";
            // 
            // lblSelectActivity
            // 
            this.lblSelectActivity.AutoSize = true;
            this.lblSelectActivity.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectActivity.Location = new System.Drawing.Point(30, 80);
            this.lblSelectActivity.Name = "lblSelectActivity";
            this.lblSelectActivity.Size = new System.Drawing.Size(118, 20);
            this.lblSelectActivity.TabIndex = 1;
            this.lblSelectActivity.Text = "Select Activity:";
            // 
            // cmbActivity
            // 
            this.cmbActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivity.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbActivity.FormattingEnabled = true;
            this.cmbActivity.Items.AddRange(new object[] {
            "Walking",
            "Swimming",
            "Running",
            "Cycling",
            "Skipping",
            "Yoga"});
            this.cmbActivity.Location = new System.Drawing.Point(34, 105);
            this.cmbActivity.Name = "cmbActivity";
            this.cmbActivity.Size = new System.Drawing.Size(480, 28);
            this.cmbActivity.TabIndex = 1;
            this.cmbActivity.SelectedIndexChanged += new System.EventHandler(this.cmbActivity_SelectedIndexChanged);
            // 
            // lblMetric1
            // 
            this.lblMetric1.AutoSize = true;
            this.lblMetric1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric1.Location = new System.Drawing.Point(30, 160);
            this.lblMetric1.Name = "lblMetric1";
            this.lblMetric1.Size = new System.Drawing.Size(66, 19);
            this.lblMetric1.TabIndex = 3;
            this.lblMetric1.Text = "Metric 1:";
            // 
            // txtMetric1
            // 
            this.txtMetric1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetric1.Location = new System.Drawing.Point(34, 185);
            this.txtMetric1.Name = "txtMetric1";
            this.txtMetric1.Size = new System.Drawing.Size(480, 27);
            this.txtMetric1.TabIndex = 2;
            this.txtMetric1.TextChanged += new System.EventHandler(this.txtMetric_TextChanged);
            // 
            // lblMetric2
            // 
            this.lblMetric2.AutoSize = true;
            this.lblMetric2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric2.Location = new System.Drawing.Point(30, 230);
            this.lblMetric2.Name = "lblMetric2";
            this.lblMetric2.Size = new System.Drawing.Size(66, 19);
            this.lblMetric2.TabIndex = 5;
            this.lblMetric2.Text = "Metric 2:";
            // 
            // txtMetric2
            // 
            this.txtMetric2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetric2.Location = new System.Drawing.Point(34, 255);
            this.txtMetric2.Name = "txtMetric2";
            this.txtMetric2.Size = new System.Drawing.Size(480, 27);
            this.txtMetric2.TabIndex = 3;
            this.txtMetric2.TextChanged += new System.EventHandler(this.txtMetric_TextChanged);
            // 
            // lblMetric3
            // 
            this.lblMetric3.AutoSize = true;
            this.lblMetric3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric3.Location = new System.Drawing.Point(30, 300);
            this.lblMetric3.Name = "lblMetric3";
            this.lblMetric3.Size = new System.Drawing.Size(66, 19);
            this.lblMetric3.TabIndex = 7;
            this.lblMetric3.Text = "Metric 3:";
            // 
            // txtMetric3
            // 
            this.txtMetric3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetric3.Location = new System.Drawing.Point(34, 325);
            this.txtMetric3.Name = "txtMetric3";
            this.txtMetric3.Size = new System.Drawing.Size(480, 27);
            this.txtMetric3.TabIndex = 4;
            this.txtMetric3.TextChanged += new System.EventHandler(this.txtMetric_TextChanged);
            // 
            // panelCalories
            // 
            this.panelCalories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.panelCalories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCalories.Controls.Add(this.lblCaloriesValue);
            this.panelCalories.Controls.Add(this.lblCaloriesLabel);
            this.panelCalories.Location = new System.Drawing.Point(34, 375);
            this.panelCalories.Name = "panelCalories";
            this.panelCalories.Size = new System.Drawing.Size(480, 60);
            this.panelCalories.TabIndex = 9;
            // 
            // lblCaloriesValue
            // 
            this.lblCaloriesValue.AutoSize = true;
            this.lblCaloriesValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaloriesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblCaloriesValue.Location = new System.Drawing.Point(350, 12);
            this.lblCaloriesValue.Name = "lblCaloriesValue";
            this.lblCaloriesValue.Size = new System.Drawing.Size(94, 32);
            this.lblCaloriesValue.TabIndex = 1;
            this.lblCaloriesValue.Text = "0 kcal";
            // 
            // lblCaloriesLabel
            // 
            this.lblCaloriesLabel.AutoSize = true;
            this.lblCaloriesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaloriesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblCaloriesLabel.Location = new System.Drawing.Point(15, 18);
            this.lblCaloriesLabel.Name = "lblCaloriesLabel";
            this.lblCaloriesLabel.Size = new System.Drawing.Size(135, 21);
            this.lblCaloriesLabel.TabIndex = 0;
            this.lblCaloriesLabel.Text = "Calories Burned:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(280, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 45);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Activity";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(415, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 45);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ActivityEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(550, 530);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelCalories);
            this.Controls.Add(this.txtMetric3);
            this.Controls.Add(this.lblMetric3);
            this.Controls.Add(this.txtMetric2);
            this.Controls.Add(this.lblMetric2);
            this.Controls.Add(this.txtMetric1);
            this.Controls.Add(this.lblMetric1);
            this.Controls.Add(this.cmbActivity);
            this.Controls.Add(this.lblSelectActivity);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ActivityEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Activity - FitTrack";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelCalories.ResumeLayout(false);
            this.panelCalories.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectActivity;
        private System.Windows.Forms.ComboBox cmbActivity;
        private System.Windows.Forms.Label lblMetric1;
        private System.Windows.Forms.TextBox txtMetric1;
        private System.Windows.Forms.Label lblMetric2;
        private System.Windows.Forms.TextBox txtMetric2;
        private System.Windows.Forms.Label lblMetric3;
        private System.Windows.Forms.TextBox txtMetric3;
        private System.Windows.Forms.Panel panelCalories;
        private System.Windows.Forms.Label lblCaloriesLabel;
        private System.Windows.Forms.Label lblCaloriesValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
