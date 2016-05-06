using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerSerialNumberRetrieval
{
    public partial class getCustomerSerialNumbersForm : Form
    {
        public getCustomerSerialNumbersForm()
        {
            InitializeComponent();
        }

        private void executeSerialNumberRetrieval_Click(object sender, EventArgs e)
        {
            String customerNum = customerNumber.Text;
            DateTime start = startDate.Value;
            DateTime end = endDate.Value;
            if (customerNum == null)
            {
                MessageBox.Show("Please enter valid Customer Number.");
                return;
            }
            else
            {
                Globals.ThisAddIn.runSerialNumberRetreival(customerNum, start, end);
                Close();
            }
        }
    }
}
