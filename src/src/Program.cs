using src;
using src.DBContext;
using src.Seed;
using src.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<RatingSystemDbcontext>();
builder.Services.AddTransient<ImageServices>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(options =>
    {
        options.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();

    });
});

var app = builder.Build();

// Perform seeding within the same scope
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RatingSystemDbcontext>();
    var dbBuilder = new InitialHostDbBuilder(context);
    dbBuilder.Create();
}
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RatingSystemDbcontext>();
    var dbBuilder = new ImageServices(context);
    await dbBuilder.GetAllImageIds();
    Console.WriteLine(GlobalVariables.pairedDictionary.Keys);
    Console.WriteLine(GlobalVariables.pairedDictionary.Values);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
