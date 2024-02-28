using _036_Les.DB;
using _036_V2_Les.DB.Repositories;
using _036_V2_Les.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// add routing
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// add db context
builder.Services.AddDbContext<AppDbContext>();

// add repositoriries
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IMainFolderRepository, MainFolderRepository>();

// add services
builder.Services.AddScoped<IPathReadService, PathReadService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
