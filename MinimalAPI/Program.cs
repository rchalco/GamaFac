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
    builder.WebHost.ConfigureKestrel((context, serverOptions) =>
    {
        //serverOptions.Listen(IPAddress.Loopback, 5000);
        //serverOptions.Listen(IPAddress.Loopback, 5001, listenOptions =>
        //{
        //    listenOptions.UseHttps("testCert.pfx", "testPassword");
        //});
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

