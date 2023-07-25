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





builder.Services.AddTransient<IEmailHandler, EmailHandler>(_ => new EmailHandler(
    builder.Configuration["EmailService:SmtpServer"],
    int.Parse(builder.Configuration["EmailService:SmtpPort"]),
    builder.Configuration["EmailService:FromEmailAddress"],
    builder.Configuration["EmailService:FromEmailPassword"]
));

// ==================================================== End Services ==================================================== //




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
builder.Services.AddSwaggerGen(x => {
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
