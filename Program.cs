var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//TODO find data in db 
app.MapGet("/api/cars", () =>
{
    var cars = new List<Car>
    {
        new Car
    {
        TeamName = "Team A"
    },
        new Car
    {
        TeamName = "Team B"
    },
         new Car
    {
        TeamName = "Team C"
    }
    };

    return cars;


}).WithName("GetCars");

app.MapGet("/api/cars/{id}", (int id) =>
{
    return new Car { TeamName = "Team A" };
}).WithName("GeCarById");

app.MapPost("api/cars", (Car car) =>
{
    return car;
}).WithName("CreateCar");

app.MapPut("api/cars/{id}", (int id,Car car) =>
{
    return car;
}).WithName("UpdateCar");

app.MapDelete("api/cars/{id}", (int id) =>
{
    return $"Car with id {id} was succesfully deleted";
});

app.Run();



public record Car
{
    public int Id { get; set; }
    public string TeamName { get; set; }
    public int Speed { get; set; }
    public double MelFunctionChance { get; set; }
    public int MelFunctionsOccured { get; set; }
    public int DistanceConverInMiles { get; set; }
    public int FinishedRace { get; set; }
    public int RacedForHours { get; set; }


}
