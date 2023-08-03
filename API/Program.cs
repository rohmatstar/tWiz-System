using API.Contracts;
using API.Data;
using API.Repositories;
using API.Services;
using API.Utilities;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//Add DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TwizDbContext>(options => options.UseSqlServer(connectionString));

// =================================================== Repositories ==================================================== //
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventDocRepository, EventDocRepository>();
builder.Services.AddScoped<IEmployeeParticipantRepository, EmployeeParticipantRepository>();
builder.Services.AddScoped<ICompanyParticipantRepository, CompanyParticipantRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITokenHandlers, TokenHandlers>();
builder.Services.AddScoped<IAccountRoleRepository, AccountRoleRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRegisterPaymentRepository, RegisterPaymentRepository>();
builder.Services.AddScoped<IEventPaymentRepository, EventPaymentRepository>();
builder.Services.AddScoped<ISysAdminRepository, SysAdminRepository>();
// ================================================= End Repositories ==================================================== //

// ===================================================== Services ==================================================== //
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<EventDocService>();
builder.Services.AddScoped<EmployeeParticipantService>();
builder.Services.AddScoped<CompanyParticipantService>();


builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AccountRoleService>();
builder.Services.AddScoped<BankService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<RegisterPaymentService>();
builder.Services.AddScoped<EventPaymentService>();

// add seeder to container
builder.Services.AddTransient<SeederHandler>();

// Add http context accessor
builder.Services.AddHttpContextAccessor();
// Jwt Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.RequireHttpsMetadata = false; // For development, jiak production maka true
           options.SaveToken = true; // untuk mengharuskan menyimpan token di req header
           options.TokenValidationParameters = new TokenValidationParameters()
           {
               ValidateIssuer = true,
               ValidIssuer = builder.Configuration["JWTService:Issuer"],
               ValidateAudience = true,
               ValidAudience = builder.Configuration["JWTService:Audience"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTService:Key"])),
               ValidateLifetime = true,
               ClockSkew = TimeSpan.Zero
           };
       });


builder.Services.AddTransient<IEmailHandler, EmailHandler>(_ => new EmailHandler(
    builder.Configuration["EmailService:SmtpServer"],
    int.Parse(builder.Configuration["EmailService:SmtpPort"]),
    builder.Configuration["EmailService:FromEmailAddress"],
    builder.Configuration["EmailService:FromEmailPassword"]
));

// ==================================================== End Services ==================================================== //



//builder.Services.AddControllers().AddJsonOptions(x =>
//                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

// Swager Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "tWiz",
        Description = "Corporate Event Arrangement System"
    });
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });


});

var app = builder.Build();

// Setup Seeder
/* cara jalankan seeder, ketikan di cli perintah : dotnet run seeddata --project <Path>/<App>.csproj
 * contoh : dotnet run seeddata --project C:\Users\Febrianto\Desktop\final-project\tWiz-System\API\API.csproj
 * 
 */
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeederHandler>();

        // tambahkan sesuai kebutuhan, jika tidak dipakai dicomment saja jangan dihapus
        service.RemoveAllData();
        service.GenerateBanks();
        service.GenerateEventMaster();
        service.GeneratePayments();
          
    }
}


// CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
