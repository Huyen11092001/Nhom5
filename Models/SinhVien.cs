using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
namespace QUANLYSINHVIEN.Models
{
    public class SinhVien
    {
    [Key]
    [Required(ErrorMessage = "Mã Sinh Viên không được để trống")]
    public string? MaSV{get;set;}
    [Required(ErrorMessage = "Họ và tên Sinh Viên không được để trống")]
    public string? Hovaten { get; set; }
    public string? Address { get; set; }
    
    public string? Malop { get; set; }
     [ForeignKey("Malop")]
    public Lop? Lop { get; set; }
    public string? Makhoa { get; set; }
    [ForeignKey("Makhoa")]
    public Khoa? Khoa { get; set; }
    
   

}
}