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

#region cars enpoints 
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


}).WithName("GetCars").WithTags("Cars");

app.MapGet("/api/cars/{id}", (int id) =>
{
    return new Car { TeamName = "Team A" };
}).WithName("GeCarById").WithTags("Cars");

app.MapPost("api/cars", (Car car) =>
{
    return car;
}).WithName("CreateCar").WithTags("Cars");

app.MapPut("api/cars/{id}", (int id,Car car) =>
{
    return car;
}).WithName("UpdateCar").WithTags("Cars");

app.MapDelete("api/cars/{id}", (int id) =>
{
    return $"Car with id {id} was succesfully deleted";
}).WithName("DeleteCar")
   .WithTags("Cars");
#endregion

#region motorbikes endpoints
app.MapPost("api/motorbikes",
    (Motorbike motorbike) =>
    {
        return motorbike;
    })
    .WithName("CreateMotorbike")
    .WithTags("Motorbikes");

// Default endpoints
app.MapPut("api/motorbikes/{id}",
    (Motorbike motorbike) =>
    {
        return motorbike;
    })
    .WithName("UpdateMotorbike")
    .WithTags("Motorbikes");

app.MapDelete("api/motorbikes/{id}",
    (int id) =>
    {
        return $"Motorbike with id: {id} was succesfully deleted";
    })
    .WithName("DeleteMotorbike")
    .WithTags("Motorbikes");
#endregion

app.Run();


#region models
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

public record Motorbike
{
    public int Id { get; set; }
    public string TeamName { get; set; }
    public int Speed { get; set; }
    public double MelfunctionChance { get; set; }
    public int MelfunctionsOccured { get; set; }
    public int DistanceCoverdInMiles { get; set; }
    public bool FinishedRace { get; set; }
    public int RacedForHours { get; set; }
}
#endregion
