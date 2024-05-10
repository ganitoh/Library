using Library.Application;
using Library.Persistance.Services;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuraion = builder.Configuration;

#region registration services
services.AddControllers();
services.AddSwaggerGen();
services.AddPostgreSql(
    configuraion["ConnecitonStrring:PostgreSQl"]!);
services.AddApplicationServices();
services.AddPersistanceServices();

#endregion

var app = builder.Build();

#region use middleware
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseDefaultFiles(new DefaultFilesOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),
});
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),
    RequestPath = "",
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.TryAdd("Cache-Control", "public,max-age=600");
    }

});
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
//app.MapControllerRoute(name: "admin", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


#endregion

app.Run();
