using Hunting_App_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Firebase.Auth;
using Newtonsoft.Json;

namespace Hunting_App_System.Controllers
{
    public class HomeController : Controller 
    {
        private readonly ILogger<HomeController> _logger;

        FirebaseAuthProvider _firebaseAuth;

        public HomeController(ILogger<HomeController> logger) 
        {
            _logger = logger;
            _firebaseAuth = new FirebaseAuthProvider(new FirebaseConfig("\r\nAIzaSyA5gNssPfDr3l1PZwY6ntjCm0ZxmY10Xuo"));
        }

        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> RegisterUser(LoginModel vm) 
        {
            try
            {
                await _firebaseAuth.CreateUserWithEmailAndPasswordAsync(vm.EmailAddress, vm.Password);

                var fribaselink = await _firebaseAuth.SignInWithEmailAndPasswordAsync(vm.EmailAddress, vm.Password);
                string accestoken = fribaselink.FirebaseToken;
                if (fribaselink != null) {

                    HttpContext.Session.SetString("AccessToken", accestoken);
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(vm);
                }
                return View(vm);

            }
            catch (FirebaseAuthException e)
            {
                var firebase = JsonConvert.DeserializeObject<ErrorModel>(e.RequestData);
                ModelState.AddModelError(string.Empty, firebase.message);
                return View(vm);
            }
        }
        public IActionResult Privacy() 
        {
            return View();
           
        }
        public IActionResult Error() 
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            throw new NotImplementedException();
        }
    }
}
