using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspCoreDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ResContext ctx;
        ILogger log;

        public ValuesController(ResContext _ctx, ILogger<ValuesController> _log)
        {
            ctx = _ctx;
            log = _log;
        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetCategory()
        {
            return Ok(await ctx.Categories.ToListAsync());
        }

        [HttpGet("Resource")]
        public async Task<IActionResult> GetResource(string code)
        {
            var catList = await ctx.Categories.ToListAsync();
            var cat = catList.FirstOrDefault(c => c.AssemblyCode == code);
            if (cat == null)
                return Ok();
            var result = await ctx.Resources.Where(c => c.Code.Contains(cat.ResourceCode))
                            .ToListAsync();
            return Ok(result);
        }
    }
}
