using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Competence.Models;
using Competence.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Competence.Browsers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace Competence.Controllers
{
    /// <summary>
    /// Company Controller. Handles the main website views.
    /// </summary>
    public class CompaniesController : Controller
    {
        private IConfiguration _configuration;
        private readonly IStringLocalizer<CompaniesController> _localizer;

        /// <summary>
        /// Sets page size for the company match view for use with pagination
        /// </summary>
        public int PageSizeMatch = 5;

        /// <summary>
        /// Company Controller constructor. Gets the context from the repo, also gets the context directly for use in certain methods
        /// </summary>
        /// <param name="Configuration"></param>
        /// <param name="localizer"></param>
        public CompaniesController(IConfiguration Configuration, IStringLocalizer<CompaniesController> localizer)
        {
            _configuration = Configuration;
            _localizer = localizer;

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
        /// GET to load the home page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> HomePageAsync(string returnUrl, string userAgent)
        {
            // Check the browsers compatability, if the browser is Internet Explorer/Edge then show error page
            if (string.IsNullOrEmpty(userAgent))
            {
                userAgent = Request.Headers["User-Agent"];

                ViewBag.userAgent = userAgent;

                UserAgent ua = new UserAgent(userAgent);

                if (ua.Browser.Name == "MSIE" || ua.Browser.Name == "IE" || ua.Browser.Name == "edge")
                {
                    return View("BrowserSupport");
                }
            }

            ViewBag.returnUrl = returnUrl;
            var homePageViewModel = new HomePageViewModel();
            var homepageInfo = new HomePage();

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
                return View(homePageViewModel);
            }
            else
            {
                var tagLine = new HomePage
                {
                    TagLine = "We've got you covered"
                };

                homePageViewModel.Tagline = tagLine.TagLine;

                return View(homePageViewModel);
            }

        }

        /// <summary>
        /// The apps main page where the user does its search
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = "RequireUserLoginAccess")]
        public IActionResult Search()
        {
            return View();
        }

        #region MAIN SEARCH

        /// <summary>
        /// Gets all the skills, programming languages and company focuses from the db via the repo and returns them to the view.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetTreeNodesAsync(string query)
        {
            // Tree nodes from db
            List<TreeNodes> treeNodes;
            // Tree nodes view model
            List<TreeNodesViewModel> treeNodesViewModel;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(ApiBaseUrl);

                var response = new HttpResponseMessage();

                response = client.GetAsync("api/gettreenodes").Result;

                var responseString = await response.Content.ReadAsStringAsync();
                treeNodes = JsonConvert.DeserializeObject<List<TreeNodes>>(responseString, Converter.Settings);
            }


            if (!string.IsNullOrWhiteSpace(query))
            {
                treeNodes = treeNodes.Where(q => q.Name.Contains(query)).ToList();
            }

            treeNodesViewModel = treeNodes.Where(l => l.ParentId == null)
                    .Select(l => new TreeNodesViewModel
                    {
                        Text = l.Name,
                        Id = l.Id,
                        ParentId = l.ParentId,
                        Nodes = GetRolesChildren(treeNodes, l.Id)
                    }).ToList();

            return Json(treeNodesViewModel);

        }

        /// <summary>
        /// Gets all the company focuses from the db via the repo and returns them to the view.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetFocusNodesAsync(string query)
        {
            List<FocusNodes> focusNodes;
            List<FocusNodeViewModel> focusNodesViewModel;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(ApiBaseUrl);

                var response = new HttpResponseMessage();

                response = client.GetAsync("api/getfocusnodes").Result;

                var responseString = await response.Content.ReadAsStringAsync();
                focusNodes = JsonConvert.DeserializeObject<List<FocusNodes>>(responseString, Converter.Settings);
            }

            if (!string.IsNullOrWhiteSpace(query))
            {
                focusNodes = focusNodes.Where(q => q.Name.Contains(query)).ToList();
            }

            focusNodesViewModel = focusNodes.Where(l => l.ParentId == null)
                    .Select(l => new FocusNodeViewModel
                    {
                        Text = l.Name,
                        Id = l.Id,
                        ParentId = l.ParentId,
                        Nodes = GetFocusChildren(focusNodes, l.Id)
                    }).ToList();

            return Json(focusNodesViewModel);
        }

        private List<TreeNodesViewModel> GetRolesChildren(List<TreeNodes> nodes, int parentId)
        {
            return nodes.Where(l => l.ParentId == parentId).OrderBy(l => l.OrderNumber)
                .Select(l => new TreeNodesViewModel
                {
                    Text = l.Name,
                    Id = l.Id,
                    ParentId = l.ParentId,
                    Nodes = GetRolesChildren(nodes, l.Id)
                }).ToList();
        }

        private List<FocusNodeViewModel> GetFocusChildren(List<FocusNodes> nodes, int parentId)
        {
            return nodes.Where(l => l.ParentId == parentId).OrderBy(l => l.OrderNumber)
                .Select(l => new FocusNodeViewModel
                {
                    Text = l.Name,
                    Id = l.Id,
                    ParentId = l.ParentId,
                    Nodes = GetFocusChildren(nodes, l.Id)
                }).ToList();
        }


        /// <summary>
        /// Gets the posted checkbox selections and sends them to the repo which then checks the db for the matches. The matches are then placed in a static list.
        /// </summary>
        /// <param name="searchSelectionsViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Policy = "RequireUserLoginAccess")]
        public async Task<JsonResult> SearchResultsAsync([FromBody]SearchSelectionsViewModel searchSelectionsViewModel)
        {
            var searchResults = new List<SearchResultsViewModel>();
            var dataToSend = new StringContent(JsonConvert.SerializeObject(searchSelectionsViewModel), Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(ApiBaseUrl);

                var response = new HttpResponseMessage();

                response = client.PostAsync("api/search", dataToSend).Result;


                var responseString = await response.Content.ReadAsStringAsync();
                searchResults = JsonConvert.DeserializeObject<List<SearchResultsViewModel>>(responseString, Converter.Settings);

                return Json(searchResults);
            }


        }
        #endregion

        /// <summary>
        /// Sets the languge
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                //"Preferences",
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }


}
