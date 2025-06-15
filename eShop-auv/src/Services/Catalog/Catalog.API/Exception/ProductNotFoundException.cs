namespace Catalog.API.Exception
{
    public class ProductNotFoundException : System.Exception // Fully qualified the Exception type
    {
        public ProductNotFoundException() : base("Product not found.")
        {
        }
    }
}
