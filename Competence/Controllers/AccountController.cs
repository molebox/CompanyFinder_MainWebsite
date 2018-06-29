using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Competence.Models;
using Competence.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Competence.Controllers
{
    /// <summary>
    /// Account controller used to responed to login requests
    /// </summary>
    //[Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManger;
        private SignInManager<IdentityUser> signInManager;
        private IConfiguration _configuration;

        /// <summary>
        /// Constructor to set the properties
        /// </summary>
        /// <param name="userMgr"></param>
        /// <param name="signInMgr"></param>
        /// <param name="Configuration"></param>
        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr, IConfiguration Configuration)
        {
            userManger = userMgr;
            signInManager = signInMgr;
            _configuration = Configuration;
        }

        // Get the api base url from the appsetting.json
        private string ApiBaseUrl
        {
            get
            {
                return _configuration["Data:UrlSettings:ApiBaseUrl"];
            }
        }

        /// <summary>
        /// Home page login method, allow anonymous indicates that authorization does not appy to this method
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        public async Task<ViewResult> HomePageLogin(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            //var homepageInfo = _repository.GetHomePageInfo();  
            var homePageViewModel = new HomePageViewModel();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(ApiBaseUrl);

                var response = new HttpResponseMessage();

                response = client.GetAsync("api/gethomepage").Result;

                var responseString = await response.Content.ReadAsStringAsync();
                homePageViewModel = JsonConvert.DeserializeObject<HomePageViewModel>(responseString, Converter.Settings);
            }

            if (homePageViewModel != null)
            {
                var tagline = homePageViewModel.Tagline;
                return View(new HomePageViewModel { ReturnUrl = returnUrl, Tagline = homePageViewModel.Tagline });
            }
            else
            {
                var tagline = "We've got you covered";
                return View(new HomePageViewModel { ReturnUrl = returnUrl, Tagline = tagline });
            }

        }
        /// <summary>
        /// Post method that checks the login for access to the search page. If login is good then the user is redirected to the search oage, if the login
        /// is bad an error message is displayed
        /// </summary>
        /// <param name="homePageViewModel"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HomePageLogin(HomePageViewModel homePageViewModel, string returnUrl)
        {
            var response = new HttpResponseMessage();
            IdentityUser user;


            if (ModelState.IsValid)
            {

                homePageViewModel.ReturnUrl = returnUrl;
                var dataToSend = new StringContent(JsonConvert.SerializeObject(homePageViewModel), Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(ApiBaseUrl);

                    response = client.PostAsync("api/homepagelogin", dataToSend).Result;

                    var responseString = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<IdentityUser>(responseString, Converter.Settings);
                }

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View(homePageViewModel);
                }
                if ((await signInManager.PasswordSignInAsync(user, homePageViewModel.SearchPassword, false, false)).Succeeded)
                {
                    return RedirectToAction("Search", "Companies");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View(homePageViewModel);
                }
            }
            return View(homePageViewModel);
        }

        /// <summary>
        /// Logout method to close the session
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}