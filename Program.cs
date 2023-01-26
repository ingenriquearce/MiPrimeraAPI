var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Two ways to implement HelloWorld service:
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>(); This way is more simplified
//builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService()); //This way can be used when we have to add a parameter
//Here, it is created the object "HelloWorldService" so that controller can use it


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage(); //it appears me because I set up port https before continuing

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();