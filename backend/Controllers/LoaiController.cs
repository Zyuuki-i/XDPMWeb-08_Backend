using backend.Models;
using backend.MyModels;
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

        [HttpGet("{id}")]
        public IActionResult getLoai(string id)
        {
            try
            {
                var data = db.LoaiSanPhams.Where(x => x.MaLoai == id).Select(t => new {
                    t.MaLoai,
                    t.Tenloai,
                    t.Mota
                }).FirstOrDefault();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult themLoai([FromBody] CLoaiSanPham dto)
        {
            try
            {
                LoaiSanPham x = new LoaiSanPham
                {
                    MaLoai = dto.MaLoai,
                    Tenloai = dto.Tenloai,
                    Mota = dto.Mota
                };

                db.LoaiSanPhams.Add(x);
                db.SaveChanges();

                return Ok(x);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult suaLoai(string id, [FromBody] CLoaiSanPham dto)
        {
            try
            {
                var x = db.LoaiSanPhams.Find(id);
                if (x == null) return NotFound();

                x.Tenloai = dto.Tenloai;
                x.Mota = dto.Mota;

                db.SaveChanges();

                return Ok(x);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult xoaLoai(string id)
        {
            try
            {
                var x = db.LoaiSanPhams.Find(id);
                if (x == null) return NotFound();

                db.LoaiSanPhams.Remove(x);
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
