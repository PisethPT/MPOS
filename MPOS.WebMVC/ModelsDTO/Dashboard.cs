namespace MPOS.WebMVC.ModelsDTO
{
	public class Dashboard
	{
		public List<TopProducts>? TopProducts { get; set; }
		public List<TopEmployees>? TopEmployees { get; set; }
	}
	public struct TopProducts
	{
		public int InvoiceId { get; set; }
		public string? ProductName { get; set; }
		public string? Category { get; set; }
		public int Quantity { get; set; }
		public double TotalPrice { get; set; }
		public DateTime Created { get; set; }
	}

	public struct TopEmployees
	{
		public int EmployeeId { get; set; }
		public string EmployeeName { get; set; }
		public string Phone { get; set; }
		public double TotalAmount { get; set; }
	}
}
