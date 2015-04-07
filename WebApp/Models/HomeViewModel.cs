using System.Collections.Generic;

namespace WebApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<KeyValuePair<string, string>> EnvironmentVariables { get; set; }
        public IEnumerable<KeyValuePair<string, string>> ConnectionStrings { get; set; }
        public IEnumerable<KeyValuePair<string, string>> AppSettings { get; set; } 
    }
}