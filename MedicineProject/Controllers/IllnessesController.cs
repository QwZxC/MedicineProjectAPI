using AutoMapper;
using MedicineProject.Context;
using MedicineProject.DTOs;
using MedicineProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace MedicineProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IllnessesController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;

        public IllnessesController(ApplicationContext context, IMapper mapper, IMemoryCache memoryCache)
        {
            this.context = context;
            this.mapper = mapper;
            cache = memoryCache;
        }


        [HttpGet("GetIllnesses")]
        public async Task<ActionResult<IEnumerable<IllnessDTO>>> GetIllnesses()
        {
            List<IllnessDTO> illnesses;
            if (cache.TryGetValue(0, out illnesses))
            {
                return Ok(illnesses);
            }
            
            illnesses = await context.Illness.Select(illness => mapper.Map<IllnessDTO>(illness)).ToListAsync();
            return Ok(illnesses);
        }

        [HttpPost("CreateIllness")]
        public async Task<ActionResult<IllnessDTO>> CreateIllnes([FromBody] IllnessDTO illnessDTO)
        {
            if (illnessDTO == null)
            {
                return BadRequest("Неверная модель");
            }

            Illness oldIllnes = await context.Illness.FirstOrDefaultAsync(illness => illness.Name == illnessDTO.Name);
            if (oldIllnes != null)
            {
                return BadRequest("Такая болезнь уже есть в списке");
            }

            context.Illness.Add(mapper.Map<Illness>(illnessDTO));
            await context.SaveChangesAsync();

            return Ok(illnessDTO);
        }

        [HttpPut("UpdateIllness")]
        public async Task<ActionResult<IllnessDTO>> UpdateIllness([FromBody] IllnessDTO illnessDTO)
        {
            if (illnessDTO == null)
            {
                return BadRequest("Неверная модель");
            }
             
            if(await context.Illness.FirstOrDefaultAsync(illness => illness.Name == illnessDTO.Name) != null)
            {
                return BadRequest("Такое название болезни уже содержится в списке");
            }

            Illness oldIllnes = await context.Illness.FindAsync(illnessDTO.Id);
            if (oldIllnes == null)
            {
                return BadRequest("Такой болезни нет в списке");
            }

            oldIllnes.Name = illnessDTO.Name;
            oldIllnes.Description = illnessDTO.Description;
            
            await context.SaveChangesAsync();
            
            return Ok(illnessDTO);
        }
    }
}
