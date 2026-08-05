using WebApplication2.Models;
using WebApplication2.Services;
using WebApplication2.Data;
using WebApplication2.Repositories;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITaskRepository, PostgresTaskRepository>();

builder.Services.AddSingleton<TaskService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/tasks", (TaskService service) => service.GetAll());
app.MapGet("/tasks/{id}", (int id, TaskService service) => service.GetById(id));
app.MapPost("/tasks", (TaskModel task, TaskService service) => service.AddTask(task.TaskName));
app.MapDelete("tasks/{id}", (int id, TaskService service) =>
{
    var deleted = service.RemoveTask(id);
    if (!deleted)
    {
        return Results.NotFound();
    }
    return Results.Ok();
});
app.MapPut("/tasks/{id}/finish", (int id, TaskService service) =>
{
    var result = service.MarkFinished(id);
    if(result == null)
    {
        return Results.NotFound();
    }
    else
    {
        return Results.Ok(result);
    }
});

app.Run();
