using backend.Models;
using backend.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaoHangController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();

        [HttpGet]
        public IActionResult getDSGiaoHang()
        {
            try
            {
                var data = db.GiaoHangs.Select(t => new {
                    t.MaGh,
                    t.MaDdh,
                    t.MaNv,
                    t.Ngaybd,
                    t.Ngaykt,
                    t.Tongthu,
                    t.Trangthai
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet("{id}")]
        public IActionResult getGiaoHang(int id)
        {
            try
            {
                var data = db.GiaoHangs.Where(x=>x.MaGh==id).Select(t => new {
                    t.MaGh,
                    t.MaDdh,
                    t.MaNv,
                    t.Ngaybd,
                    t.Ngaykt,
                    t.Tongthu,
                    t.Trangthai
                }).FirstOrDefault();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet("TrangThai")]
        public IActionResult getDSGiaoHangByTrangThai(string trangthai)
        {
            try
            {
                var data = db.GiaoHangs.Where(x=>x.Trangthai==trangthai).Select(t => new {
                    t.MaGh,
                    t.MaDdh,
                    t.MaNv,
                    t.Ngaybd,
                    t.Ngaykt,
                    t.Tongthu,
                    t.Trangthai
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult themGiaoHang([FromBody] CGiaoHang dto)
        {
            try
            {
                GiaoHang gh = new GiaoHang
                {
                    MaGh = dto.MaGh,
                    MaDdh = dto.MaDdh, 
                    MaNv = dto.MaNv,
                    Ngaybd = dto.Ngaybd,
                    Ngaykt = dto.Ngaykt,
                    Tongthu = dto.Tongthu,
                    Trangthai = dto.Trangthai
                };

                db.GiaoHangs.Add(gh);
                db.SaveChanges();

                return Ok(gh);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult suaGiaoHang(int id, [FromBody] CGiaoHang dto)
        {
            try
            {
                var gh = db.GiaoHangs.Find(id);
                if (gh == null) return NotFound();

                gh.MaGh = dto.MaGh;
                gh.MaDdh = dto.MaDdh;
                gh.MaNv = dto.MaNv;
                gh.Ngaybd = dto.Ngaybd;
                gh.Ngaykt = dto.Ngaykt;
                gh.Tongthu = dto.Tongthu;
                gh.Trangthai = dto.Trangthai;

                db.SaveChanges();

                return Ok(gh);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult xoaGiaoHang(int id)
        {
            try
            {
                var gh = db.GiaoHangs.Find(id);
                if (gh == null) return NotFound();

                db.GiaoHangs.Remove(gh);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
