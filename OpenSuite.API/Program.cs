using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OpenSuite.API.Configs.Extensions;
using OpenSuite.API.Extensions;
using OpenSuite.API.Middleware;
using OpenSuite.API.Tools.Responses;
using Shared.JWT;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Inyeccion de dependencias


// Configuracion de base de datos
builder.Services.AddDatabase(builder.Configuration);
// Configuracion de negocio
builder.Services.AddBusiness();
// Configuracion de herramientas
builder.Services.AddTools();
// Configuracion de mapeos
builder.Services.AddMappers();

// anadir documentacion de api: scalar y swagger
builder.Services.AddSwaggerDocumentation();
builder.Services.AddScalarDocumentation();

//
builder.Services.AddCustomCors(); // lo usara maxwel para conectarse desde su front, sera un "para mientras"

// Configuracion de JWT
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("AuthConfigurationKey"));
builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddJwtAuthentication(builder.Configuration);




//
var app = builder.Build();

// Usar CORS antes de MapControllers
app.UseCors("AllowAngular");

// Middlewares
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<PermissionMiddleware>();


app.UseSwaggerDocumentation(); // Swagger disponible en /swagger
app.UseScalarDocumentation();  // Scalar como página inicial

app.MapControllers();
app.Run();




















//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Scalar.AspNetCore;

//using Datos.EF.Context;
//using OpenSuite.API.Tools.Responses;
//using Negocio.Modulos.Finanzas.PlanCuentas;
//using Datos.ADO;
//using Negocio.Modulos.Catalogos;
//using Negocio.Modulos.Configuraciones.Empresas;
//using Negocio.Tools.Encriptacion;
//using OpenSuite.API.Tools.Encrypt;
//using Negocio.Modulos.Seguridad.Usuarios;
//using Negocio.Modulos.Personas;
//using Negocio.Modulos.Finanzas.Comprobantes;
//using AutoMapper;



//var builder = WebApplication.CreateBuilder(args);



//// Add services to the container.
//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//// obtener cadena de conexión desde appsettings.json
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//// Registrar el DbContext con tu cadena de conexión para EF
//builder.Services.AddDbContext<OpenSuiteDbContext>(options =>
//    options.UseSqlServer(connectionString));

//// Registrar DatosSQL ADO con la cadena de conexión
//builder.Services.AddScoped<DatosSQL>(sp => new DatosSQL(connectionString));


///// Registrar DatosSQL<T> EF con la cadena de conexión
//builder.Services.AddScoped(typeof(Datos.EF.DatosSQL<>));

//// Dependencia de herramientas
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());






//builder.Services.AddScoped<PasswordService>();

//builder.Services.AddScoped<ResponseService>();
//builder.Services.AddScoped<IResponseService, ResponseService>();


//// Dependencia de negocio
//builder.Services.AddScoped<PlanCuentasServicios>();
//builder.Services.AddScoped<CatalogosServicios>();
//builder.Services.AddScoped<EmpresasServicios>();
//builder.Services.AddScoped<UsuariosServicios>();
//builder.Services.AddScoped<PersonasServicios>();
//builder.Services.AddScoped<ComprobantesServicios>();





//// Configurar para que no retorne automáticamente un 400 Bad Request cuando el modelo es inválido
//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true;
//});

//// Configurar Newtonsoft.Json para ignorar los ciclos de referencia
//// creeme, eso mucho jode
//builder.Services.AddControllers()
//    .AddNewtonsoftJson(options =>
//    {
//        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
//    });

//builder.Services.AddControllers()
//    .AddJsonOptions(opt =>
//    {
//        opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
//        opt.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
//    });


//// Anadir documentacion para swagger
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();




//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();


//    ////anadir documentacion para swagger
//    app.UseSwagger();
//    app.UseSwaggerUI();


//    // anadir documentación para scalar
//    app.MapScalarApiReference(options => { options.Servers = Array.Empty<ScalarServer>(); });

//    //para abrir directamente en el navegador la documentación
//    app.Use(async (context, next) =>
//    {
//        if (context.Request.Path == "/")
//        {
//            // redirigir a la documentación de Scalar
//            context.Response.Redirect("/scalar/v1");
//            return;
//        }

//        await next();
//    });

//}

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();


//// Initialize application
//app.Run();
