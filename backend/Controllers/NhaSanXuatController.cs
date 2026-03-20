using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaSanXuatController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();
        [HttpGet]
        public IActionResult getDSNSX()
        {
            try
            {
                var data = db.NhaSanXuats.Select(t => new {
                    t.MaNsx,
                    t.Tennsx,
                    t.Diachi,
                    t.Sdt,
                    t.Email
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }
    }
}
