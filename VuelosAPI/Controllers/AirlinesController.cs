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
    [Route("api/airlines")]
    [ApiController]
    public class AirlinesController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AirlinesController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AirlineDTO>>> Get()
        {
            var airlines = await context.Airlines.ToListAsync();
            return mapper.Map<List<AirlineDTO>>(airlines);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<AirlineDTO>> Gat(int Id)
        {
            var airline = await context.Airlines.FirstOrDefaultAsync(x => x.Id == Id);
            if (airline == null)
            {
                return NotFound();
            }

            return mapper.Map<AirlineDTO>(airline);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AirlineCreacionDTO airlineCreacionDTO)
        {
            var airline = mapper.Map<Airline>(airlineCreacionDTO);
            context.Add(airline);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(int Id, [FromBody] AirlineCreacionDTO airlineCreacionDTO)
        {
            var airline = await context.Airlines.FirstOrDefaultAsync(a => a.Id == Id);

            if (airline == null)
            {
                return NotFound();
            }

            airline = mapper.Map(airlineCreacionDTO, airline);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var airline = await context.Airlines.AnyAsync(x => x.Id == id);

            if (!airline)
            {
                return NotFound();
            }

            context.Remove(new Airline() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
