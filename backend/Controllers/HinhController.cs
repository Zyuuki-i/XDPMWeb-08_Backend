using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinhController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();

        [HttpGet]
        public IActionResult getDSHinh()
        {
            try
            {
                var data = db.Hinhs.Select(t => new {
                    t.MaHinh,
                    t.MaSp,
                    t.Tenhinh
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }
    }
}
