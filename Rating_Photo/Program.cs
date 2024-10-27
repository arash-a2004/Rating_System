using Rating_Photo.DBContext;
using Rating_Photo.Seed;
using Rating_Photo.Services.ImageServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<IRatingServices, RatingServices>();

builder.Services.AddDbContext<RatingSystemDbContext>();


var app = builder.Build();

// Perform seeding within the same scope
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RatingSystemDbContext>();
    var dbBuilder = new InitialHostDbBuilder(context);
    dbBuilder.Create(); 
}

#region Test
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<IImageService>();
//    var context2 = scope.ServiceProvider.GetRequiredService<IRatingServices>();
//    var test = new Test(context,context2);
//    //await test.GetAllImageTest();
//    //await test.GetImageDetailByIdTest(5155);
//    //await test.RatingTest();
//}
#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
