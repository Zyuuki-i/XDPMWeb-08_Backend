using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaiTroController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();
        [HttpGet]
        public IActionResult getDSVaiTro()
        {
            try
            {
                var data = db.VaiTros.Select(t => new {
                    t.MaVt,
                    t.Tenvt,
                    t.Mota
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet("{id}")]
        public IActionResult getLoai(string id)
        {
            try
            {
                var data = db.VaiTros.Where(x => x.MaVt == id).Select(t => new {
                    t.MaVt,
                    t.Tenvt,
                    t.Mota
                }).FirstOrDefault();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }
    }
}
