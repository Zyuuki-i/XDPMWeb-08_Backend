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

        [HttpGet("{mahinh}")]
        public IActionResult getHinh(int mahinh)
        {
            try
            {
                var query = db.Hinhs.Where(t => t.MaHinh == mahinh);
                if (query == null) return NotFound();
                var data = query.Select(
                    t => new {
                        t.MaHinh,
                        t.MaSp,
                        t.Tenhinh
                    }).FirstOrDefault();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

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

        [HttpGet("only")]
        public IActionResult getDS1Hinh()
        {
            try
            {
                var query = db.Hinhs.GroupBy(x => x.MaSp)
                                        .Select(g => g.First())
                                        .ToList();
                var data = query.Select(
                    t => new {
                        t.MaHinh,
                        t.MaSp,
                        t.Tenhinh
                    }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet("SanPham/{masp}")]
        public IActionResult getDSHinhByMasp(string masp)
        {
            try
            {
                var query = db.Hinhs.Where(t=>t.MaSp==masp).ToList();
                if(query.Count<=0) return NotFound();
                var data = query.Select(
                    t => new {
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
