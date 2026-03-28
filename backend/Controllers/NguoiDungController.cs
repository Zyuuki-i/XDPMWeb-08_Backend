using backend.Models;
using backend.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();

        [HttpGet("{id}")]
        public IActionResult getNguoidung(int id)
        {
            try
            {
                var nguoiDung = db.NguoiDungs.Find(id);
                if (nguoiDung == null)
                {
                    return NotFound();
                }
                var data = new
                {
                    nguoiDung.MaNd,
                    nguoiDung.Tennd,
                    nguoiDung.Matkhau,
                    nguoiDung.Sdt,
                    nguoiDung.Diachi,
                    nguoiDung.Phuongxa,
                    nguoiDung.Tinhthanh,
                    nguoiDung.Email,
                    nguoiDung.Hinh,
                    nguoiDung.Trangthai
                };
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("DanhGia/{mand}")]
        public IActionResult getNguoidungByMand(int mand)
        {
            try
            {
                var nguoiDung = db.NguoiDungs.Find(mand);
                if (nguoiDung == null)
                {
                    return NotFound();
                }
                var data = new
                {
                    nguoiDung.MaNd,
                    nguoiDung.Tennd,
                    nguoiDung.Matkhau,
                    nguoiDung.Sdt,
                    nguoiDung.Diachi,
                    nguoiDung.Phuongxa,
                    nguoiDung.Tinhthanh,
                    nguoiDung.Email,
                    nguoiDung.Hinh,
                    nguoiDung.Trangthai
                };
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("TrangThai")]
        public IActionResult getNguoidungByTt(bool trangthai)
        {
            try
            {
                var data = db.NguoiDungs.Where(t=>t.Trangthai==trangthai)
                    .Select( 
                    x => new {
                        x.MaNd,
                        x.Tennd,
                        x.Matkhau,
                        x.Sdt,
                        x.Diachi,
                        x.Phuongxa,
                        x.Tinhthanh,
                        x.Email,
                        x.Hinh,
                        x.Trangthai
                    }).ToList();
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public IActionResult getDSNguoidung()
        {
            try
            {
                var data = db.NguoiDungs.Select(t => new {
                    t.MaNd,
                    t.Tennd,
                    t.Matkhau,
                    t.Sdt,
                    t.Diachi,
                    t.Phuongxa,
                    t.Tinhthanh,
                    t.Email,
                    t.Hinh,
                    t.Trangthai
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
                var nguoiDung = db.NguoiDungs.FirstOrDefault(t => t.Email == email && t.Matkhau == password);
                if (nguoiDung == null)
                {
                    return NotFound();
                }
                var data = new
                {
                    nguoiDung.MaNd,
                    nguoiDung.Tennd,
                    nguoiDung.Matkhau,
                    nguoiDung.Sdt,
                    nguoiDung.Diachi,
                    nguoiDung.Phuongxa,
                    nguoiDung.Tinhthanh,
                    nguoiDung.Email,
                    nguoiDung.Hinh,
                    nguoiDung.Trangthai
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
                var nguoiDung = db.NguoiDungs.FirstOrDefault(t => t.Email == email);
                if (nguoiDung == null)
                {
                    return NotFound();
                }
                var data = new
                {
                    nguoiDung.MaNd,
                    nguoiDung.Tennd,
                    nguoiDung.Matkhau,
                    nguoiDung.Sdt,
                    nguoiDung.Diachi,
                    nguoiDung.Phuongxa,
                    nguoiDung.Tinhthanh,
                    nguoiDung.Email,
                    nguoiDung.Hinh,
                    nguoiDung.Trangthai
                };
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult themNguoidung([FromBody] CNguoiDung nd)
        {
            try
            {
                if (nd == null)
                    return BadRequest();
                NguoiDung newND = new NguoiDung();
                newND.MaNd = nd.MaNd;
                newND.Tennd = nd.Tennd;
                newND.Matkhau = nd.Matkhau;
                newND.Sdt = nd.Sdt;
                newND.Diachi = nd.Diachi;
                newND.Phuongxa = nd.Phuongxa;
                newND.Tinhthanh = nd.Tinhthanh;
                newND.Email = nd.Email;
                newND.Hinh = nd.Hinh;
                newND.Trangthai = nd.Trangthai;

                db.NguoiDungs.Add(newND);
                db.SaveChanges();

                return Ok(nd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult suaNguoidung(int id, [FromBody] CNguoiDung nd)
        {
            try
            {
                var nguoiDung = db.NguoiDungs.Find(id);
                if (nguoiDung == null)
                    return NotFound();

                nguoiDung.Tennd = nd.Tennd;
                nguoiDung.Matkhau = nd.Matkhau;
                nguoiDung.Sdt = nd.Sdt;
                nguoiDung.Diachi = nd.Diachi;
                nguoiDung.Phuongxa = nd.Phuongxa;
                nguoiDung.Tinhthanh = nd.Tinhthanh;
                nguoiDung.Email = nd.Email;
                nguoiDung.Hinh = nd.Hinh;
                nguoiDung.Trangthai = nd.Trangthai;

                db.SaveChanges();

                return Ok(nguoiDung);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult xoaNguoidung(int id)
        {
            try
            {
                var nguoiDung = db.NguoiDungs.Find(id);
                if (nguoiDung == null)
                    return NotFound();

                db.NguoiDungs.Remove(nguoiDung);
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
