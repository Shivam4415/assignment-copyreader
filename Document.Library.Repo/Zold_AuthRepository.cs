using Dapper;
using Document.Library.Entity;
using Document.Library.Globals.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Excluding from project since there is no references
namespace Document.Library.Repo
{
    public class Zold_AuthRepository
    {

        public UserProfile GetUserProfile(string email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@email", email);
                    return con.Query<UserProfile>("[GetUserProfileByEmail]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                }
            }
            catch
            {
                throw;
            }
        }

        public UserProfile GetUserProfile(Guid userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@id", userId);

                    return con.Query<UserProfile>("[GetUserProfileById]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch
            {
                throw;
            }
        }

        public void RemoveUserSession(Guid sessionId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@sessionId", sessionId);

                    con.Execute("[RemoveUserSession]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }

        public UserSession SetUserSession(UserSession session)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();

                    param.Add("@userId", session.UserId);
                    param.Add("@sessionId", session.Id);
                    param.Add("@lastAccess", session.LastAccess);
                    param.Add("@isPersistent", session.IsPersistent);
                    param.Add("@accessToken", session.AccessToken);
                    param.Add("@accessTokenExpiry", session.AccessTokenExpiry);
                    param.Add("@lastCheckAccessToken", session.LastCheckAccessToken);

                    return con.Query("[SetUserSession]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch
            {
                throw;
            }
        }

        public UserSession GetUserSession(Guid sessionId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@sessionId", sessionId);

                    return con.Query<UserSession>("[GetUserSession]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUserSession(UserSession session)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();

                    param.Add("@userId", session.UserId);
                    //param.Add("@accountId", session.AccountId);
                    param.Add("@sessionId", session.Id);
                    param.Add("@accessToken", session.AccessToken);
                    param.Add("@accessTokenExpiry", session.AccessTokenExpiry);
                    //param.Add("@refreshToken", session.RefreshToken);
                    param.Add("@lastCheckAccessToken", session.LastCheckAccessToken);
                    //param.Add("@isOtpVerified", session.IsOtpVerified);

                    con.Query<UserSession>("[UpdateUserSession]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }



        public void SlideUserSessionExpiration(Guid sessionId, DateTime newExpirationTime, DateTime? lastCheckAccessToken)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@sessionId", sessionId);
                    param.Add("@newExpirationTime", newExpirationTime);
                    param.Add("@lastCheckAccessToken", lastCheckAccessToken);

                    con.Query<UserSession>("[SlideUserSessionExpiration]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch
            {
                throw;
            }
        }


    }

}
