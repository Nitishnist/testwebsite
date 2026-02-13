var builder = WebApplication.CreateBuilder(args);

// ✅ Force Kestrel to use Railway's port
builder.WebHost.ConfigureKestrel(options =>
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
    options.ListenAnyIP(int.Parse(port));
});

// Add Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Production settings
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// ⚠️ DO NOT enable HTTPS redirection on Railway
// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

// ✅ VERY IMPORTANT — Default route
app.MapGet("/", async context =>
{
    context.Response.Redirect("/Index");
});

// Map Razor pages
app.MapRazorPages();

app.Run();
