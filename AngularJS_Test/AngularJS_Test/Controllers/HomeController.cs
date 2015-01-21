using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AngularJS_Test.Models;

namespace AngularJS_Test.Controllers
{
    public class HomeController : Controller
    {
        public mySqlRemote remoteSql = new mySqlRemote();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestMySql()
        {
            remoteSql.mySqlConnect();
            return View("Test", remoteSql.mConn);
        }
    }
}
