using System;
using System.Threading.Tasks;
using LeaveApp.Core.Entities;
using LeaveApp.Service.ILeaveServices;
using Microsoft.AspNetCore.Mvc;

namespace LeaveApp.API.LeaveAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : Controller
    {
        private readonly ILevelService levelService;

        public LevelController(ILevelService levelService)
        {
            this.levelService = levelService;
        }
        // GET: api/Level
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetLevels()
        {
            try
            {
                var levels = await levelService.GetAllLevels();
                if (levels == null)
                {
                    return NotFound();
                }
                return Ok(levels);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // GET: api/Level/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLevel(int id)
        {
            try
            {
                var level = await levelService.GetLevelById(id);
                if (level == null)
                {
                    return NotFound();
                }
                return Ok(level);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // POST: api/Level
        [HttpPost]
        public async Task<IActionResult> PostLevel([FromBody] Level level)
        {
            try
            {
                var levl = await levelService.AddLevel(level);
                if (levl.Id > 0)
                {
                    return Ok(levl);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        // PUT: api/Level/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevel(int id, [FromBody] Level level)
        {
            try
            {
                var levl = await levelService.UpdateLevel(level, id);
                if (levl.Id > 0)
                {
                    return Ok(levl);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevel(int id)
        {
            try
            {
                if (id != 0)
                {
                    var level = await levelService.DeleteLevel(id);
                    return Ok(level);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}