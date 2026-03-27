using backend.Models;
using backend.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();

        [HttpGet("{id}")]
        public IActionResult getNhanvien(string id)
        {
            try
            {
                var nv = db.NhanViens.Find(id);
                if (nv == null)
                {
                    return NotFound();
                }
                string? tenvt = db.VaiTros.Find(nv.MaVt)?.Tenvt;
                var data = new
                {
                    nv.MaNv,
                    nv.Tennv,
                    nv.Matkhau,
                    nv.Phai,
                    nv.Sdt,
                    nv.Email,
                    nv.Cccd,
                    nv.Diachi,
                    nv.Hinh,
                    nv.MaVt,
                    Tenvt = tenvt,
                    nv.Trangthai
                };
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult getDSNhanvien()
        {
            try
            {
                var data = db.NhanViens
                    .Include(x => x.MaVtNavigation)
                    .Select(nv => new {
                    nv.MaNv,
                    nv.Tennv,
                    nv.Matkhau,
                    nv.Phai,
                    nv.Sdt,
                    nv.Email,
                    nv.Cccd,
                    nv.Diachi,
                    nv.Hinh,
                    nv.MaVt,
                    nv.MaVtNavigation.Tenvt,
                    nv.Trangthai
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet("DangNhap")]
        public IActionResult DangNhap(string email, string password)
        {
            try
            {
                var nv = db.NhanViens.FirstOrDefault(t => t.Email == email && t.Matkhau == password);
                if (nv == null)
                {
                    return NotFound();
                }
                string? tenvt = db.VaiTros.Find(nv.MaVt)?.Tenvt;
                var data = new
                {
                    nv.MaNv,
                    nv.Tennv,
                    nv.Matkhau,
                    nv.Phai,
                    nv.Sdt,
                    nv.Email,
                    nv.Cccd,
                    nv.Diachi,
                    nv.Hinh,
                    nv.MaVt,
                    Tenvt = tenvt,
                    nv.Trangthai
                };
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Email")]
        public IActionResult getNguoidungByEmail(string email)
        {
            try
            {
                var nv = db.NhanViens.FirstOrDefault(t => t.Email == email);
                if (nv == null)
                {
                    return NotFound();
                }
                string? tenvt = db.VaiTros.Find(nv.MaVt)?.Tenvt;
                var data = new
                {
                    nv.MaNv,
                    nv.Tennv,
                    nv.Matkhau,
                    nv.Phai,
                    nv.Sdt,
                    nv.Email,
                    nv.Cccd,
                    nv.Diachi,
                    nv.Hinh,
                    nv.MaVt,
                    Tenvt = tenvt,
                    nv.Trangthai
                };
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult themNhanvien([FromBody] CNhanVien cnv)
        {
            try
            {
                if (cnv == null)
                    return BadRequest();
                NhanVien nv = new NhanVien();
                nv.MaNv = cnv.MaNv;
                nv.Tennv = cnv.Tennv;
                nv.Matkhau = cnv.Matkhau;
                nv.Phai = cnv.Phai;
                nv.Sdt = cnv.Sdt;
                nv.Email = cnv.Email;
                nv.Cccd = cnv.Cccd;
                nv.Diachi = cnv.Diachi;
                nv.Hinh = cnv.Hinh;
                nv.Trangthai = cnv.Trangthai;
                nv.MaVt = cnv.MaVt;

                db.NhanViens.Add(nv);
                db.SaveChanges();

                return Ok(nv);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult suaNhanvien(string id, [FromBody] CNhanVien cnv)
        {
            try
            {
                var nv = db.NhanViens.Find(id);
                if (nv == null)
                    return NotFound();

                nv.MaNv = cnv.MaNv;
                nv.Tennv = cnv.Tennv;
                nv.Matkhau = cnv.Matkhau;
                nv.Phai = cnv.Phai;
                nv.Sdt = cnv.Sdt;
                nv.Email = cnv.Email;
                nv.Cccd = cnv.Cccd;
                nv.Diachi = cnv.Diachi;
                nv.Hinh = cnv.Hinh;
                nv.Trangthai = cnv.Trangthai;
                nv.MaVt = cnv.MaVt;


                db.SaveChanges();

                return Ok(nv);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult xoaNhanvien(string id)
        {
            try
            {
                var nv = db.NhanViens.Find(id);
                if (nv == null)
                    return NotFound();

                db.NhanViens.Remove(nv);
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
