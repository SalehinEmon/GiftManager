using GiftManagerWebApp.DatabaseContext;
using GiftManagerWebApp.Models;
using GiftManagerWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftManagerWebApp.BLL
{
    public class UserManager
    {
        private GiftManagerContext _giftManagerContext;

        public UserManager() { _giftManagerContext = new GiftManagerContext(); }


        public void LogOut()
        {
            UserSession.ClearUserSession();
        }


        public User LogInCheck(string email,string password)
        {
            User userToCheck = FindUserByEmail(email);

            if(userToCheck != null)
            {
                bool validationState = PasswordHash.CheckPasswordAndSalt
                    (password, userToCheck.PasswordSalt, userToCheck.Password);

                if(validationState)
                {
                    return userToCheck;
                }
                else
                {
                    return null;

                }


                
            }
            return null;
        }


        private User FindUserByEmail(string email)
        {
            User user = null;

            user=_giftManagerContext.Users
                      .Where(u => u.Email == email)
                      .FirstOrDefault();

            return user;
        }


        public int AddNewUser(User user)
        {

            if(FindUserByEmail(user.Email) != null)
            {
                return 0;
            }

            string hashedPassword;
            string passwordSalt;

            PasswordHash.GenerateHashPassAndSalt(out hashedPassword,out passwordSalt, user.Password);
            
            user.Password = hashedPassword;
            user.PasswordSalt = passwordSalt;

            _giftManagerContext.Users.Add(user);
            int rowEffecte = _giftManagerContext.SaveChanges();

            return rowEffecte;

        }


        public bool ChangePassword(string email,string newPassword,string oldPassword)
        {

            User userToChangePass = FindUserByEmail(email);

            if(userToChangePass != null)
            {
                bool validationState = PasswordHash.CheckPasswordAndSalt
                    (oldPassword, userToChangePass.PasswordSalt, userToChangePass.Password);

                if(validationState)
                {
                    userToChangePass = _giftManagerContext
                                        .Users
                                        .Where(u => u.Email == email)
                                        .FirstOrDefault();

                    string hashedPassword;
                    string passwordSalt;

                    PasswordHash.GenerateHashPassAndSalt
                        (out hashedPassword, out passwordSalt, newPassword);

                    userToChangePass.Password = hashedPassword;
                    userToChangePass.PasswordSalt = passwordSalt;

                    _giftManagerContext.SaveChanges();

                    return true;

                }

            }

            return false;


        }
    }
}