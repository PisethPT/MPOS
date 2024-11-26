using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPOS.WebMVC.Models;

public partial class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int CategoryId { get; set; }

	[Required]
	[Range(1, double.MaxValue, ErrorMessage = "Cost Price must be greater than 0")]
	public double CostPrice { get; set; }

	[Required]
	[Range(1, double.MaxValue, ErrorMessage = "Selling Price must be greater than 0")]
	public double SellingPrice { get; set; }

    public string Unit { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
	public string? Photo { get; set; }

	public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    [NotMapped]
    public string Title { get; set; } = string.Empty;
    [NotMapped]
	public List<SelectListItem>? Categories { get; set; }
	[NotMapped]
	public IFormFile? IPhoto { get; set; }
}
