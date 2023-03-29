using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SeguroAutoAPI.DataAccess.Context;
using SeguroAutoAPI.DI;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Agrega las configuraciones del archivo appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Configura el DbContext
builder.Services.AddDbContext<SeguroAutoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SeguroAutoDatabase")));

// Configura la autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Configura las políticas de autorización
builder.Services.AddAuthorization();

// Agrega los controladores y las acciones de la API
builder.Services.AddControllers();

// Configura Swagger para generar documentación de la API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Seguro Auto API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autenticación JWT usando el esquema Bearer. Ingrese 'Bearer' [espacio] y luego su token en el campo de texto a continuación.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
            new List<string>()
        }
    });
});

// Configura los servicios
DependencyInjection.AddServices(builder.Services);

var app = builder.Build();

// Usa Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Seguro Auto API v1"));
}

// Usa la autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Configura el enrutamiento y los endpoints
app.MapControllers();

app.Run();

