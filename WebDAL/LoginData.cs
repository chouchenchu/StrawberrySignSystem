using CommonLibrary.Global;
using System;
using System.Data.SqlClient;
using WebModel.Login;

namespace WebDAL
{
    public class LoginData
    {
        public bool IsMember(AccountModel account)
        {
            try
            {
                string sql = $@"select count(*) as count from MemberData where Account = '{account.Account}' and Password = '{account.Password}'";
                using (var cn = new SqlConnection(Entry.SystemConfig.DBPath))
                {
                    SqlCommand cmd = new SqlCommand(sql);
                    SqlDataReader rdr=cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        return Convert.ToInt32(rdr["count"] ) > 0 ? true : false; 
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}
