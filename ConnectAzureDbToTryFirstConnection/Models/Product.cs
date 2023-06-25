using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectAzureDbToTryFirstConnection.Models;


[Table("Product", Schema = "SalesLT")]
public class Product
{
    public int ProductID { get; set; }
    public string? Name { get; set; }
    public string? ProductNumber { get; set; }
    public string? Color { get; set; }
    public decimal? ListPrice { get; set; }
    public decimal? Weight { get; set; }
    public int? ProductCategoryID { get; set; }
    [NotMapped]
    public string ProductCategoryName { get; set; } = string.Empty;
}