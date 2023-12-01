using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;


var bld = WebApplication.CreateBuilder();

bld.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

bld.Services.AddFastEndpoints().SwaggerDocument(); 

bld.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(bld.Configuration.GetConnectionString("SqlServerConnection")));

bld.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
bld.Services.AddScoped<IProdutoService, ProdutoService>();
bld.Services.AddScoped<IPedidoRepository, PedidoRepository>();
bld.Services.AddScoped<IPedidoService, PedidoService>();
bld.Services.AddScoped<IItensPedidoRepository, ItensPedidoRepository>();
bld.Services.AddScoped<IItensPedidoService, ItensPedidoService>();

bld.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")  
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

bld.Services.AddAutoMapper(typeof(MappingProfile));

var app = bld.Build();
app.UseCors();
app.UseFastEndpoints().UseSwaggerGen();
app.Run();
