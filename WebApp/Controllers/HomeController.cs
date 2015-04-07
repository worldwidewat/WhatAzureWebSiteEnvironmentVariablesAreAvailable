using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            var viewModel = new HomeViewModel();
            
            var environmentVariables = Environment.GetEnvironmentVariables();
            viewModel.EnvironmentVariables = environmentVariables.Keys.OfType<string>()
                .Select(k=>new KeyValuePair<string, string>(k, environmentVariables[k].ToString()));

            var appSettings = ConfigurationManager.AppSettings;
            viewModel.AppSettings = appSettings.Keys.OfType<string>()
                .Select(k => new KeyValuePair<string, string>(k, appSettings[k]));

            var connectionStrings = ConfigurationManager.ConnectionStrings;
            viewModel.ConnectionStrings = connectionStrings.OfType<string>()
                .Select(n => new KeyValuePair<string, string>(n, connectionStrings[n].ConnectionString));

            return View(viewModel);
        }


    }
}