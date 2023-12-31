using System.ComponentModel.DataAnnotations;
namespace WordlessAPI
{
     public record QueryMatchCountRequest( 
          [MaxLength(5), MinLength(5)] string Answer, 
          string[] Guesses 
     );
}
 