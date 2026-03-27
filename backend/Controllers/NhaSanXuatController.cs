using backend.Models;
using backend.MyModels;
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

        [HttpGet("{id}")]
        public IActionResult getNSX(string id)
        {
            try
            {
                var data = db.NhaSanXuats.Where(x=>x.MaNsx==id).Select(t => new {
                    t.MaNsx,
                    t.Tennsx,
                    t.Diachi,
                    t.Sdt,
                    t.Email
                }).FirstOrDefault();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult themNSX([FromBody] CNhaSanXuat dto)
        {
            try
            {
                NhaSanXuat x = new NhaSanXuat
                {
                    MaNsx = dto.MaNsx,
                    Tennsx = dto.Tennsx,
                    Diachi = dto.Diachi,
                    Sdt = dto.Sdt,
                    Email = dto.Email
                };

                db.NhaSanXuats.Add(x);
                db.SaveChanges();

                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult suaNSX(string id, [FromBody] CNhaSanXuat dto)
        {
            try
            {
                var x = db.NhaSanXuats.Find(id);
                if (x == null) return NotFound();

                x.Tennsx = dto.Tennsx;
                x.Diachi = dto.Diachi; 
                x.Sdt = dto.Sdt; 
                x.Email = dto.Email;

                db.SaveChanges();

                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult xoaNSX(string id)
        {
            try
            {
                var x = db.NhaSanXuats.Find(id);
                if (x == null) return NotFound();

                db.NhaSanXuats.Remove(x);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //end
    }
}
