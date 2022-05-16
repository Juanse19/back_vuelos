using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VuelosAPI.DTOs;
using VuelosAPI.Entidades;

namespace VuelosAPI.Controllers
{
    [Route("api/flight")]
    [ApiController]
    public class FlightController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public FlightController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<FlightDTO>>> Get()
        {
            var flight = await context.Flights.ToListAsync();
            return mapper.Map<List<FlightDTO>>(flight);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<FlightDTO>> Gat(int Id)
        {
            var flight = await context.Flights.FirstOrDefaultAsync(x => x.Id == Id);
            if (flight == null)
            {
                return NotFound();
            }

            return mapper.Map<FlightDTO>(flight);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FlightCreacionDTO flightCreacionDTO)
        {
            var flight = mapper.Map<Flight>(flightCreacionDTO);
            context.Add(flight);
            await context.SaveChangesAsync();
            return NoContent();
        }

       [HttpPut("{id:int}")]
       public async Task<ActionResult> Put(int Id, [FromBody] FlightCreacionDTO flightCreacionDTO)
        {
            var flight = await context.Flights.FirstOrDefaultAsync(x => x.Id == Id);

            if(flight == null)
            {
                return NotFound();
            }

            flight = mapper.Map(flightCreacionDTO, flight);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var flight = await context.Flights.AnyAsync(x => x.Id == id);

            if (!flight)
            {
                return NotFound();
            }

            context.Remove(new Flight() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
