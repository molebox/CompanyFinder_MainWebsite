using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Competence.Controllers
{
    /// <summary>
    /// Status code controller used to show custom error views
    /// </summary>
    public class StatusCodeController : Controller
    {
        /// <summary>
        /// Method to show the status code view
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        [HttpGet("/StatusCode/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            return View(statusCode);
        }
    }
}