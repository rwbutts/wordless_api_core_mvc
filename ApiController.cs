using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using WordlessAPI;

namespace WordlessAPI
{
     [ApiController]
     [Route("/")]
     public class ApiController : ControllerBase
     {
          const string HTTP_VER_HEADER = "X-wordless-api-version";

          public ApiController()
          {
          }

          [HttpGet("/healthcheck")]
          public IActionResult HealthCheck()
          { 
               SetApiVersionHeader();
               return Ok( new HealthCheckResponse( true ) );
          }

          [HttpGet("/getword/{daysago}")]
          public IActionResult GetWord( int daysago )
          { 
               SetApiVersionHeader();
               return Ok( new GetWordResponse( Words.TodaysWord( daysago ) ) );
          }

          [HttpGet("/randomword")]
          public IActionResult RandomWord()
          { 
               SetApiVersionHeader();
               return Ok( new GetWordResponse( Words.RandomWord() ) );
          }

          [HttpGet("/checkword/{word}")]
          public IActionResult CheckWord( string word )
          { 
               SetApiVersionHeader();
               return Ok( new WordExistsResponse( Words.WordExists( word ) ) );
          }

          [HttpPost("/querymatchcount")]
          public IActionResult QueryMatchCount( [FromBody] QueryMatchCountRequest request )
          { 
               SetApiVersionHeader();
               return Ok( new QueryMatchCountResponse( Words.CountMatches( Words.wordList, request.Answer, request.Guesses ) ) );
          }

          private void SetApiVersionHeader( )
          {
               Version? apiVersion = Assembly.GetExecutingAssembly().GetName().Version;
               string verHeaderValue = apiVersion?.ToString() ?? "unknown";
               HttpContext.Response.Headers[HTTP_VER_HEADER] = verHeaderValue;
          }
     }
}
