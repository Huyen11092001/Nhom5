using System.ComponentModel.DataAnnotations;
namespace QUANLYSINHVIEN.Models
{
    public class Qlmh
    {
    [Key]
    [Required(ErrorMessage = "Mã môn học không được để trống")]
    public string? Mamonhoc{get;set;}
    [Required(ErrorMessage = "Tên môn học không được để trống")]
    public string? Tenmonhoc { get; set; }
}
}