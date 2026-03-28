using backend.Models;
using backend.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapNhatController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();
        [HttpGet]
        public IActionResult getDSCapNhat()
        {
            try
            {
                var data = db.CapNhats.Select(t => new {
                    t.MaCn,
                    t.MaNv,
                    t.MaSp,
                    t.Ngaycapnhat,
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet("{id}")]
        public IActionResult getCN(int id)
        {
            try
            {
                var data = db.CapNhats
                        .Where(t => t.MaCn == id)
                        .OrderByDescending(t => t.Ngaycapnhat)
                        .Select(t => new {
                            t.MaCn,
                            t.MaNv,
                            t.MaSp,
                            t.Ngaycapnhat,
                        });
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet("SanPham/{id}")]
        public IActionResult getCNbyMasp(string id)
        {
            try
            {
                var data = db.CapNhats
                        .Where(t => t.MaSp == id)
                        .OrderByDescending(t => t.Ngaycapnhat)
                        .Select(t => new {
                            t.MaCn,
                            t.MaNv,
                            t.MaSp,
                            t.Ngaycapnhat,
                        }).FirstOrDefault();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult themCN([FromBody] CCapNhat dto)
        {
            try
            {
                CapNhat x = new CapNhat
                {
                   MaCn = dto.MaCn,
                   MaNv = dto.MaNv,
                   MaSp = dto.MaSp,
                   Ngaycapnhat = dto.Ngaycapnhat
                };

                db.CapNhats.Add(x);
                db.SaveChanges();

                return Ok(x);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult suaCN(int id, [FromBody] CCapNhat dto)
        {
            try
            {
                var x = db.CapNhats.Find(id);
                if (x == null) return NotFound();

                x.Ngaycapnhat = dto.Ngaycapnhat;

                db.SaveChanges();

                return Ok(x);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult xoaCN(int id)
        {
            try
            {
                var x = db.CapNhats.Find(id);
                if (x == null) return NotFound();

                db.CapNhats.Remove(x);
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
