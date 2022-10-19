using CommonLibrary.Global;
using System;
using System.Data.SqlClient;
using WebDAL.Utility;
using WebModel.Interface;
using WebModel.Login;

namespace WebDAL.Login
{
    public class LoginData: ILoginData
    {
        public bool IsMember(AccountModel account)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Entry.SystemConfig.DBPath))
                {
                    con.Open();
                    string sql = $@"select count(*) as count from MemberData where Account = {account.Account.FormatDBString()} and Password = {account.Password.FormatDBString()}";
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                    {
                        System.Data.SqlClient.SqlDataReader rdr = null;
                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            return Convert.ToInt32(rdr["count"]) > 0 ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}
