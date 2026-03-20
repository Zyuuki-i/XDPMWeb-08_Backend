using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();
        [HttpGet]
        public IActionResult getDSLoai()
        {
            try
            {
                var data = db.LoaiSanPhams.Select(t => new {
                    t.MaLoai,
                    t.Tenloai,
                    t.Mota
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }
    }
}
