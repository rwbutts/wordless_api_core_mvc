const string CORS_CONFIG_PATH = "Kestrel:Cors";

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddConfiguredCors( builder, CORS_CONFIG_PATH );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors();

if ( app.Environment.IsDevelopment() )
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseRouting();
app.UseSwaggerUI();
app.UseDefaultFiles();
app.UseStaticFiles();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints( endpoints => 
     {
          endpoints.MapControllers();
     });
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run();

