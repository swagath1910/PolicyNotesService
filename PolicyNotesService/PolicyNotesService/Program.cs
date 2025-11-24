using Microsoft.EntityFrameworkCore;
using PolicyNotesService.Data;
using PolicyNotesService.Repositories;
using PolicyNotesService.Services;
using PolicyNotesService.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PolicyNotesDbContext>(options =>
    options.UseInMemoryDatabase("PolicyNotesDb"));

builder.Services.AddScoped<IPolicyNoteRepository, PolicyNoteRepository>();
builder.Services.AddScoped<IPolicyNoteService, PolicyNotesService.Services.PolicyNoteService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/notes", async (PolicyNote note, IPolicyNoteService service) =>
{
    var newnote = await service.AddNoteAsync(note);
    return Results.Created($"/notes/{newnote.Id}", newnote);
});


app.MapGet("/notes", async (IPolicyNoteService service) =>
{
    var notes = await service.GetAllNotesAsync();
    return Results.Ok(notes);
});


app.MapGet("/notes/{id}", async (Guid id, IPolicyNoteService service) =>
{
    var note = await service.GetNoteByIdAsync(id);
    return note is null
    ? Results.NotFound()
    : Results.Ok(note);
});



app.Run();

public partial class Program { }