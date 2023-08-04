using Client.Contracts;
using Client.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped(typeof(IRepository<,>), typeof(GeneralRepository<,>));
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
/*builder.Services.AddScoped<IEventRepository, EventRepository>();*/
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWTService:Audience"],
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWTService:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTService:Key"])),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors(options => { options.AllowAnyOrigin(); options.AllowAnyHeader(); options.AllowAnyMethod(); });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Custom Error Page
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode.Equals((int)HttpStatusCode.Unauthorized))
    {
        response.Redirect("/Error/Unauthorize");
    }
    else if (response.StatusCode.Equals((int)HttpStatusCode.NotFound))
    {
        response.Redirect("/Error/Notfound");
    }
    else if (response.StatusCode.Equals((int)HttpStatusCode.Forbidden))
    {
        response.Redirect("/Error/Forbidden");
    }
    else if (response.StatusCode.Equals((int)HttpStatusCode.MethodNotAllowed))
    {
        response.Redirect("/Error/MethodNotAllowed");
    }
    else if (response.StatusCode.Equals((int)HttpStatusCode.InternalServerError))
    {
        response.Redirect("/Error/InternalServerError");
    }
});

app.UseSession();

//Add JWToken to all incoming HTTP Request Header
app.Use(async (context, next) =>
{   
    // Disable cache to prevent reaccess page after sign out
    context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "0";

    var JWToken = context.Session.GetString("JWTToken");
    if (!string.IsNullOrEmpty(JWToken))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
    }

    await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

