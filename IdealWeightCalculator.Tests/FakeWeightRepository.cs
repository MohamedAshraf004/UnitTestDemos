using System;
using System.Collections.Generic;
using System.Text;

namespace IdealWeight.Tests
{
    class FakeWeightRepository:IDataRepository
    {
        IEnumerable<WeightCalculator> weights;
        public FakeWeightRepository()
        {
            weights = new List<WeightCalculator>
            {
                new WeightCalculator(){Height=175,Gender='m'},
                new WeightCalculator(){Height=172,Gender='m'},
                new WeightCalculator(){Height=175,Gender='w'}
            };
        }
        public IEnumerable<WeightCalculator> GetWeight()
        {
            return weights;
        }
    }
}
