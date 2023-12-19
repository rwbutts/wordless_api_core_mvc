using System.ComponentModel.DataAnnotations;
namespace WordlessAPI
{
     public record QueryMatchCountRequest
     {
          public string answer { get; set;}

          public string[] guesses { get; set;}

          public QueryMatchCountRequest( [MaxLength(5), MinLength(5)] string answer, string[] guesses )
          {
               this.guesses = guesses;
               this.answer = answer;
          }
     }
}
 