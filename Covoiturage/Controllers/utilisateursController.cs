﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Covoiturage;
using Covoiturage.Models;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace Covoiturage.Controllers
{
    public class utilisateursController : Controller
    {
        private covoiturageEntities db = new covoiturageEntities();
        private static readonly string hash = new Random().Next().ToString();
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["RedaConnectionString"].ConnectionString;

        //SqlConnection con = new SqlConnection();
        //SqlCommand com = new SqlCommand();
        //SqlDataReader dr;


        // GET: utilisateurs
        public ActionResult Index()
        {
            return View(db.utilisateurs.ToList());
        }

        // GET: utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilisateur utilisateur = db.utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        


        // GET: utilisateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: utilisateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUtilisateur,nom,prenom,dateN,sexe,mdp,photo,photoCIN1,photoCIN2,telephone,email,valide,hashCode,presentation")] utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.utilisateurs.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilisateur);
        }

        // GET: utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilisateur utilisateur = db.utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: utilisateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUtilisateur,nom,prenom,dateN,sexe,mdp,photo,photoCIN1,photoCIN2,telephone,email,valide,hashCode,presentation")] utilisateur utilisateur)
        {
            

            if (ModelState.IsValid)
            {
                db.Entry(utilisateur).State = EntityState.Modified;
                db.SaveChanges();
                //return View(utilisateur);
                  return RedirectToAction("Index");
            }
            return View(utilisateur);
        }


        public void ProfilUpdate()
        {
            // Get values from the view
            string nom = Request.Form["Nom"];
            string prenom = Request.Form["Prenom"];
            string email = Request.Form["Email"];
            string sexe = Request.Form["Sexe"];
            string photo = Request.Form["Photo"];
            string telephone = Request.Form["Telephone"];
            string photorecto = Request.Form["Photorecto"];
            string photoverso = Request.Form["Photoverso"];
            DateTime date = Convert.ToDateTime(Request.Form["Date"]);
            string presentation = Request.Form["Presentation"];
            int id = Convert.ToInt32(Request.Form["Id"]);


            // updating values of user
            db.utilisateurs.Find(id).nom = nom;
            db.utilisateurs.Find(id).prenom = prenom;
            db.utilisateurs.Find(id).email = email;
            db.utilisateurs.Find(id).sexe = sexe;
            db.utilisateurs.Find(id).photo = photo;
            db.utilisateurs.Find(id).telephone = telephone;
            db.utilisateurs.Find(id).photoCIN1 = photorecto;
            db.utilisateurs.Find(id).photoCIN2 = photoverso;
            db.utilisateurs.Find(id).presentation = presentation;
            db.utilisateurs.Find(id).dateN = date;


            if (ModelState.IsValid)
            {
                // updating in database
                db.Entry(db.utilisateurs.Find(id)).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public void EditProfile([Bind(Include = "idUtilisateur,nom,prenom,dateN,sexe,mdp,photo,photoCIN1,photoCIN2,telephone,email,valide,hashCode,presentation")] utilisateur utilisateur)
        {
            var id = Request.Form["idUtili"];
            utilisateur = db.utilisateurs.Find(id);

            if (ModelState.IsValid)
            {
                db.Entry(utilisateur).State = EntityState.Modified;
                db.SaveChanges();                
            }
           
        }

        // GET: utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilisateur utilisateur = db.utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            utilisateur utilisateur = db.utilisateurs.Find(id);
            db.utilisateurs.Remove(utilisateur);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        static public string encrypte(string pass, string key)
        {
            byte[] data = System.Text.UTF8Encoding.UTF8.GetBytes(pass);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] resulta = transform.TransformFinalBlock(data, 0, data.Length);
                    string result = Convert.ToBase64String(resulta, 0, resulta.Length);

                    return result;
                }
            }
        }



        static public string dencrypt(string stringDecrpter, string key)
        {
            string str = "";
            byte[] data = Convert.FromBase64String(stringDecrpter);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] resulta = transform.TransformFinalBlock(data, 0, data.Length);
                    str = UTF8Encoding.UTF8.GetString(resulta);
                }
            }

            return str;
        }

        //void connectionString()
        //{
        //    con.ConnectionString = "data source =DESKTOP-Q3F1QCV; initial catalog = covoiturage; integrated security = true;";
        //}

        public ActionResult AddUtilisateur(AccountSignUp acc, FormCollection fc)
        {
            bool found = false;

            foreach (var item in db.utilisateurs)
            {

                if (item.email == acc.Email)
                {
                    ViewBag.c = "block";
                    found = true;
                    //var itemFound = item;
                    break;
                }
            }

            if(found==true)
            {
                //"hnaya khesna ntal3o msg beli deja kayen"
            }

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    string query = "insert into utilisateur (email,nom,prenom,mdp,valide) values (@email,@nom,@prenom,@password,0)";
                    command.CommandText = query;
                    string password = encrypte(acc.Password, "myKey");
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@email",
                        Value = acc.Email
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = acc.Nom.Replace("'", "''")
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@prenom",
                        Value = acc.Prenom.Replace("'", "''")
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@password",
                        Value = password
                    });
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            //connectionString();
            //con.Open();
            //com.Connection = con;

            //com.CommandText = "insert into utilisateur (email,nom,prenom,mdp,valide) values ('" + acc.Email + "','" + acc.Nom.Replace("'", "''") + "','" + acc.Prenom.Replace("'", "''") + "','"  + password + "',0)";
            //com.ExecuteNonQuery();

            using (SmtpClient smtpClient = new SmtpClient("smtp.live.com"))
            {
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("covoiturage-maroc@outlook.com")
                };
                mailMessage.To.Add(acc.Email);
                mailMessage.Subject = "Inscription sur le site de covoiturage en ligne";
                mailMessage.IsBodyHtml = true;
                string htmlBody = "<h1>Inscription</h1> Merci pour votre inscription dans notre site cliquez ou copiez le lien suivant dans votre navigteur <a href='https://localhost:44318/validation?login=" + acc.Email + "&hash=" + hash + "'>https://localhost:44318/validation?login=" + acc.Email + "&hash=" + hash + " </a>votre inscription";
                mailMessage.Body = htmlBody;
                smtpClient.Port = 587; //64   587
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("covoiturage-maroc@outlook.com", "Covoituragemaroc");
                smtpClient.EnableSsl = true;
                try
                {
                    smtpClient.Send(mailMessage);

                }
                catch (Exception)
                {
                    Response.Write("Erreur d'envoi de message");
                }
            }           

            //SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            //var mail = new MailMessage
            //{
            //    From = new MailAddress("covoiturage-maroc@outlook.com")
            //};
            //mail.To.Add(acc.Email);

            //mail.Subject = "Inscription sur le site de covoiturage en ligne";
            //mail.IsBodyHtml = true;
            ////string htmlBody;
            ////htmlBody = "<h1>Inscription</h1> Merci pour votre inscription dans notre site cliquez ou copiez le lien suivant dans votre navigteur <a href='https://localhost:44318/validation?login=" + acc.Email + "&hash=" + hash + "'>https://localhost:44318/validation?login=" + acc.Email + "&hash=" + hash + " </a>votre inscription";
            //mail.Body = htmlBody;
            //SmtpServer.Port = 587; //64   587
            //SmtpServer.UseDefaultCredentials = false;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("covoiturage-maroc@outlook.com", "Covoituragemaroc"); 
            //SmtpServer.EnableSsl = true;
            //try
            //{
            //    SmtpServer.Send(mail);

            //}
            //catch (Exception)
            //{
            //    Response.Write("Erreur d'envoi de message");
            //}


            return View("../Home/MerciIscription");
        }

        [ValidateAntiForgeryToken]
        public ActionResult Profil(Profilinfo utilisateur)
        {
            return View(utilisateur);
        }

        

        public utilisateur utilisateur;


        
        public ActionResult VerifyUtilisateur(AccountLogin acc, FormCollection fc)
        {
            bool found = false;


            foreach (var item in db.utilisateurs)
            {
                string password = dencrypt(item.mdp, "myKey");
                if (item.email == acc.Email && password == acc.Password)
                {
                    found = true;
                    utilisateur = item;
                    
                    break;
                }
            }

            if (found == false)
                return View("../Home/LoginFailed");
            else
            {
                Profilinfo utilis = new Profilinfo
                {
                    nom = utilisateur.nom,
                    prenom = utilisateur.prenom,
                    dateN = utilisateur.dateN,
                    sexe = utilisateur.sexe,
                    mdp = utilisateur.mdp,
                    photo = utilisateur.photo,
                    photoCIN1 = utilisateur.photoCIN1,
                    photoCIN2 = utilisateur.photoCIN2,
                    telephone = utilisateur.telephone,
                    email = utilisateur.email,
                    valide = utilisateur.valide,
                    hashCode = utilisateur.hashCode,
                    presentation = utilisateur.presentation,
                    idUtilisateur = utilisateur.idUtilisateur
                };

                Session["passport"] = "oui";
                return View("Profil",utilis);
            }
        }
    }
}
