﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace CustomerSerialNumberRetrieval
{
    public partial class GetSerialNumbersRibbon
    {
        private void GetSerialNumbersRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void getCustomerSerialNumbers_Click(object sender, RibbonControlEventArgs e)
        {
            getCustomerSerialNumbersForm snf = new getCustomerSerialNumbersForm();
            snf.Show();
        }
    }
}
