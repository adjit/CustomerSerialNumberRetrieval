namespace CustomerSerialNumberRetrieval
{
    partial class getCustomerSerialNumbersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(getCustomerSerialNumbersForm));
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.custNumberLabel = new System.Windows.Forms.Label();
            this.customerNumber = new System.Windows.Forms.TextBox();
            this.executeSerialNumberRetrieval = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "MM-dd-yyyy";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(75, 32);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(133, 20);
            this.startDate.TabIndex = 1;
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(12, 38);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(55, 13);
            this.startDateLabel.TabIndex = 1;
            this.startDateLabel.Text = "Start Date";
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(12, 64);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(52, 13);
            this.endDateLabel.TabIndex = 3;
            this.endDateLabel.Text = "End Date";
            // 
            // endDate
            // 
            this.endDate.CustomFormat = "MM/dd/yyyy";
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(75, 58);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(133, 20);
            this.endDate.TabIndex = 2;
            // 
            // custNumberLabel
            // 
            this.custNumberLabel.AutoSize = true;
            this.custNumberLabel.Location = new System.Drawing.Point(12, 9);
            this.custNumberLabel.Name = "custNumberLabel";
            this.custNumberLabel.Size = new System.Drawing.Size(91, 13);
            this.custNumberLabel.TabIndex = 4;
            this.custNumberLabel.Text = "Customer Number";
            // 
            // customerNumber
            // 
            this.customerNumber.Location = new System.Drawing.Point(109, 6);
            this.customerNumber.Name = "customerNumber";
            this.customerNumber.Size = new System.Drawing.Size(99, 20);
            this.customerNumber.TabIndex = 0;
            // 
            // executeSerialNumberRetrieval
            // 
            this.executeSerialNumberRetrieval.Location = new System.Drawing.Point(75, 84);
            this.executeSerialNumberRetrieval.Name = "executeSerialNumberRetrieval";
            this.executeSerialNumberRetrieval.Size = new System.Drawing.Size(75, 23);
            this.executeSerialNumberRetrieval.TabIndex = 3;
            this.executeSerialNumberRetrieval.Text = "OK";
            this.executeSerialNumberRetrieval.UseVisualStyleBackColor = true;
            this.executeSerialNumberRetrieval.Click += new System.EventHandler(this.executeSerialNumberRetrieval_Click);
            // 
            // getCustomerSerialNumbersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 115);
            this.Controls.Add(this.executeSerialNumberRetrieval);
            this.Controls.Add(this.customerNumber);
            this.Controls.Add(this.custNumberLabel);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.startDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "getCustomerSerialNumbersForm";
            this.Text = "Customer Serial Numbers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label custNumberLabel;
        private System.Windows.Forms.TextBox customerNumber;
        private System.Windows.Forms.Button executeSerialNumberRetrieval;
    }
}