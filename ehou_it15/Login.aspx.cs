using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace ehou_it15
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void DoLogin()
        {
            if (ValidateCredentials(txtUsername.Value, txtPassword.Value))
            {
                var authTicket = 
                    new FormsAuthenticationTicket(1, txtUsername.Value, DateTime.Now, DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, "something");

                var cookieStr = FormsAuthentication.Encrypt(authTicket);

                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieStr)
                {
                    Path = FormsAuthentication.FormsCookiePath,
                    SameSite = SameSiteMode.Lax
                };

                if (chkPersistCookie.Checked)
                    cookie.Expires = authTicket.Expiration;

                Response.Cookies.Add(cookie);

                var strRedirect = Request["ReturnUrl"] ?? "Default.aspx";
                
                Response.Redirect(strRedirect, true);
            }
            else
            {
                Response.Redirect("Login.aspx", true);
            }
        }

        private static bool ValidateCredentials(string username, string password)
        {
            string lookupPassword = null;

            try
            {
                var conn = new SqlConnection(DataProvider.ConnectionString);
                conn.Open();

                var cmd = new SqlCommand("select password from app_user where uname=@username", conn);
                cmd.Parameters.Add("@userName", SqlDbType.VarChar, 25);
                cmd.Parameters["@userName"].Value = username;

                lookupPassword = (string)cmd.ExecuteScalar();

                cmd.Dispose();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }


            if (null == lookupPassword)
            {
                // You could write failed login attempts here to event log for additional security.
                return false;
            }

            // Compare lookupPassword and input password, using a case-sensitive comparison.
            return 0 == string.CompareOrdinal(lookupPassword, password);
        }
    }
}