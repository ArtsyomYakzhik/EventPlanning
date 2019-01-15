using EventPlanning.Controllers;
using EventPlanning.Models.DB.Interaction;
using EventPlanning.Models.DB.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Security.Policy;

namespace EventPlanning.Models.ElementControl
{
    static public class UserControl
    {
        static private DBInteraction dBInteraction = new DBInteraction();

        static public bool userAuthenticication(UserController userController, User user)
        {
            string userId = checkUserEmailAndPassword(user.Email, user.Password);
            if (userId != null)
            {
                userController.Session["UserId"] = userId;
                return true;
            }
            userController.ViewBag.Status = "Incorrect email or password.";
            return false;
        }

        static private string checkUserEmailAndPassword(string email, string password)
        {
            User user = dBInteraction.FindUserByEmail(email);
            if (user != null &&
                user.Password == password &&
                user.ConfirmedEmail)
            {
                return user.UserId;
            }
            return null;
        }

        static public string userRegistration(UserController userController, User user)
        {
            if (checkUserFields(user))
            {
                dBInteraction.CreateUser(user.Name, user.Email, user.Password);
                sendEmailToUser(user, userController);
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

        static private void sendEmailToUser(User user,UserController userController)
        {
            user = dBInteraction.FindUserByEmail(user.Email);
            MailAddress from = new MailAddress("testconfirmation25@gmail.com", "Web Registration");
            MailAddress to = new MailAddress(user.Email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Email confirmation";
            m.Body = string.Format("Для завершения регистрации перейдите по ссылке:" +
                            "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
                userController.Url.Action("ConfirmEmail", "User", new { Token = user.UserId, user.Email }, userController.Request.Url.Scheme));
            m.IsBodyHtml = true;
            SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("testconfirmation25@gmail.com", "A123456ABC");
            smtp.Send(m);
        }

        static public void confirmEmail(string token, string email)
        {
            User user = dBInteraction.FindUserByEmail(email);
            if(dBInteraction.FindUser(token) != null)
            {
                if (user != null)
                {
                    dBInteraction.SetEmailConfirm(user.UserId);
                    dBInteraction.FindUserByEmail(email);
                }
            }
        }
    }
}