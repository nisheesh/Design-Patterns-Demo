using DesignPatternsDemo.Facade_Pattern.SubSystems;

namespace DesignPatternsDemo.Facade_Pattern
{
    class OnlineShoppingFacade
    {
        IInventory inventory = new InventoryManager();
        IOrderVerify orderVerify = new OrderVerificationManager();
        ICosting costManger = new CostManager();
        IPaymentGateway paymentGateWay = new PaymentGatewayManager();
        ILogistics logistics = new LogisticsManager();

        public void FinalizeOrder(OrderDetails orderDetails)
        {
            inventory.Update(orderDetails.ProductNo);
            orderVerify.VerifyShippingAddress(orderDetails.PinCode);
            orderDetails.Price = costManger.ApplyDiscounts(orderDetails.Price, orderDetails.DiscountPercent);
            paymentGateWay.VerifyCardDetails(orderDetails.CardNo);
            paymentGateWay.ProcessPayment(orderDetails.CardNo, orderDetails.Price);
            logistics.ShipProduct(orderDetails.ProductName, $"{orderDetails.AddressLine1}, {orderDetails.AddressLine2} - {orderDetails.PinCode}.");
        }
    }
}
