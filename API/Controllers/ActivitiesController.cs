using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

//ActivitiesController eredita da BaseAPIController
//sotto ce la dimostrazione della dependency injection
public class ActivitiesController(AppDbContext context) : BaseAPIController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    //sempre attenzione all'ActionResult<>
    //usare async per i metodi che richiamano query db e' buono per la scalabilita, 
    //parche' non blocca il thread in attesa della risposta del db
    //ma un altro thread fa il lavoro e poi lo ripassa quando e' pronto
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetails(string id)
    {
        var activity = await context.Activities.FindAsync(id);

        if (activity == null)
            return BadRequest("Activity not found");

        return activity;
    }
}
