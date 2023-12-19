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

          [HttpGet("/getword/{daysago}")]
          public GetWordResponse GetWord( int daysago )
          { 
               SetApiVersionHeader();
               return Words.TodaysWord( daysago );
          }

          [HttpGet("/randomword")]
          public IActionResult RandomWord()
          { 
               SetApiVersionHeader();
               return Ok( Words.RandomWord() );
          }

          [HttpGet("/checkword/{word}")]
          public IActionResult CheckWord( string word )
          { 
               SetApiVersionHeader();
               return Ok( Words.WordExists( word ) );
          }

          [HttpPost("/querymatchcount")]
          public IActionResult QueryMatchCount( [FromBody] QueryMatchCountRequest request )
          { 
               SetApiVersionHeader();
               return Ok( Words.CountMatches( Words.wordList, request.answer, request.guesses ) );
          }

          private void SetApiVersionHeader( )
          {
               Version? apiVersion = Assembly.GetExecutingAssembly().GetName().Version;
               string verHeaderValue = apiVersion?.ToString() ?? "unknown";
               HttpContext.Response.Headers.Add( HTTP_VER_HEADER, verHeaderValue );
          }
     }

     public record QueryMatchCountRequest( string answer, string[] guesses );

}