using PlumbingProps.Config;

///Configuration host
var MyAllowSpecificOrigins = "MyPolicy";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                      });
});

if (ConfigManager.GetConfiguration().GetSection("mode").Value.Equals("server"))
{
    builder.Host.ConfigureWebHostDefaults(webBuilder =>
    {
        if (ConfigManager.GetConfiguration().GetSection("mode").Value.Equals("server"))
        {
            webBuilder.UseUrls(ConfigManager.GetConfiguration().GetSection("star_url").Value);
        }
    });
}
builder.Services.AddControllers();

///Configuration application
var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());
app.Run();

