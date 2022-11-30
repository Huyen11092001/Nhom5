using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
namespace QUANLYSINHVIEN.Models
{
    public class Qld
    {
    [Key]
    [Required(ErrorMessage = "Mã sinh viên không được để trống")]
    public string? MaSV{get;set;}
    [Required(ErrorMessage = "Tên sinh viên không được để trống")]
    public string? TenSV { get; set; }
    public string? Tenmonhoc { get; set; }
    public string? Diem { get; set; }
}
}