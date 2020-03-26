
using System;
using System.Collections.Generic;
using System.Text;

namespace IdealWeight
{
    class WeightRepository:IDataRepository
    {
        IEnumerable<WeightCalculator> weights;
        public WeightRepository()
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
