using Demo.Website.Data;

using Microsoft.EntityFrameworkCore;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc().AddRazorPagesOptions(v =>
{
	v.Conventions.AddPageRoute("/Employees", "");
});

builder.Services.AddDbContext<AppDbContext>(opts =>
{
	var conn = builder.Configuration.GetConnectionString("DefaultConnection");
	opts.UseSqlServer(conn);
});

builder.Services.AddLogging(v =>
{
	//remove the logging providers created by WebApplication.CreateBuilder and add our own providers
	v.ClearProviders();
	v.AddDebug();

	if (OperatingSystem.IsWindows())
		v.AddEventLog();
});

builder.Services.AddSerilog(configuration =>
{
	configuration.ReadFrom.Configuration(builder.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
{
	if (context.Database.IsSqlServer())
		await context.Database.MigrateAsync();
}

app.UseSwagger(c =>
{
    c.RouteTemplate = "api/swagger/{documentname}/swagger.json";
});

app.UseSwaggerUI(options =>
{
    options.RoutePrefix = "api/swagger";
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();