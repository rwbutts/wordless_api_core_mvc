namespace WordlessAPI
 {
     public record GetWordResponse( string Word );
     public record WordExistsResponse( bool Exists );
     public record QueryMatchCountResponse( int Count );
     public record HealthCheckResponse( bool Healthy );

 }
