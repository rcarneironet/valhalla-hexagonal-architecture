using System;

namespace Valhalla.Modules.Application.Commands.PlaceOrder
{
    public interface IPlaceOrderUseCase
    {
        Guid Execute(Guid customerId);
    }
}
