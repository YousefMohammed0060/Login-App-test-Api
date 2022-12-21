using Login_App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Login_App.Controllers
{
    public class HomeController : Controller
    {
        Users user;
        List<Users> result;
        Uri BASE_URL = new Uri("https://localhost:7228/");
        HttpClient client;
        HttpResponseMessage responseMessage;

        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = BASE_URL;
            responseMessage = client.GetAsync(BASE_URL + "api/users").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<Users>>(data);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string userName, string password)
        {
            foreach (var item in result)
            {
                if (item.UserName.Equals(userName) && item.Password.Equals(password))
                {
                    return View(item);
                }
            }
            return View("NotFound");
        }

    }
}