using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KnockKnock.Services;

namespace KnockKnock.Controllers
{
    [Route("api/[action]")]
    public class KnockKnockController : Controller
    {
        private readonly FibonacciService fSvc;
        private readonly ReverseWordsService rwSvc;
        private readonly TriangleTypeService ttSvc;
        public KnockKnockController(FibonacciService fSvc,ReverseWordsService rwSvc, TriangleTypeService ttSvc)
        {
            this.fSvc = fSvc;
            this.rwSvc = rwSvc;
            this.ttSvc = ttSvc;
        }

        [ResponseCacheAttribute(Location=ResponseCacheLocation.Any,Duration=60)]
        [HttpGet]
        public IActionResult Fibonacci([FromQuery]int n)
        {
            try
            {
                return Json(fSvc.GetFibonacciAt(n));
            }
            catch(ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        public IActionResult Token()
        {
            return Json("f0042d62-3ff2-44d0-81fe-5d1103647aee");
        }



        [HttpGet]
        public IActionResult ReverseWords([FromQuery]string sentence)
        {
            //System.Console.WriteLine(System.Net.WebUtility.UrlDecode(sentence));
            return Json(rwSvc.ReverseWords(sentence));
        }
        

        [HttpGet]
        public IActionResult TriangleType(int a, int b, int c)
        {
            return Json(ttSvc.GetTriangelTypeString(a,b,c));
        }

        
        [Route("/api/{*method}")]
        [HttpGet]
        public IActionResult NotSupported()
        {
            return NotFound(new {message=$"No HTTP resource was found that matches the request URI '{ Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Request) }'."});
        }

    }
}
