using MPOS.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPOS.Controllers
{
    public class UsersController : Controller
    {
        private MPOSConStr db = new MPOSConStr();
        Common com = new Common();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignIn(int? MPOSSignIn)
        {
            if (MPOSSignIn == null)
            {
                Session["URL"] = "NoMPOSSignIn";
            }
            else
            {
                Session["URL"] = "MPOSSignIn";
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult SignIn([Bind (Include ="Username, Password")] User user)
        {
            if (ModelState.IsValid)
            {
                DataSet dsUser = new DataSet();
                dsUser = com.ReturnDataSet("SELECT Username, Password, FactoryId, ID FROM Users WHERE Username ='" + user.Username + "'");
                //string absoluteurl = HttpContext.Request.Url.AbsoluteUri;
                var controller = ControllerContext.RouteData.Values["controller"].ToString();
               

                if (Session["URL"].ToString().Equals("MPOSSignIn"))
                {
                    if (dsUser.Tables[0].Rows.Count > 0)
                    {
                        Session["username"] = user.Username;
                        Session["factoryId"] = dsUser.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
                        Session["UserId"] = dsUser.Tables[0].Rows[0].ItemArray.GetValue(3).ToString();
                        DataSet dsFactory = new DataSet();
                        int FacId = int.Parse(Session["factoryId"].ToString());
                        dsFactory = com.ReturnDataSet("SELECT ID, Code FROM Factories WHERE ID =" + FacId + "");
                        Session["FactoryName"] = dsFactory.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();

                        Session.Timeout = 46800;
                        return RedirectToAction("MPOS", "ItemPurchases");
                    }
                    else
                    {
                        ViewBag.Message = "Incorrect Factory Name";
                        return View();
                    }
                }
                else
                {
                    if (dsUser.Tables[0].Rows.Count > 0)
                    {
                        Session["username"] = user.Username;
                        Session["factoryId"] = dsUser.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
                        Session["UserId"] = dsUser.Tables[0].Rows[0].ItemArray.GetValue(3).ToString();
                        DataSet dsFactory = new DataSet();
                        int FacId = int.Parse(Session["factoryId"].ToString());
                        dsFactory = com.ReturnDataSet("SELECT ID, Code FROM Factories WHERE ID =" + FacId + "");
                        Session["FactoryName"] = dsFactory.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();

                        Session.Timeout = 46800;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Incorrect Factory Name";
                        return View();
                    }
                }
                
            }
            return View();
        }


    }
}