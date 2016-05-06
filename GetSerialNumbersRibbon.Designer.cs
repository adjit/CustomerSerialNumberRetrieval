namespace CustomerSerialNumberRetrieval
{
    partial class GetSerialNumbersRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public GetSerialNumbersRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.customerSerialNumbersGroup = this.Factory.CreateRibbonGroup();
            this.getCustomerSerialNumbers = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.customerSerialNumbersGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.customerSerialNumbersGroup);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // customerSerialNumbersGroup
            // 
            this.customerSerialNumbersGroup.Items.Add(this.getCustomerSerialNumbers);
            this.customerSerialNumbersGroup.Label = "Customer Serials";
            this.customerSerialNumbersGroup.Name = "customerSerialNumbersGroup";
            // 
            // getCustomerSerialNumbers
            // 
            this.getCustomerSerialNumbers.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.getCustomerSerialNumbers.Image = global::CustomerSerialNumberRetrieval.Properties.Resources.tracking_number_512;
            this.getCustomerSerialNumbers.Label = "Get Customer Serial Numbers";
            this.getCustomerSerialNumbers.Name = "getCustomerSerialNumbers";
            this.getCustomerSerialNumbers.ShowImage = true;
            this.getCustomerSerialNumbers.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.getCustomerSerialNumbers_Click);
            // 
            // GetSerialNumbersRibbon
            // 
            this.Name = "GetSerialNumbersRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.GetSerialNumbersRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.customerSerialNumbersGroup.ResumeLayout(false);
            this.customerSerialNumbersGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup customerSerialNumbersGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton getCustomerSerialNumbers;
    }

    partial class ThisRibbonCollection
    {
        internal GetSerialNumbersRibbon GetSerialNumbersRibbon
        {
            get { return this.GetRibbon<GetSerialNumbersRibbon>(); }
        }
    }
}
