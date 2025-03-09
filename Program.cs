using api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*Configurar el DBContext creado como un servicio*/
builder.Services.AddDbContext<DataContext>( opt => {   

    opt.UseSqlite( builder.Configuration.GetConnectionString("DefaultConnection") );
} );




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



/* Habilitar CORS
    declarar el servicio, este sera referenciadl en el http Request Pipeline
*/
//builder.Services.AddCors();
builder.Services.AddCors( options => {
    options.AddPolicy( "New Policy", app => {
        app.AllowAnyHeader().AllowAnyMethod()
        .WithOrigins("http://localhost:4200",
        "https://localhost:4200");
    } );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseCors( x=> x.AllowAnyHeader().AllowAnyMethod()
//.WithOrigins("http://localhost:4200', 'https://localhost:4200") );

/*WithOrigins(http://localhost:4200) si se quiere especificar el origen del request*/






if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors( "New Policy" ); /*registramos politica de cors*/
app.UseAuthorization();

app.MapControllers();

app.Run();
