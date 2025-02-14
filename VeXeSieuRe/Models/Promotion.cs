using System.ComponentModel.DataAnnotations;

namespace VeXeSieuRe;

public enum PromotionType { Percentage, Fixed }
public enum PromotionStatus { Active, Inactive, Expired }

public class Promotion: BaseEntity
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(20)]
    public string Code { get; set; } //Mã khuyến mãi để khách hàng nhập
    public PromotionType Type { get; set; } //Loại giảm giá (percentage: phần trăm/fixed: số tiền cố định)
    public decimal Value { get; set; } //Giá trị giảm (VD: 10% hoặc 50,000đ)
    public DateTime StartDate { get; set; } //Ngày bắt đầu
    public DateTime EndDate { get; set; } //Ngày kết thúc
    [Range(0, double.MaxValue)]
    public decimal MinOrderValue { get; set; } //Giá trị đơn hàng tối thiểu
    [Range(0, double.MaxValue)]
    public decimal MaxDiscount { get; set; } //Số tiền giảm tối đa
    [Range(0, double.MaxValue)]
    public int UsageLimit { get; set; } //Giới hạn số lần sử dụng
    [Range(0, double.MaxValue)]
    public int UsedCount { get; set; } //Số lần đã sử dụng
    public PromotionStatus Status { get; set; } //Trạng thái (active/inactive/expired)
}