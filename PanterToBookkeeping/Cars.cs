using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanterToBookkeeping
{
    class Cars
    {
        DataTable DTCars = new DataTable();
        public int SearchBy { get; set; }//משתנה תצוגה לפי בחירת המשתמש
        public DateTime DateStart { get; set; }//תאריך התחלה של שינוי
        public DateTime DateEnd { get; set; }//תאריך סיום של שינוי
        Dictionary<int,string> d = new Dictionary<int, string>();//רשימת כל השמות-נוד בשביל לגלות מי בעל הרכב הקודם,שולפים מטבלת היסטוריה
        public DateTime FromDate { get; set; }//מאיזה תאריך החזקת הרכב
        public List <string> CarNumbers { get; set; }//רשימת של חיפוש כלי רכב 

        public Cars()
        {
            CarNumbers = new List<string>();//יוצר רשימה של כלי רכב לפי חיפוש 
        }


        /// <summary>
        ///  קבלת טבלת נתונים מפנתר
        /// </summary>
        public DataTable GetPanterChanges(int SearchBy,string SearchField )//לפי בחירת המשתמש
        {
            this.SearchBy = SearchBy;
            string StrSql = $@"SELECT nig_cars_employees.num_id AS ID,' ' as EmployeeNum, nig_cars_employees.num_risoi AS Car_No,' ' as FromOwner,' ' as FullName,' ' as Department,
                                CONVERT(varchar(10),cast( nig_cars_employees.dt_sioh AS date), 103)   AS From_Dt,case when nig_cars_employees.ad_dt='00000000' then '' else CONVERT(varchar(10),cast(nig_cars_employees.ad_dt AS date), 103)  end To_DT, 
                                table_car_modeles.name_dgm AS Model, table_suppliers.name_sfk as supplier
                                FROM  nig_cars_employees LEFT OUTER JOIN
                                veichles ON nig_cars_employees.num_risoi = veichles.num_risoi LEFT OUTER JOIN
                                table_car_modeles ON veichles.kod_dgm = table_car_modeles.kod_dgm LEFT OUTER JOIN                          
							    (								
								select case when kod_sapak_leasing=0 then kod_sapak_hascara else kod_sapak_leasing end kod_sapak,veichles.kod_dgm 
								from veichles left join table_suppliers on veichles.kod_sapak_hascara=table_suppliers.kod_sfk) as k
								 ON veichles.kod_dgm = k.kod_dgm left join table_suppliers on k.kod_sapak=table_suppliers.kod_sfk ";
            DbServiceSQL dbPanter = new DbServiceSQL();

            //DataTable DTCars = new DataTable();

            switch (SearchBy)
            {
                
                case 0://היום ואתמול

                    StrSql+=    $@" WHERE nig_cars_employees.dt_sioh=convert(varchar, getdate(), 112) or nig_cars_employees.dt_sioh= CONVERT(varchar, dateadd(day,datediff(day,1,GETDATE()),0),112) 
						        or nig_cars_employees.ad_dt=convert(varchar, getdate(), 112) or nig_cars_employees.ad_dt=CONVERT(varchar, dateadd(day,datediff(day,1,GETDATE()),0),112)";//כל האירועים שהתרחשו היום או אתמול
             
                    break;

                case 1://כל ההיסטוריה
                    
                    break;


                case 3://לפי מספר רכב
                    CarNumbers.Add(SearchField);//מוסיפה כלי רכב שהמשתמש רוצה לחפש לפיו
                    for (int i = 0; i < CarNumbers.Count; i++)
                    {
                        if (i == 0)
                        {
                            StrSql += $@" Where(nig_cars_employees.num_risoi IN('{CarNumbers[i]}'";//מספר הרכב הראשון שהמשתמש רוצה לחפש
                        }
                        else
                        {
                            StrSql += $@",'{CarNumbers[i]}'";//תוספת של כלי רכב שרוצה לחפש
                        }
                    }
                    StrSql += "))";//סגירת IN AND WHERE
                    break;


                case 4://לפי ת.ז
                    StrSql += $@" Where(nig_cars_employees.num_id IN('{SearchField}'))";
                    break;

                case 6://לפי תאריך שינויים שהמשתמש יבחר
                    StrSql += $@" Where nig_cars_employees.dt_sioh>={DateStart.ToString("yyyyMMdd")} and nig_cars_employees.dt_sioh<={DateEnd.ToString("yyyyMMdd")}" ;
                    break;

                case 7://מציג רכבים פעילים במפעל(עבור שירן)
                    StrSql += $@" Where  (nig_cars_employees.ad_dt>=convert(varchar, getdate(), 112) or nig_cars_employees.ad_dt='00000000')  and 
								  DATEDIFF (MONTH,  CONVERT(varchar(10),cast( nig_cars_employees.dt_sioh AS date), 23) , CONVERT(varchar(10),cast( GETDATE() AS date), 23) ) <36";//כל מה שעבר תוקף של 3 שנים לא פעיל יותר
                    break;

                    ///case 2,4,5 בפונקציה GetEmployeesDetails בגלל שלוקחים נתונים מאס400
            }
            //StrSql += " order by nig_cars_employees.num_risoi,CONVERT(varchar(10),cast( nig_cars_employees.dt_sioh AS date), 103) ";
            DTCars = dbPanter.GetDataSetByQuery(StrSql, CommandType.Text).Tables[0];
            GetEmployeesDetails();

            if (SearchBy == 2 || SearchBy == 5)
            {
                DTCars = FilterDataTable(SearchField);//רק עבור מקרים 2 4 ו5
                //return DTCars;//החזרה  רק במקרים של חיפוש לפי מספר עובד,ת.ז ושם
            }

            CheckWhichOwnerBefore();//הוספה של בעל הרכב הקודם 
            return DTCars;
        }



        /// <summary>
        /// סינון טבלה במקרים שלסינון לפי שם מלא ומספר עובד
        /// </summary>
        private DataTable FilterDataTable(string SearchField)
        {
            DataTable dataTable=null;
            try
            {
                dataTable = DTCars.Clone();
                switch (SearchBy)
                {
                    case 2://מספר עובד
                        DataRow[] dataRows2 = DTCars.Select($@"EmployeeNum='{int.Parse(SearchField.ToString())}'");
                        foreach (DataRow row in dataRows2)
                        {
                            dataTable.ImportRow(row);
                        }
                        break;

                        //case 5://לפי שם
                        //    DataRow[] dataRows5 = DTCars.Select($@"FullName={SearchField.ToString()}");
                        //    foreach (DataRow row in dataRows5)
                        //    {
                        //        dataTable.ImportRow(row);
                        //    }
                        //    break;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataTable;

        }


        /// <summary>
        /// הוספת פרטי מחזיק רכב מתוך אס400 
        /// </summary>
        /// <returns></returns>
        public void GetEmployeesDetails()
        {
            DBService DBS = new DBService();
            DataTable dataEmployees = new DataTable();
            string Employee_Table = $@"SELECT right(trim(a.OVED),5) as EmployeeNum, a.teudtzhui, substring(a.oved,3,5) as soved ,right(trim(b.MAHLAKA),2) as Department ,trim(fmly1||fmly2||fmly3||fmly4||fmly5||fmly6||fmly7||fmly8||fmly9||fmly10)||' '||trim(name1||name2||name3||name4||name5||name6) as fullName,a.mifal as mifal
                                       FROM ISUFKV.ISAV a LEFT JOIN ISUFKV.ISAVL10 b on a.oved = b.oved inner join BPCSFV30.CDPL01 as C on right(trim(a.MAHLAKA),3)= C.CDEPT";
            dataEmployees = DBS.executeSelectQueryNoParam(Employee_Table);
            foreach (DataRow row in DTCars.Rows)//לולאה על טבלת פנתר
            {
                var v = dataEmployees.Select("teudtzhui = " + row["ID"].ToString() );//משווה באס400 אנשים שתואמים עם הת.ז
                if (v.Length != 0)
                {
                    if (v.Length > 1)// הוספה חדשה-זה אומר שיש עובד שנמצא פעמיים גם במפעל 09 וגם ב01-לוקחים 01
                    {
                        for (int i = 0; i < v.Length; i++)
                        {
                            if (v[i]["mifal"].ToString() == "01")//רק מפעל 01 רלוונטי
                            {
                                row["EmployeeNum"] = v[i]["EmployeeNum"].ToString();
                                row["Department"] = v[i]["Department"].ToString();
                                row["FullName"] = v[i]["fullName"].ToString();  // הוספת שם
                            }
                        }
                    }
                    else//אם קיימת רשומה אחת-הכנסה רגילה
                    {
                        //הכנסה רגילה לטבלה
                        row["EmployeeNum"] = v[0]["EmployeeNum"].ToString();
                        row["Department"] = v[0]["Department"].ToString();
                        row["FullName"] = v[0]["fullName"].ToString();  // הוספת שם
                    }


                if (SearchBy == 1)// אם שייך לטבלת הסטוריה מוסיף את השם לרשימת שמות
                    {
                        if(!d.ContainsKey(int.Parse(row["ID"].ToString())))
                        d.Add(int.Parse(row["ID"].ToString()), row["FullName"].ToString());
                    }
                }
            }



        }


        /// <summary>
        /// מוסיף לרשומות מי הבעל רכב הקודם שהיה
        /// </summary>
        private void CheckWhichOwnerBefore()
        {
            DbServiceSQL dbPanter = new DbServiceSQL();
            DataTable PreviousOwner;
            foreach (DataRow row in DTCars.Rows)
            {         
                PreviousOwner= new DataTable();
                FromDate = DateTime.Parse(row["From_Dt"].ToString());
                if (row["Car_No"].ToString() !=" ") //אם מספר רכב לא ריק
                {
                    string query =
                        $@"SELECT  case when nig_cars_employees.ad_dt='00000000' then 0 else nig_cars_employees.num_id end ID
                       FROM nig_cars_employees 
                       WHERE (nig_cars_employees.ad_dt='00000000' or nig_cars_employees.ad_dt = DATEADD(day, -1, convert(date, '{FromDate.ToString("yyyy-MM-dd")}')) or nig_cars_employees.ad_dt =  convert(date, '{FromDate.ToString("yyyy-MM-dd")}')) and nig_cars_employees.num_risoi IN ('{row["Car_No"].ToString()}')";

                       //WHERE nig_cars_employees .ad_dt=DATEADD(day, -1, convert(date, '{FromDate.ToString("yyyy-MM-dd")}')) and nig_cars_employees.num_risoi IN ('{row["Car_No"].ToString()}') ";
                    PreviousOwner = dbPanter.GetDataSetByQuery(query, CommandType.Text).Tables[0];
                    if (PreviousOwner.Rows.Count == 0 || int.Parse(PreviousOwner.Rows[0]["ID"].ToString()) == 0)
                        row["FromOwner"] = "מאגר";
                    else
                    {
                        string value;
                        d.TryGetValue(int.Parse(PreviousOwner.Rows[0]["ID"].ToString()), out value);//מוצא את שם המחזיק רכב הקודם לפי ת.ז באמצעות המילון
                        if (value == row["FullName"].ToString())//אם השם המקבל שווה לשם הנותן אז הוא נלקח ממאגר
                            row["FromOwner"] = "מאגר";
                        else
                            row["FromOwner"] = value;                       
                    }
                }
            }


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
    }
}
