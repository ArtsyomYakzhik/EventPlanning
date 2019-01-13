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

        static public void userAuthenticication(UserController userController, User user)
        {
            string userId = checkUserEmailAndPassword(user.Email, user.Password);
            if (userId != null)
            {
                userController.Session["UserId"] = userId;
                userController.UserHome();
            }
            userController.ViewBag.Status = "Incorrect email or password.";
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

        static public string userRegistration(UserController userController, User user)
        {
            if(checkUserFields(user))
            {
                dBInteraction.CreateUser(user.Name, user.Email, user.Password);
                userController.ViewBag.Status = "Successfully creating of account, please confirm it on your email.";
                return "SignIn";
            }
            userController.ViewBag.Status = "Creating failed, current user is already exists.";
            return "SignUp";
        }

        static private bool checkUserFields(User user)
        {
            if (dBInteraction.FindUserByEmail(user.Email) == null)
            {
                return true;
            }
            return false;
        }
    }
}