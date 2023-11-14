using ChuongTrinhDaoTao.WebMVC.Services;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTao.WebMVC.Utilyty;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();


builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<IFacultyService, FacultyService>();
builder.Services.AddHttpClient<IMajorService, MajorService>();
builder.Services.AddHttpClient<ICohortService, CohortService>();
builder.Services.AddHttpClient<IBlockOfKnowledgeService, BlockOfKnowledgeService>();
builder.Services.AddHttpClient<ICohortMajorService, CohortMajorService>();
builder.Services.AddHttpClient<ICourseService, CourseService>();
builder.Services.AddHttpClient<IBlockOfKnowledgeCourseService, BlockOfKnowledgeCourseService>();
SD.ApiBase = builder.Configuration["ServiceUrls:WebApi"];


builder.Services.AddScoped<IBlockOfKnowledgeCourseService, BlockOfKnowledgeCourseService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICohortMajorService, CohortMajorService>();
builder.Services.AddScoped<IBlockOfKnowledgeService, BlockOfKnowledgeService>();
builder.Services.AddScoped<ICohortService, CohortService>();
builder.Services.AddScoped<IMajorService, MajorService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFacultyService, FacultyService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(10);
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
});

var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

