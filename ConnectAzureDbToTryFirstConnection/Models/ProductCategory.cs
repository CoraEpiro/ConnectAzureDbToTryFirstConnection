using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectAzureDbToTryFirstConnection.Models;


[Table("ProductCategory", Schema = "SalesLT")]
public class ProductCategory
{
    public int ProductCategoryID { get; set; }
    public string? Name { get; set; }
}