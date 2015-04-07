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

            viewModel.RandomItems = new[]
            {
                new KeyValuePair<string, string>("Request.IsLocal", Request.HttpMethod),
                new KeyValuePair<string, string>("Request.IsLocal", Request.IsLocal.ToString()),
                new KeyValuePair<string, string>("Request.IsLocal", Request.IsSecureConnection.ToString()),
                new KeyValuePair<string, string>("Request.IsSecureConnection", Request.IsSecureConnection.ToString()),
                new KeyValuePair<string, string>("Request.RawUrl", Request.RawUrl),
                new KeyValuePair<string, string>("Request.UserHostAddress", Request.UserHostAddress)
            };

            var environmentVariables = Environment.GetEnvironmentVariables();
            viewModel.EnvironmentVariables = environmentVariables.Keys.OfType<string>()
                .Select(k=>new KeyValuePair<string, string>(k, environmentVariables[k].ToString()));

            var appSettings = ConfigurationManager.AppSettings;
            viewModel.AppSettings = appSettings.Keys.OfType<string>()
                .Select(k => new KeyValuePair<string, string>(k, appSettings[k]));

            var headers = Request.Headers;
            viewModel.Headers = headers.OfType<string>()
                .Select(h => new KeyValuePair<string, string>(h, headers[h]));

            var cookies = Request.Cookies;
            viewModel.Cookies = cookies.OfType<string>()
                .Select(c => new KeyValuePair<string, HttpCookie>(c, cookies[c]));

            return View(viewModel);
        }


    }
}