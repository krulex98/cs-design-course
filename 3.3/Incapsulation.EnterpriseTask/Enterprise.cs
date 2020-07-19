using System;
using System.Linq;

namespace Incapsulation.EnterpriseTask
{
    public class Enterprise
    {
        public string Name { get; set; }
        public DateTime EstablishDate { get; set; }
        public Guid Guid { get; }

        public Enterprise(Guid guid)
        {
            Guid = guid;
        }
        
        private string _inn;
        public string Inn
        {
            get => _inn;
            set
            {
                if (_inn.Length != 10 || !_inn.All(char.IsDigit))
                    throw new ArgumentException();
                _inn = value;
            }
        }

        public TimeSpan ActiveTimeSpan => DateTime.Now - EstablishDate;

        public double GetTotalTransactionsAmount()
        {
            DataBase.OpenConnection();
            var amount = 0.0;
            foreach (var t in DataBase.Transactions().Where(z => z.EnterpriseGuid == Guid))
                amount += t.Amount;
            return amount;
        }
    }
}
