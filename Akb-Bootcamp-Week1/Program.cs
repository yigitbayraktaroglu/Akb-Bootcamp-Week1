using Akb_Bootcamp_Week1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<BookService, BookService>();
// Startup.cs
builder.Services.AddScoped<FakeAuthenticationService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Global exception middleware for dev
    app.UseDeveloperExceptionPage();
}
else
{
    // Global exception handling middleware for production
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Global log middleware
app.Use(async (context, next) =>
{
    // Log when action is called
    Console.WriteLine($"Action invoked: {context.Request.Method} - {context.Request.Path} - {context.Request.QueryString.Value} ");

    // Resume next middleware or actions
    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
