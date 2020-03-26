using System.Collections.Generic;

namespace IdealWeight
{
    public interface IDataRepository
    {
        IEnumerable<WeightCalculator> GetWeight();
    }
}
