using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace thinkTwice
{
    public partial class select_class : System.Web.UI.Page
    {

        /*int[,] Class = new int[7, 14] {{0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0}};*/
        //C#的陣列超帥
        public int[,] Class = new int[5, 14]; //已經初始化了
        string w_text=null;
        int k = 0; //節數計算機
        string[,] Class_name = new string[5, 14];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void prGrid()
        {
            Label2.Text = "\0";
            for (int x = 0; x < 14; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    Label2.Text += Class[y, x] + " ";
                }
                Label2.Text += "<br/>";
            }
        }

        void changer(char j)
        {
            string arrayC = "1234N56789ABCD";
            //上是定義下是走訪
            for (int x = 0; x < arrayC.Length; x++)
            {
                if (j == arrayC[x])
                {
                    k = x;
                    break;
                }
            }
        }
        void week_to_text(string w)
        {
            
            if (w == "1    ")
            {
                w_text = "星期一";
                
            }
            if (w == "2    ")
            {
                w_text = "星期二";
            }
            if (w == "3    ")
            {
                w_text = "星期三";
            }
            if (w == "4    ")
            {
                w_text = "星期四";
            }
            if (w == "5    ")
            {
                w_text = "星期五";
            }
            
        }
        void class_update()
        {
            SqlConnection objCon;
            SqlCommand objCmd;
            SqlDataReader objDR;
            string strDbCon, strSQL;
            // 資料庫連接字串
            strDbCon = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                        "AttachDbFilename=" +
                         Server.MapPath("App_Data\\database.mdf") +
                        ";Integrated Security=True";
            objCon = new SqlConnection(strDbCon);
            objCon.Open(); // 開啟資料庫連接
            strSQL = "SELECT * FROM [class] ";

            objCmd = new SqlCommand(strSQL, objCon);
            objDR = objCmd.ExecuteReader();
            if (objDR.HasRows)//檢測是否有資料
            {
                for (int n = 0; n < 14; n++)
                {
                    objDR.Read();
                    string Mon, Tus, Wed, Thu, Fri;
                    Mon = objDR["星期一"].ToString();
                    Tus = objDR["星期二"].ToString();
                    Wed = objDR["星期三"].ToString();
                    Thu = objDR["星期四"].ToString();
                    Fri = objDR["星期五"].ToString();
                    if (Mon == null || Mon == "0")
                    {
                        Class[n, 0] = 0;
                    }
                    else
                    {
                        Class[n, 0] = 1;
                    }
                    if (Tus == null || Tus == "0")
                    {
                        Class[n, 1] = 0;
                    }
                    else
                    {
                        Class[n, 1] = 1;
                    }
                    if (Wed == null || Wed == "0")
                    {
                        Class[n, 2] = 0;
                    }
                    else
                    {
                        Class[n, 2] = 1;
                    }
                    if (Thu == null || Thu == "0")
                    {
                        Class[n, 3] = 0;
                    }
                    else
                    {
                        Class[n, 3] = 1;
                    }
                    if (Fri == null || Fri == "0")
                    {
                        Class[n, 4] = 0;
                    }
                    else
                    {
                        Class[n, 4] = 1;
                    }


                }
            }
            objCon.Close();
            objDR.Close();
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
           

            int i = Convert.ToInt32(GridView1.SelectedIndex); //由上往下數第幾列
            string section = GridView1.Rows[i].Cells[5].Text; //該列的第幾節
            string week = GridView1.Rows[i].Cells[4].Text;    //該列為星期幾(string)
            int week_day = Convert.ToInt32(week) - 1;             //該列為星期幾(int)
            week_to_text(week);
            string week_text = w_text;
            int Yes = 0;                                      //衝堂節數
            int No = 0;
            string name_class = GridView1.Rows[i].Cells[2].Text;    //課程名稱
            string place_class = GridView1.Rows[i].Cells[6].Text;   //課程地點

            
            
            
            //衝堂判斷
            Label4.Text = w_text;
            //class_update();

            for (int j = 0; j < section.Length; j++)
            {
                if (section[j] != '0' && section[j] != '\0' && section[j] != ' ')
                {//if的地方不知道為啥會一直讀到' '我把它排除了:)
                    changer(section[j]); //轉換成陣列的格子
                    int section_this = k;
                    Label1.Text = Class.GetValue(week_day, section_this).ToString(); //GetValue出來的型態是Object請把他轉成String //已完成
                    if (Class[week_day, section_this] == 0)
                    {
                        //Class[week_day, section_this] = 1;
                        No++;
                        Label1.Text = Class.GetValue(week_day, section_this).ToString() + " YES:" + Yes.ToString() + "  NO: " + No.ToString();

                    }
                    else if (Class[week_day, section_this] == 1)
                    {
                        Yes++;
                        Label1.Text = "**衝堂警告**";
                    }
                }
            }  //目前問題，無法同時選取兩堂課。待解決。

            if (Yes == 0)
            {
                for (int j = 0; j < section.Length; j++)
                {
                    if (section[j] != '0' && section[j] != '\0' && section[j] != ' ')
                    {
                        changer(section[j]);
                        int section_this = k;
                        Class[week_day, section_this] = 1;
                        Class_name[week_day, section_this] = name_class + "<br>" + place_class;
                        class_to_sql();
                        
                    }
                }
            }
            else if (No > 0)
            {
                Label1.Text = "衝堂";
            }
            //prGrid();
            Label3.Text = "\0";
            for (int x = 0; x < 14; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    Label3.Text += Class_name[y, x] + " ";
                }
                Label3.Text += "<br/>";
            }
            /*----------------------------------------------------*/
            void class_to_sql()
            {
                SqlConnection objCon;
                SqlCommand objCmd;
                SqlDataReader objDR;
                string strDbCon, strSQL;
                // 資料庫連接字串
                strDbCon = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                            "AttachDbFilename=" +
                             Server.MapPath("App_Data\\database.mdf") +
                            ";Integrated Security=True";
                objCon = new SqlConnection(strDbCon);
                objCon.Open(); // 開啟資料庫連接
                strSQL = "SELECT * FROM [class] ";

                objCmd = new SqlCommand(strSQL, objCon);
                objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)//檢測是否有資料
                {
                    // 顯示資料表的記錄
                    for (int j = 0; j < section.Length; j++)
                    {
                        if (section[j] != '0' && section[j] != '\0' && section[j] != ' ')
                        {
                            changer(section[j]);
                            int section_this = k + 1;
                            while (objDR.Read())
                            {
                                string section_db, week_db;
                                section_db = objDR["id"].ToString();
                                //week_db = objDR[week_text].ToString();

                                if (section_db == section_this.ToString())
                                {
                                    SqlConnection objCon2;
                                    SqlCommand objCmd2;
                                    string strDbCon2, strSQL2;
                                    // 資料庫連接字串
                                    strDbCon2 = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                                                "AttachDbFilename=" +
                                                 Server.MapPath("App_Data\\database.mdf") +
                                                ";Integrated Security=True";
                                    objCon2 = new SqlConnection(strDbCon2);
                                    objCon2.Open(); // 開啟資料庫連接

                                    //將week_db寫入class_name
                                    strSQL2 = "UPDATE [class]"
                                                +"SET "+ week_text+" = '"+name_class+"'"
                                                +"WHERE id='"+ section_db+"'";
                                    
                                    objCmd2 = new SqlCommand(strSQL2, objCon2);
                                    objCmd2.ExecuteNonQuery();
                                    Label4.Text = "SQQl";

                                    objCon2.Close();
                                }

                            }
                        }
                    }

                }
                objDR.Close();
                objCon.Close();
            }

            
        }

        
    }
}