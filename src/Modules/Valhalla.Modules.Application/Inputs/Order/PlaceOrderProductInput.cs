namespace Valhalla.Modules.Application.Inputs.Order
{
    public class PlaceOrderProductInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
