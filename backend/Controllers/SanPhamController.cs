using backend.Models;
using backend.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();

        [HttpGet("{masp}")]
        public IActionResult getSanpham(string masp)
        {
            try
            {
                var data = db.SanPhams
                    .Include(sp => sp.MaLoaiNavigation)
                    .Include(sp => sp.MaNsxNavigation)
                    .Where(x => x.MaSp == masp)
                    .Select(t => new {
                        t.MaSp,
                        t.Tensp,
                        Tenloai = t.MaLoaiNavigation != null ? t.MaLoaiNavigation.Tenloai : "",
                        Tennsx = t.MaNsxNavigation != null ? t.MaNsxNavigation.Tennsx : "",
                        t.MaNsx,
                        t.MaLoai,
                        t.Giasp,
                        t.Soluongton,
                        t.Mota
                    }).FirstOrDefault();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet]
        public IActionResult getDSSanpham()
        {
            try
            {
                var data = db.SanPhams
                    .Include(sp => sp.MaLoaiNavigation)
                    .Include(sp => sp.MaNsxNavigation)
                    .Select(t => new {
                    t.MaSp,
                    t.Tensp,
                    t.MaLoaiNavigation.Tenloai,
                    t.MaNsxNavigation.Tennsx,
                    t.MaNsx,
                    t.MaLoai,
                    t.Giasp,
                    t.Soluongton,
                    t.Mota
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet("loc")]
        public IActionResult LocSanPham(string? keyword = null,string? maloai = null,string? mansx = null)
        {
            try
            {
                var query = db.SanPhams.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(sp => sp.Tensp.Contains(keyword));
                }
                else if (!string.IsNullOrEmpty(maloai) && !string.IsNullOrEmpty(mansx))
                {
                    query = query.Where(sp => sp.MaLoai == maloai && sp.MaNsx == mansx);
                }
                else if (!string.IsNullOrEmpty(maloai))
                {
                    query = query.Where(sp => sp.MaLoai == maloai);
                }
                else if (!string.IsNullOrEmpty(mansx))
                {
                    query = query.Where(sp => sp.MaNsx == mansx);
                }

                var data = query
                    .Include(sp => sp.MaLoaiNavigation)
                    .Include(sp => sp.MaNsxNavigation)
                    .Select(t => new {
                        t.MaSp,
                        t.Tensp,
                        Tenloai = t.MaLoaiNavigation != null ? t.MaLoaiNavigation.Tenloai : "",
                        Tennsx = t.MaNsxNavigation != null ? t.MaNsxNavigation.Tennsx : "",
                        t.MaNsx,
                        t.MaLoai,
                        t.Giasp,
                        t.Soluongton,
                        t.Mota
                    }).ToList();


                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult themSanPham([FromBody] CSanPham dto)
        {
            try
            {
                SanPham sp = new SanPham
                {
                    MaSp = dto.MaSp,
                    Tensp = dto.Tensp,
                    MaLoai = dto.MaLoai,
                    MaNsx = dto.MaNsx,
                    Giasp = dto.Giasp,
                    Soluongton = dto.Soluongton,
                    Mota = dto.Mota
                };

                db.SanPhams.Add(sp);
                db.SaveChanges();

                return Ok(sp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult suaSanPham(string id, [FromBody] CSanPham dto)
        {
            try
            {
                var sp = db.SanPhams.Find(id);
                if (sp == null) return NotFound();

                sp.Tensp = dto.Tensp;
                sp.MaLoai = dto.MaLoai;
                sp.MaNsx = dto.MaNsx;
                sp.Giasp = dto.Giasp;
                sp.Soluongton = dto.Soluongton;
                sp.Mota = dto.Mota;

                db.SaveChanges();

                return Ok(sp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult xoaSanPham(string id)
        {
            try
            {
                var sp = db.SanPhams.Find(id);
                if (sp == null) return NotFound();

                db.SanPhams.Remove(sp);
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
