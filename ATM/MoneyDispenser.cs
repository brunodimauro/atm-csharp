using System;
using System.Collections.Generic;

namespace ATM
{
    public class MoneyDispenser : IDispenseHandler
    {
        private int _note;
        private int _qty;
        private byte? _limit;

        public MoneyDispenser(int note, int qty, byte? limit = null)
        {
            _note = note;
            _qty = qty;
            _limit = limit;
        }

        private IDispenseHandler handler;

        public Dictionary<object, object> Dispense(Currency currency, Dictionary<object, object> result)
        {
            if (result == null)
                result = new Dictionary<object, object>();

            // Set the remainder value
            int remainder = currency.Amount % _note;

            if (currency.Amount >= _note)
            {
                int num = currency.Amount / _note;

                if (num > _qty)
                    throw new Exception("Lack of notes");

                // Check limit of currency
                if (_limit.HasValue && num > _limit)
                {
                    num = _limit.Value;

                    // Set the remainder value considering the limit of currency
                    remainder = currency.Amount - (_note * num);
                }

                result.Add(_note, num);
            }

            if (remainder != 0)
            {
                if (handler == null)
                    throw new Exception("Out of options to dispense");

                handler.Dispense(new Currency(remainder), result);
            }

            return result;
        }

        public void SetNextHandler(IDispenseHandler nextHandler)
        {
            handler = nextHandler;
        }
    }
}
