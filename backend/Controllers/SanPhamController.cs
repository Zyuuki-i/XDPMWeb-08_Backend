using backend.Models;
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
                        t.MaLoaiNavigation.Tenloai,
                        t.MaNsxNavigation.Tennsx,
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
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
