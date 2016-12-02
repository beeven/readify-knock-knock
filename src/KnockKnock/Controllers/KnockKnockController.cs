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
        private readonly IFibonacciService _fibonacciService;
        private readonly IReverseWordsService _reverseWordsService;
        private readonly ITriangleTypeService _triangleTypeService;
        public KnockKnockController(IFibonacciService fibonacciService,IReverseWordsService reverseWordsService, ITriangleTypeService triangleTypeService)
        {
            _fibonacciService = fibonacciService;
            _reverseWordsService = reverseWordsService;
            _triangleTypeService = triangleTypeService;
        }

        [ResponseCacheAttribute(Location=ResponseCacheLocation.Any,Duration=60)]
        [HttpGet]
        public IActionResult Fibonacci([FromQuery]int n)
        {
            try
            {
                return Json(_fibonacciService.GetFibonacciNumberAt(n));
            }
            catch(ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        public IActionResult Token()
        {
            return Json("d644cc6a-114b-43ee-9503-13ddca467836");
        }



        [HttpGet]
        public IActionResult ReverseWords([FromQuery]string sentence)
        {
            return Json(_reverseWordsService.ReverseWords(sentence));
        }
        

        [HttpGet]
        public IActionResult TriangleType(int a, int b, int c)
        {
            return Json(_triangleTypeService.GetTriangleType(a,b,c).ToString());
        }

        
        [Route("/api/{*method}")]
        [HttpGet]
        public IActionResult NotSupported()
        {
            return NotFound(new {message=$"No HTTP resource was found that matches the request URI '{ Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Request) }'."});
        }

    }
}
