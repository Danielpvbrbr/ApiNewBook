using ApiNewBook.Contexts;
using ApiNewBook.DTOs.Mappings;
using ApiNewBook.Filter;
using ApiNewBook.Repository.BookRepositories;
using ApiNewBook.Repository.CategoryRepositories;
using ApiNewBook.Repository.LanguageRepositories;
using ApiNewBook.Services.AuthService;
using ApiNewBook.Services.AuthServices;
using ApiNewBook.Services.PasswordService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opts=>
{
    opts.Filters.Add(typeof(ExceptionFilter));
});

builder.Services.AddCors(ops =>
{
    ops.AddPolicy("AllowApiRequest",  builder => builder.WithOrigins("http://localhost:5173/").WithMethods("GET"));
});

//Cors sem restrição
builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(ops =>
{
    ops.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateAudience = false,
        ValidateIssuer = false

    };
});

//-----------------------------------------------------------------------------------------------------
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "apinewbook", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Header de autorização JWT usando o esquema Bearer.\r\n\r\nInforme 'Bearer'[espaço] e o token. \r\n\r\n'Examplo: \'Bearer 122345abcdef\'",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                         new string[] {}
                    }
                });
    });

//-----------------------------------------------------------------------------------------------------
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(conn, ServerVersion.AutoDetect(conn)));

builder.Services.AddScoped<IBookRepository, BookRepositories>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepositories>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepositories>();

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IPasswordService, PasswordService>();

//-----------------------------------------------------------------------------------------------------
builder.Services.AddAutoMapper(typeof(DTOsMapping));

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//Produção restrição
//app.UseCors(opt => opt.WithOrigins("http://localhost:5173/").WithMethods("GET"));

//Libera todos
app.UseCors(opt => opt.AllowAnyOrigin());
app.Run();
