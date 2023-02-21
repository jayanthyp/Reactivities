using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpGet]//api/Activities
        public async Task<List<Activity>> GetActivities()
        {
            return await _mediator.Send(new List.Query());
        }
        
        [HttpGet("{id}")]//api/Activities/sdfhjkef768fefd
        public async Task<ActionResult<Activity>> GetActivities(Guid id)
        {
            return await _mediator.Send(new Details.Query{Id=id});
        }  
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command{ Activity=activity}));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid Id, Activity activity)
        {
            activity.Id=Id;
            return Ok(await Mediator.Send(new Edit.Command{ Activity=activity}));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid Id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id=Id}));
        }
    }
}