using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PanterToBookkeeping
{
    /// <summary>
    /// תצוגה לפי בחירת החיפוש
    /// </summary>
    enum SearchBy { TodayandYesterday, History, EmployeeNum, Carnum, Id, FullName,OtherDates,ShowActiveCars };

    public partial class Frm_Main : Form
    {
        Cars CarObject = new Cars();
        DataTable DTCars = new DataTable();//קבלת טבלה מפנתר
        DataTable DtHistory = new DataTable();//טבלת כל השינויי רכבים אי פעם
        DataTable DtChanges = new DataTable();//טבלת שינויים לפי החיפושים
        SearchBy Choice = SearchBy.History;//enum של תצוגה

        public Frm_Main()
        {
            InitializeComponent();

            DTCars = CarObject.GetPanterChanges((int)SearchBy.TodayandYesterday, null);
            CarObject.GetEmployeesDetails();
            DataGridView_employees.DataSource = DTCars;
            

            ChangeColumnHeader(DataGridView_employees);
            DtHistory = CarObject.GetPanterChanges((int)SearchBy.History, null);
            DataGridView_History.DataSource = DtHistory;
            ChangeColumnHeader(DataGridView_History);
            FillCombo();
            lbl_show.Text = "מתאריך " + DateTime.Today.AddDays(-1).ToLongDateString();
            
            //שינוי רקע עמודת מ ואל
            DataGridView_employees.Columns["FromOwner"].DefaultCellStyle.BackColor = Color.Red;
            DataGridView_History.Columns["FromOwner"].DefaultCellStyle.BackColor = Color.Red;
            DataGridView_employees.Columns["FullName"].DefaultCellStyle.BackColor = Color.LawnGreen;
            DataGridView_History.Columns["FullName"].DefaultCellStyle.BackColor = Color.LawnGreen;
            DataGridView_employees.Columns["ID"].Visible = false;
            DataGridView_History.Columns["ID"].Visible = false;
            DataGridView_employees.Columns["FromOwner"].DefaultCellStyle.BackColor = Color.Red;



        }

        /// <summary>
        /// מילוי קומבו חיפוש
        /// </summary>
        private void FillCombo()
        {

            cbo_search.Items.Add("מספר עובד");
            cbo_search.Items.Add("מספר רכב");
            cbo_search.Items.Add("ת.ז");
            //cbo_search.Items.Add("שם");


        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D; ;
            this.WindowState = FormWindowState.Maximized;

        }

        private void ChangeColumnHeader(DataGridView dataGridView)
        {

            dataGridView.Columns["EmployeeNum"].HeaderText = "מספר עובד";
            dataGridView.Columns["ID"].HeaderText = "תעודת זהות";
            dataGridView.Columns["Car_No"].HeaderText = "מספר רכב";
            dataGridView.Columns["FullName"].HeaderText = "שם מקבל הרכב";
            dataGridView.Columns["Department"].HeaderText = "מחלקה";
            dataGridView.Columns["From_Dt"].HeaderText = "מתאריך";
            dataGridView.Columns["To_DT"].HeaderText = "עד תאריך";
            dataGridView.Columns["Model"].HeaderText = "דגם";
            dataGridView.Columns["supplier"].HeaderText = "שם ספק";
            dataGridView.Columns["FromOwner"].HeaderText = "מ...";


        }

        private void DataGridView_employees_SortStringChanged(object sender, EventArgs e)
        {
            DTCars.DefaultView.Sort = this.DataGridView_employees.SortString;
        }

        private void DataGridView_employees_FilterStringChanged(object sender, EventArgs e)
        {
            DTCars.DefaultView.RowFilter = this.DataGridView_employees.FilterString;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cbo_search_result.Text == "") return;
            DtChanges = CarObject.GetPanterChanges((int)Choice, cbo_search_result.Text);//שולח בחירה לפי שדה ואת הרשומה שרוצים לחפש
            DataGridView_History.DataSource = DtChanges;

            //הצגה למשתמש לפי איזה שדה מחפשים

            if (Choice == SearchBy.Carnum)//חיפוש לפי מספר רכב
            {
                string color ="";
                //DataGridView_History.Rows[DataGridView_History.Rows.Count -2].Cells["Car_No"].Style.BackColor = Color.Turquoise;//צביעת תא אחרון
                for (int i = 0; i < DataGridView_History.RowCount -1; i++)//צביעת שורות בשביל להבחין בין שינוי רכבים
                {
                    if (i == 0)
                    {
                        color = "Turquoise";
                        DataGridView_History.Rows[0].Cells["Car_No"].Style.BackColor = Color.Turquoise;
                    }
                    string CarNumberNow = DataGridView_History.Rows[i].Cells["Car_No"].Value.ToString();
                    string CarNumberNext = "";
                    if(i+1< DataGridView_History.RowCount -1)
                    CarNumberNext = DataGridView_History.Rows[i+1].Cells["Car_No"].Value.ToString();
                    if (CarNumberNext == CarNumberNow)//אותו צבע גם בשורה הבאה
                    {
                        if(color == "Turquoise")
                            DataGridView_History.Rows[i + 1].Cells["Car_No"].Style.BackColor = Color.Turquoise;
                        if(color == "LightGoldenrodYellow")
                            DataGridView_History.Rows[i + 1].Cells["Car_No"].Style.BackColor = Color.LightGoldenrodYellow;

                    }
                    else //צבע אחר בשורה הבאה מסמל רכב אחר
                    {
                        if (color == "Turquoise")
                        {
                            DataGridView_History.Rows[i + 1].Cells["Car_No"].Style.BackColor = Color.LightGoldenrodYellow;
                            color = "LightGoldenrodYellow";//עדכון צבע
                        }
                        else if (color == "LightGoldenrodYellow")
                        {
                            DataGridView_History.Rows[i + 1].Cells["Car_No"].Style.BackColor = Color.Turquoise;
                            color = "Turquoise";//עדכון צבע
                        }
                    }
                }

                //טקסט עבור מי החיפוש
                lbl_show.Text = "עבור ";
                for (int i = 0; i < CarObject.CarNumbers.Count; i++)
                {
                    lbl_show.Text += $@"{CarObject.CarNumbers[i]} ";
                }
            }
            else
            {
                lbl_show.Text = "עבור " + cbo_search_result.Text;
                lbl_show.Location = new Point(lbl_show.Location.X + 100, lbl_show.Location.Y);
            }



        }

        private void cbo_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_search.Enabled = true;
            SearchFunc();

        }

        /// <summary>
        /// חיפוש לפי שדה שהמשתמש בוחר
        /// </summary>
        private void SearchFunc()
        {
            try
            {
                DataTable dataSearch = new DataTable();//טבלה עבור תוצאות חיפוש
                cbo_search_result.DataSource = DtHistory;

                if (cbo_search.SelectedItem.ToString() == "מספר עובד")
                {
                    Choice = SearchBy.EmployeeNum;

                    //מונע שורות ריקות בקומבובוקס ומוחק כפיליות
                    var distinctRows = (from DataRow dRow in DtHistory.Rows
                                        select dRow["EmployeeNum"]).Distinct();

                    cbo_search_result.DataSource = null;
                    foreach (object item in distinctRows)
                    {
                        if ((!cbo_search_result.Items.Cast<string>().Contains(item)) && (!(item is null)))
                        {
                            cbo_search_result.Items.Add(item);
                        }
                    }
                }
                else if (cbo_search.SelectedItem.ToString() == "מספר רכב")
                {
                    Choice = SearchBy.Carnum;
                    cbo_search_result.DisplayMember = "Car_No";
                }

                else if (cbo_search.SelectedItem.ToString() == "ת.ז")
                {
                    Choice = SearchBy.Id;
                    cbo_search_result.DisplayMember = "ID";
                }
                else if (cbo_search.SelectedItem.ToString() == "שם")
                {
                    Choice = SearchBy.FullName;
                    cbo_search_result.DisplayMember = "FullName";

                    //מונע שורות ריקות בקומבובוקס ומוחק כפיליות
                    var distinctRows = (from DataRow dRow in DtHistory.Rows
                                        select dRow["FullName"]).Distinct();

                    cbo_search_result.DataSource = null;
                    foreach (object item in distinctRows)
                    {
                        if ((!cbo_search_result.Items.Cast<string>().Contains(item)) && (!(item is null)))
                        {
                            cbo_search_result.Items.Add(item);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbo_lastname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView_History_SortStringChanged(object sender, EventArgs e)
        {
            DtHistory.DefaultView.Sort = this.DataGridView_History.SortString;

        }

        private void DataGridView_History_FilterStringChanged(object sender, EventArgs e)
        {
            DtHistory.DefaultView.RowFilter = this.DataGridView_History.FilterString;
        }

        /// <summary>
        /// -לשונית הסטוריה הצגת שינויים לפי תאריכים מבוקשים
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_show_Click(object sender, EventArgs e)
        {
            ShowChangesByDate(date_start1.Value, date_start2.Value,false);
        }

        /// <summary>
        ///  הצגת שינויים לפי תאריך
        /// </summary>
        private void ShowChangesByDate(DateTime DateStart,DateTime DateEnd,bool ChangeOrHistoryTab)//ChangeOrHistoryTab -history false changes true
        {
            Choice = SearchBy.OtherDates;
            CarObject.DateStart = DateStart;
            CarObject.DateEnd = DateEnd;
            DtChanges = CarObject.GetPanterChanges((int)Choice, null);
            if (!ChangeOrHistoryTab)
                DataGridView_History.DataSource = DtChanges;
            else
                DataGridView_employees.DataSource = DtChanges;
            lbl_show.Text = "מתאריך " +DateStart.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataGridView_employees.DataSource = DTCars;
            DataGridView_History.DataSource = DtHistory;
            string show= "מתאריך " + DateTime.Today.AddDays(-1).ToLongDateString();
            if(lbl_show.Text!=show)//רק פעם אחת יזיז שמאלה את המילה עבור
            lbl_show.Location = new Point(lbl_show.Location.X - 100, lbl_show.Location.Y);//חזרה למיקום מקורי
            lbl_show.Text = show;    
            cbo_search_result.Text = "";
            CarObject.CarNumbers.Clear();//מנקה רשימת חיפוש כלי רכב
        }



        private void LogWave(string LogStr)
        {
            StreamWriter SW;
            string LogName = DateTime.Now.Date.ToString("yyyy-MM-dd") + " LogFile";

            if (!File.Exists(@"P:\\HR\" + LogName + ".txt"))
            {
                SW = File.CreateText(@"P:\\HR\" + LogName + ".txt");
                SW.Close();
            }

            SW = File.AppendText(@"P:\\HR\" + LogName + ".txt");
            SW.WriteLine(DateTime.Now.ToString() + " - " + LogStr);
            SW.Close();
        }


        private void lbl_print_Click(object sender, EventArgs e)
        {
            PrintData(true);
        }

        private void PrintData(bool ChangeOrHistoryTab)//ChangeOrHistoryTab -history false ,changes true
        {
            try
            {
                LogWave("start print");
                DGVPrinter printer = new DGVPrinter();
                LogWave("class");
                printer.Title = "דוח שינויי רכבים " + lbl_show.Text;//Header
                LogWave("1");
                printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
                LogWave("2");
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                LogWave("3");
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                LogWave("4");
                printer.HeaderCellAlignment = StringAlignment.Near;
                LogWave("5");
                printer.Footer = "שינויי רכבים";//Footer
                LogWave("6");
                printer.FooterSpacing = 15;
                LogWave("7");
                //Print landscape mode
                printer.printDocument.DefaultPageSettings.Landscape = true;
                LogWave("8");
                if (ChangeOrHistoryTab)
                {
                    int x = DataGridView_employees.Size.Width;
                    int y = DataGridView_employees.Size.Height;
                    DataGridView_employees.Size = new Size((int)(x * 0.5), (int)(y * 0.5));
                    DataGridView_employees.Columns["FromOwner"].DefaultCellStyle.BackColor = Color.Transparent;
                    printer.PrintDataGridView(DataGridView_employees);
                    DataGridView_employees.Size = new Size(x, y);
                    DataGridView_employees.Columns["FromOwner"].DefaultCellStyle.BackColor = Color.Red;

                }
                else
                {
                    LogWave("9");
                    int x = DataGridView_History.Size.Width;
                    int y = DataGridView_History.Size.Height;
                    LogWave("9xy");
                    DataGridView_History.Size = new Size((int)(x * 0.5), (int)(y * 0.5));
                    LogWave("10");
                    DataGridView_History.Columns["FromOwner"].DefaultCellStyle.BackColor = Color.Transparent;
                    LogWave("11");
                    printer.PrintDataGridView(DataGridView_History);
                    LogWave("12");
                    DataGridView_History.Size = new Size(x, y);
                    DataGridView_History.Columns["FromOwner"].DefaultCellStyle.BackColor = Color.Red;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// הצג תאריכים-לשונית שינויי רכבים
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ShowChangesByDate(date_start_changes1.Value,date_start_changes2.Value,true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintData(false);//מדפיס מטב היסטורי
        }

        /// <summary>
        /// הצגת רכבים פעילים כרגע בלבד
        /// </summary>
        private void cb_ShowActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ShowActive.Checked == true)
            {
                Choice = SearchBy.ShowActiveCars;
                DtChanges = CarObject.GetPanterChanges((int)Choice, cbo_search_result.Text);// case 7-מציג רק את הפעילים כיום

                DataView dv = new DataView(DtChanges); 
                dv.RowFilter = ($@"Car_no<>' ' and FullName<>' '");//סינון רשומות שלא מופיע מספר רכב and Department<>' '
                DataGridView_History.DataSource = dv;          
            }
            else
            {
                DataGridView_History.DataSource = DtHistory;
            }
        }

        private void MakeExcellRepBTN_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            xlWorkSheet.Cells[1, 9] = "מספר עובד";
            xlWorkSheet.Cells[1, 8] = "מספר רכב";
            xlWorkSheet.Cells[1, 7] = "מ..";
            xlWorkSheet.Cells[1, 6] = "אל";
            xlWorkSheet.Cells[1, 5] = "מחלקה";
            xlWorkSheet.Cells[1, 4] = "מתאריך";
            xlWorkSheet.Cells[1, 3] = "עד תאריך";
            xlWorkSheet.Cells[1, 2] = "דגם";
            xlWorkSheet.Cells[1, 1] = "שם ספק";

            //גבולות תא
            Excel.Range UsedRange, chartRange;
            UsedRange = xlWorkSheet.UsedRange;
            int lastUsedRow = UsedRange.Row + UsedRange.Rows.Count - 1;//שורה אחרונה עם טקסט באקסל
            chartRange = xlWorkSheet.get_Range("A1:I" + lastUsedRow);//עיצוב תאים
            chartRange.Borders.Color = System.Drawing.Color.Black.ToArgb();

            //כותרת
            Excel.Range First = xlWorkSheet.get_Range("A1:I1");
            //First.Merge();//מיזוג תאים
            First.Font.Bold = true;
            First.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.PaleTurquoise);
            First.RowHeight = 40;
            First.Font.Size = 16;

            //////מחיקת שורות ריקות
            //for (int i = 2; i < lastUsedRow; i++)
            //{
            //    if (string.IsNullOrEmpty(xlWorkSheet.Cells[i, "I"].Value2 as string))//לפי מתאריך
            //    {
            //        //if (string.IsNullOrEmpty(xlWorkSheet.Cells[i + 1, "P"].Value2 as string))
            //        xlWorkSheet.Rows[i].Delete();

            //    }

            //}
            //מרכוז
            Excel.Range workSheet_range = xlWorkSheet.get_Range("A:I");
            workSheet_range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//מרכוז טקסט
            workSheet_range.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;//מרכוז טקסט
            workSheet_range.ColumnWidth = 12;

            Excel.Range oRng;
            oRng = xlWorkSheet.get_Range("A1", "I" +lastUsedRow);
            oRng.AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);
            //Excel.Range firstRow = (Excel.Range)xlWorkSheet.Rows[1];
    

            //פוקוס על תא בדטה גריד
            DataGridView_History.CurrentCell = DataGridView_History.Rows[2].Cells[3];
            DataGridView_History.Focus();
            DataGridView_History.BeginEdit(true);

            xlexcel.Visible = true;
            Cursor.Current = Cursors.Default;
            //xlWorkBook.Close();
            releaseObject(xlexcel);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);
        }

        private void copyAlltoClipboard()
        {
            DataGridView_History.SelectAll();
            DataObject dataObj = DataGridView_History.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
    }
