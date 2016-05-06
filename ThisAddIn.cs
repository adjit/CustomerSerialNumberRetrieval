using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Data.SqlClient;

namespace CustomerSerialNumberRetrieval
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion

        private enum Cols
        {
            ItemNumber,
            ItemDescription,
            Quantity,
            CustomerName,
            InvoiceDate,
            ShipToName,
            ShipToAddress,
            ShipToCity,
            ShipToState,
            ShipToZip,
            InvoiceNumber,
            CommentText
        }

        private string SELECTSTRING = @"
                                        SELECT
                                            lineItemTable.ITEMNMBR,
	                                        lineItemTable.ITEMDESC,
	                                        lineItemTable.QUANTITY,
	                                        tHeader.ShipToName,
	                                        tHeader.ACTLSHIP,
	                                        tHeader.CNTCPRSN,
	                                        tHeader.ADDRESS2,
	                                        tHeader.CITY,
	                                        tHeader.STATE,
	                                        tHeader.ZIPCODE,
	                                        tHeader.SOPNUMBE,
	                                        serialTable.CMMTTEXT

                                        FROM dbo.SOP30200 tHeader

                                            JOIN dbo.SOP30300 lineItemTable
                                                on tHeader.CUSTNMBR = '";
        private string BETWEENSTRING = @"' AND tHeader.ACTLSHIP BETWEEN '";
        private string ENDSTRING = @"'
			                                AND lineItemTable.SOPNUMBE = tHeader.SOPNUMBE
                                            AND tHeader.SOPNUMBE like 'I%'
	                                JOIN dbo.SOP10202 serialTable
		                                on lineItemTable.LNITMSEQ = serialTable.LNITMSEQ
		                                AND
		                                serialTable.SOPNUMBE = lineItemTable.SOPNUMBE";

        private static string DATASTRING = "Data Source=METRO-GP1;Integrated Security=SSPI;Initial Catalog=METRO";

        private class xRow
        {
            private enum xCols
            {
                ZEROINDEX,
                ItemNumber,
                ItemDescription,
                SerialNumber,
                Quantity,
                CustomerName,
                InvoiceDate,
                ShipToName,
                ShipToAddress,
                ShipToCity,
                ShipToState,
                ShipToZip,
                InvoiceNumber
            }

            public DateTime invoiceDate { get; }
            public int quantity { get; }
            public string itemNumber { get; }
            public string itemDescription { get; }
            public string customerName { get; }
            public string shipToName { get; }
            public string shipToAddress { get; }
            public string shipToCity { get; }
            public string shipToState { get; }
            public string shipToZip { get; }
            public string invoiceNumber { get; }
            public string comment { get; }
            public string[] serialNumbers { get; }

            private bool formattingSet = false;

            public xRow(
                object itemNum, object itemDesc, object qty, object custName, object date, object shipToCustomer,
                object address, object city, object state, object zip, object invoiceNum, object commentText)
            {
                itemNumber = itemNum.ToString().Trim();
                itemDescription = itemDesc.ToString().Trim();
                quantity = Convert.ToInt32(qty);
                customerName = custName.ToString().Trim();
                invoiceDate = (DateTime)date;
                shipToName = shipToCustomer.ToString().Trim();
                shipToAddress = address.ToString().Trim();
                shipToCity = city.ToString().Trim();
                shipToState = state.ToString().Trim();
                shipToZip = zip.ToString().Trim();
                invoiceNumber = invoiceNum.ToString().Trim();
                comment = commentText.ToString().Trim();
                serialNumbers = comment.Split(',');

            }
            
            public void parseRow(Excel.Worksheet ws)
            {
                if(!formattingSet)
                {
                    ws.Cells[1, xCols.InvoiceDate].EntireColumn.NumberFormat = "MM/DD/YYYY";
                    ws.Cells[1, xCols.SerialNumber].EntireColumn.NumberFormat = "@";
                    ws.Cells[1, xCols.ShipToZip].EntireColumn.NumberFormat = "@";
                    formattingSet = true;
                }

                int rowNumber = ws.UsedRange.Row + ws.UsedRange.Rows.Count;

                if (rowNumber == 2) rowNumber = 1;

                for (int i = 0; i < serialNumbers.Length - 1; i++) 
                {
                    ws.Cells[rowNumber, (int)xCols.ItemNumber].Value = itemNumber;
                    ws.Cells[rowNumber, (int)xCols.ItemDescription].Value = itemDescription;
                    ws.Cells[rowNumber, (int)xCols.SerialNumber].Value = serialNumbers[i];
                    ws.Cells[rowNumber, (int)xCols.Quantity].Value = 1;
                    ws.Cells[rowNumber, (int)xCols.CustomerName].Value = customerName;
                    ws.Cells[rowNumber, (int)xCols.InvoiceDate].Value = invoiceDate;
                    ws.Cells[rowNumber, (int)xCols.ShipToName].Value = shipToName;
                    ws.Cells[rowNumber, (int)xCols.ShipToAddress].Value = shipToAddress;
                    ws.Cells[rowNumber, (int)xCols.ShipToCity].Value = shipToCity;
                    ws.Cells[rowNumber, (int)xCols.ShipToState].Value = shipToState;
                    ws.Cells[rowNumber, (int)xCols.ShipToZip].Value = shipToZip;
                    ws.Cells[rowNumber, (int)xCols.InvoiceNumber].Value = invoiceNumber;
                    rowNumber++;
                }
            }
        }

        private String buildQuery(String customerNumber, DateTime startDate, DateTime endDate)
        {
            String query = SELECTSTRING + customerNumber + BETWEENSTRING;
            query += startDate.ToShortDateString() + "' AND '" + endDate.ToShortDateString() + ENDSTRING;
            System.Diagnostics.Debug.WriteLine(query);
            return query;
        }

        public void runSerialNumberRetreival(string customerNumber, DateTime startDate, DateTime endDate)
        {
            xRow thisRow;

            Excel.Workbook thisWorkbook = Globals.ThisAddIn.Application.ActiveWorkbook;
            Excel.Worksheet thisWorksheet = thisWorkbook.ActiveSheet;

            SqlConnection dbConnection = new SqlConnection(DATASTRING);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = buildQuery(customerNumber, startDate, endDate);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dbConnection;

            dbConnection.Open();

            reader = cmd.ExecuteReader();

            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    thisRow = new xRow(
                        reader.GetValue((int)Cols.ItemNumber), reader.GetValue((int)Cols.ItemDescription),
                        reader.GetValue((int)Cols.Quantity), reader.GetValue((int)Cols.CustomerName),
                        reader.GetValue((int)Cols.InvoiceDate), reader.GetValue((int)Cols.ShipToName),
                        reader.GetValue((int)Cols.ShipToAddress), reader.GetValue((int)Cols.ShipToCity),
                        reader.GetValue((int)Cols.ShipToState), reader.GetValue((int)Cols.ShipToZip),
                        reader.GetValue((int)Cols.InvoiceNumber), reader.GetValue((int)Cols.CommentText));

                    thisRow.parseRow(thisWorksheet);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No Rows Found");
            }

            dbConnection.Close();
        }
    }
}
