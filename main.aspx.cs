using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Data.SqlClient;

namespace thinkTwice
{
    public partial class main : System.Web.UI.Page
    {
        string account = null;
        string pass = null;
        string pass_check = null;
        int id = 0;
        int checkO = 0; //登入確認器
        int checkR = 0; //註冊確認器

        //頁面載入器
        protected void Page_Load(object sender, EventArgs e)
        {

            if (checkR == 0)
            {
                Register_button.Visible = true;
                Register_button0.Visible = false;
            }
        }
        //登入器
        protected void checkLogin()
        {
            SqlConnection objCon;
            SqlCommand objCmd;
            SqlDataReader objDR;
            string strDbCon, strSQL;
            // 資料庫連接字串
            strDbCon = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                        "AttachDbFilename=" +
                         Server.MapPath("App_Data\\user.mdf") +
                        ";Integrated Security=True";
            objCon = new SqlConnection(strDbCon);
            objCon.Open(); // 開啟資料庫連接

            strSQL = "SELECT[user_name], [user_password] FROM [User_log] ";
            //這樣寫SQL無論如何都會找到@@

            // 建立Command物件的SQL指令
            objCmd = new SqlCommand(strSQL, objCon);
            objDR = objCmd.ExecuteReader();
            // 取得DataReader物件
            if (objDR.HasRows)
            {
                // 顯示資料表的記錄
                while (objDR.Read())
                {
                    string test1, test2, test4, test5;
                    test2 = account;
                    test1 = objDR["user_name"].ToString();
                    test5 = pass;
                    test4 = objDR["user_password"].ToString();
                    string test3 = null; //字串初始化要用null
                    string test6 = null; //字串初始化要用null
                    for (int x = 0; x < 20; x++)
                    {
                        if (test1[x] != ' ')
                        {
                            test3 += test1[x];
                        }
                    }
                    for (int x = 0; x < 20; x++)
                    {
                        if (test4[x] != ' ')
                        {
                            test6 += test4[x];
                        }
                    }
                    //驗證訊息
                    //Label3.Text = test2 + "<br/>" + test3 + test5 + "<br/>" + test6 + checkO.ToString();
                    //
                    if (test3 == test2 && test6 == test5)
                    {
                        checkO = 1;
                        break;
                    }
                    else
                    {
                        //搜尋下一筆
                        checkO = 2;
                        continue;
                    }
                }
            }
            else
            {
                Label3.Text = "Error 202!";
            }
            objDR.Close(); // 關閉DataReader
            objCon.Close(); // 關閉資料庫連接
        }

        //驗證帳號是否有人使用+新建帳號之準備
        protected void checkAccount()
        {
            SqlConnection objCon;
            SqlCommand objCmd;
            SqlDataReader objDR;
            string strDbCon, strSQL;
            // 資料庫連接字串
            strDbCon = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                        "AttachDbFilename=" +
                         Server.MapPath("App_Data\\user.mdf") +
                        ";Integrated Security=True";
            objCon = new SqlConnection(strDbCon);
            objCon.Open(); // 開啟資料庫連接
            strSQL = "SELECT[id],[user_name] FROM [User_log] ";
            // 建立Command物件的SQL指令
            objCmd = new SqlCommand(strSQL, objCon);
            objDR = objCmd.ExecuteReader();
            // 取得DataReader物件
            if (objDR.HasRows)
            {

                int z = 0; //id接收暫存器
                // 顯示資料表的記錄
                while (objDR.Read())
                {
                    z = (int)objDR["id"];
                    string test1, test2;
                    test2 = account;
                    test1 = objDR["user_name"].ToString();
                    string test3 = null; //字串初始化要用null
                    for (int x = 0; x < 20; x++)
                    {
                        if (test1[x] != ' ')
                        {
                            test3 += test1[x];
                        }
                    }
                    if (test3 == test2)
                    {
                        checkR = -1;
                        break;
                    }
                    else
                    {
                        //搜尋下一筆
                        checkR = 0;
                        continue;
                    }
                }
                id = z;
            }
            else
            {
                Label3.Text = "Error 202!";
            }
            objDR.Close(); // 關閉DataReader
            objCon.Close(); // 關閉資料庫連接
        }

