//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Net.Http.Headers;

//namespace IntegrateKeycloak.MVC.Controllers
//{
//    public class UserController : Controller
//    {
//        private readonly HttpClient _httpClient;

//        public UserController(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var token = HttpContext.Request.Cookies["AccessToken"];

//            if (token != null)
//            {
//                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

//                var response = await _httpClient.GetAsync("https://localhost:7034/api/user/dashboard");
//                if (response.IsSuccessStatusCode)
//                {
//                    var data = await response.Content.ReadAsStringAsync();
//                    ViewBag.UserData = data;
//                }
//                else
//                {
//                    ViewBag.UserData = "Erreur lors de la récupération des données";
//                }
//            }
//            else
//            {
//                ViewBag.UserData = "Token introuvable.";
//            }

//            return View();
//        }
//    }
//}
