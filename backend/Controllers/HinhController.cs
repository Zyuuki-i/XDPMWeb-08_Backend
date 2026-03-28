using backend.Models;
using backend.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinhController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();

        [HttpGet("{id}")]
        public IActionResult getHinh(int id)
        {
            try
            {
                var query = db.Hinhs.Where(t => t.MaHinh == id);
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

        [HttpPost]
        public IActionResult themHinh([FromBody] CHinh dto)
        {
            try
            {
                Hinh x = new Hinh
                {
                    MaHinh = dto.MaHinh,
                    MaSp = dto.MaSp,
                    Tenhinh = dto.Tenhinh
                };

                db.Hinhs.Add(x);
                db.SaveChanges();

                return Ok(x);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult suaHinh(int id, [FromBody] CHinh dto)
        {
            try
            {
                var x = db.Hinhs.Find(id);
                if (x == null) return NotFound();

                x.Tenhinh = dto.Tenhinh;
                x.MaSp = dto.MaSp;

                db.SaveChanges();

                return Ok(x);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult xoaHinh(int id)
        {
            try
            {
                var x = db.Hinhs.Find(id);
                if (x == null) return NotFound();

                db.Hinhs.Remove(x);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("SanPham/{masp}")]
        public IActionResult xoaHinhAll(string masp)
        {
            try
            {
                var x = db.Hinhs.Where(x => x.MaSp == masp).ToList();
                if (x == null) return NotFound();

                db.Hinhs.RemoveRange(x);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
