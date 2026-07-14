using WebApplication2.Models;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TaskService>();
var app = builder.Build();
var taskService = app.Services.GetRequiredService<TaskService>();

app.MapGet("/", () => "Hello World!");
app.MapGet("/tasks", () => taskService.GetAll());
app.MapGet("/tasks/{id}", (int id) => taskService.GetById(id));
app.MapPost("/tasks", (TaskModel task) => taskService.AddTask(task.TaskName));
app.MapDelete("tasks/{id}", (int id) =>
{
    var deleted = taskService.RemoveTask(id);
    if (!deleted)
    {
        return Results.NotFound();
    }
    return Results.Ok();
});
app.MapPut("/tasks/{id}/finish", (int id) =>
{
    var result = taskService.MarkFinished(id);
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
