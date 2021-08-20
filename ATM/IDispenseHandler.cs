using System.Collections.Generic;

namespace ATM
{
    public interface IDispenseHandler
    {
        void SetNextHandler(IDispenseHandler nextChain);

        Dictionary<object, object> Dispense(Currency currency, Dictionary<object, object> result);
    }
}
