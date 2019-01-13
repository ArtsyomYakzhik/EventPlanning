using EventPlanning.Controllers;
using EventPlanning.Models.DB.Interaction;
using EventPlanning.Models.DB.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanning.Models.ElementControl
{
    static public class UserControl
    {
        static private DBInteraction dBInteraction = new DBInteraction();

        static public void userAuthentification(UserController userController, User user)
        {
            string userId = checkUserEmailAndPassword(user.Email, user.Password);
            if (userId != null)
            {
                userController.Session["UserId"] = userId;
                userController.UserHome();
            }
            userController.SignIn();
        }

        static private string checkUserEmailAndPassword(string email, string password)
        {
            User user = dBInteraction.FindUserByEmail(email);
            if(user != null && 
                user.Password == password &&
                user.ConfirmedEmail)
            {
                return user.UserId;
            }
            return null;
        }
    }
}