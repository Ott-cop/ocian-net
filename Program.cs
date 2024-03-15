using ocian_net.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppDbContext>();

builder.Services.AddCors(options => 
{
    options.AddPolicy(name: "CorsApp",
        policyBuilder => 
        {
            policyBuilder.WithOrigins("https://ocian.vercel.app");
            policyBuilder.WithMethods("POST");
        }
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
