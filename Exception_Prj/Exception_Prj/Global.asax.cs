using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Exception_Prj
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception ex = Server.GetLastError();
            //Server.ClearError();
            //// Response.Write(ex.GetType());
            //Server.Transfer("apperr.html");

            //to handle other handled exceptions if any
            //HttpException lstex = Server.GetLastError() as HttpException;
            //if (lstex.GetHttpCode()==403)
            //{
            //    Server.Transfer("~/err.aspx");
            //}

            Exception ex = Server.GetLastError();
            Server.ClearError();
            string str = "";
            str = ex.Message;
            string path = "C:\\ASP.NET\\Errorfile.txt";
            File.WriteAllText(path, str);
            Server.Transfer("~/PageNotFound.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}