        //註冊器(新增之帳號寫入SQL)
        protected void register()
        {
            pass = password_1.Text;
            pass_check = password_2.Text;
            SqlConnection objCon;
            SqlCommand objCmd;
            string strDbCon, strSQL;
            // 資料庫連接字串
            strDbCon = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                        "AttachDbFilename=" +
                         Server.MapPath("App_Data\\user.mdf") +
                        ";Integrated Security=True";
            objCon = new SqlConnection(strDbCon);
            objCon.Open(); // 開啟資料庫連接
            //資料insertSQL指令
            id = id + 1;
            strSQL = "INSERT INTO [User_log] " +
                     "VALUES('" + id + "',N'" + account + "',N'" + pass_check + "')";
            //建立Command物件的SQL指令
            objCmd = new SqlCommand(strSQL, objCon);
            if (pass == pass_check)
            {
                //無情的指令執行機器。
                objCmd.ExecuteNonQuery();
                Label3.Text = "註冊成功!";
            }
            else
            {
                Label3.Text = "密碼需重新確認。";
            }
            objCon.Close(); // 關閉資料庫連接
        }
        string w_text = null;
        //week轉換器
        void week_to_text(string w)
        {

            if (w == "0")
            {
                w_text = "星期一";

            }
            if (w == "1")
            {
                w_text = "星期二";
            }
            if (w == "2")
            {
                w_text = "星期三";
            }
            if (w == "3")
            {
                w_text = "星期四";
            }
            if (w == "4")
            {
                w_text = "星期五";
            }
        }
        protected void clearclass()
        {
            pass = password_1.Text;
            pass_check = password_2.Text;
            SqlConnection objCon;
            SqlCommand objCmd;
            string strDbCon, strSQL;
            // 資料庫連接字串
            strDbCon = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                        "AttachDbFilename=" +
                         Server.MapPath("App_Data\\database.mdf") +
                        ";Integrated Security=True";
            objCon = new SqlConnection(strDbCon);
            objCon.Open(); // 開啟資料庫連接
                           //資料insertSQL指令
            for (int y = 0; y < 14; y++)
            {
                for(int x = 0; x < 5; x++) {
                string section_db = y.ToString();
                    week_to_text(x.ToString());
                string week_text = w_text;
                strSQL = "UPDATE [class] " + "SET " + week_text + " = NULL "
                       + "WHERE id='" + section_db + "'";
                //建立Command物件的SQL指令
                objCmd = new SqlCommand(strSQL, objCon);
                    //執行
                    objCmd.ExecuteNonQuery();
                    //驗證訊息
                    //Label3.Text = strSQL;
                }
            }
            objCon.Close(); // 關閉資料庫連接
        }
        //登入按鈕
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (user_1.Text == "\0") //已增加驗證控制項
            {
                Label3.Text = "空的!";
            }
            else if (user_1.Text != null && password_1.Text != null)
            {
                account = user_1.Text;
                pass = password_1.Text;
                checkLogin();
                if (checkO == 1)
                {
                    clearclass();
                    Response.Redirect("select_class.aspx");
                }
                else if (checkO == 2)
                {
                    Label3.Text = "密碼錯誤或是帳號不存在，請確認輸入資訊。";
                }
            }

        }

        //引導至註冊頁面的按鈕
        protected void Button2_Click(object sender, EventArgs e)
        {
            password_2.Visible = true;
            password_2_text.Visible = true;
            login_button.Visible = false;
            Register_button.Visible = false;
            Register_button0.Visible = true;
            Label3.Text = "請確認密碼。";
            //測試訊息
            //Label3.Text += checkR.ToString();
            if (checkR == 0)
            {
                checkR = 1;
                //測試訊息
                //Label3.Text += "哈哈哈這裡被我佔據了";
            }
        }

        //註冊頁面的註冊按鈕
        protected void Button3_Click(object sender, EventArgs e)
        {
            //需要做驗證控制項
            account = user_1.Text;
            pass = password_1.Text;
            pass_check = password_2.Text;
            if (pass == pass_check)
            {
                checkAccount();
                //測試訊息
                //Label3.Text += "帳號確認 " + checkR.ToString();
                if (checkR != -1)
                {
                    register();
                    password_2.Visible = false;
                    password_2_text.Visible = false;
                    login_button.Visible = true;
                }
                else
                {
                    Label3.Text = "此帳號已有人使用。";
                    Register_button.Visible = false;
                    Register_button0.Visible = true;
                }
            }
            else
            {
                Label3.Text = "請確認密碼。";
                Register_button.Visible = false;
                Register_button0.Visible = true;

            }

        }
    }
}