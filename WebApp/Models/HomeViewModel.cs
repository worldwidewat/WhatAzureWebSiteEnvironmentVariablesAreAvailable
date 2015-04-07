using System.Collections.Generic;
using System.Configuration;
using System.Web;

namespace WebApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<KeyValuePair<string, string>> EnvironmentVariables { get; set; }
        public IEnumerable<KeyValuePair<string, string>> AppSettings { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Headers { get; set; }
        public IEnumerable<KeyValuePair<string, HttpCookie>> Cookies { get; set; }
        public IEnumerable<KeyValuePair<string,string>> RandomItems { get; set; }
    }
}