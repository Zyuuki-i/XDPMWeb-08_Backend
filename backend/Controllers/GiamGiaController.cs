using backend.Models;
using backend.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();
        [HttpGet("{magg}")]
        public IActionResult getGiamGia(string magg)
        {
            try
            {
                var data = db.GiamGia
                    .Where(x => x.MaGg == magg)
                    .Select(x => new
                    {
                        x.MaGg,
                        x.Tenma,
                        x.Loaima,
                        x.Dieukien,
                        x.Phantramgiam,
                        x.Ngaybd,
                        x.Ngaykt,
                        x.Tongsl
                    }).FirstOrDefault();
                if(data == null) { return NotFound(); }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult getDSGiamGia()
        {
            try
            {
                var data = db.GiamGia
                    .Select(x => new
                    {
                        x.MaGg,
                        x.Tenma,
                        x.Loaima,
                        x.Dieukien,
                        x.Phantramgiam,
                        x.Ngaybd,
                        x.Ngaykt,
                        x.Tongsl
                    }).ToList();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult themGiamGia([FromBody] CGiamGia dto)
        {
            try
            {
                GiamGia x = new GiamGia
                {
                    MaGg = dto.MaGg,
                    Tenma = dto.Tenma,
                    Loaima = dto.Loaima,
                    Dieukien = dto.Dieukien,
                    Phantramgiam = dto.Phantramgiam,
                    Ngaybd = dto.Ngaybd,
                    Ngaykt = dto.Ngaykt,
                    Tongsl = dto.Tongsl
                };

                db.GiamGia.Add(x);
                db.SaveChanges();

                return Ok(x);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult suaGiamGia(string id, [FromBody] CGiamGia dto)
        {
            try
            {
                var x = db.GiamGia.Find(id);
                if (x == null) return NotFound();

                x.Tenma = dto.Tenma;
                x.Loaima = dto.Loaima;
                x.Dieukien = dto.Dieukien;
                x.Phantramgiam = dto.Phantramgiam;
                x.Ngaybd = dto.Ngaybd;
                x.Ngaykt = dto.Ngaykt;
                x.Tongsl = dto.Tongsl;

                db.SaveChanges();

                return Ok(x);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult xoaGiamGia(string id)
        {
            try
            {
                var x = db.GiamGia.Find(id);
                if (x == null) return NotFound();

                db.GiamGia.Remove(x);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //end
    }
}
