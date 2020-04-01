using Editor.App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Editor.App.Authentication
{
    public static class AuthServices
    {



        public static UserProfile GetUser(string email)
        {
            try
            {
                UserProfile user = new UserProfile();
                //get user from repo
                user.Name = "Shivam";
                user.Email = "shivam441";
                user.Password = "123456";
                return user;
            }
            catch
            {
                throw;
            }
        }


        public static HttpCookie SignIn(UserProfile user)
        {
            try
            {
                UserSession session = new UserSession();
                Random random = new Random();
                session.Id = random.Next();
                session.LastAccess = DateTime.UtcNow;
                session.Email = user.Email;
                session.UserId = user.Id;
                session.IsPersistent = false;


                //Call db to save user session

                FormsAuthenticationTicket ticket = null;

                if (session.IsPersistent)
                {
                    ticket = new FormsAuthenticationTicket(1, user.Email, DateTime.UtcNow, DateTime.UtcNow.AddDays(30), true, session.Id.ToString());
                }
                else
                {
                    ticket = new FormsAuthenticationTicket(1, user.Email, DateTime.UtcNow, DateTime.UtcNow.Add(FormsAuthentication.Timeout), false, session.Id.ToString());
                }


                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                authCookie.Domain = FormsAuthentication.CookieDomain;
                authCookie.HttpOnly = true;
                authCookie.Secure = FormsAuthentication.RequireSSL;

                return authCookie;

            }
            catch
            {
                throw;
            }
        }


    }
}