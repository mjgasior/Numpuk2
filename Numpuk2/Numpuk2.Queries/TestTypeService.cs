using Numpuk2.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Numpuk2.Queries
{
    public class TestTypeService
    {
        public List<string> GetOfType(Family[] families)
        {
            if (families.Length == 0)
            {
                return TestTypes.GetAll();
            }

            if (families.Length > 4)
            {
                throw new ArgumentException("There cannot be more than 4 families to pick!");
            }

            var set = new List<string>();

            families.ToList().ForEach(x => set.AddRange(GetFamily(x)));

            return set;
        }

        private List<string> GetFamily(Family family)
        {
            switch (family)
            {
                case Family.ANAEROBIC:
                    return TestTypes.GetAnaerobic();
                case Family.GRAM_MINUS:
                    return TestTypes.GetGramMinus();
                case Family.GRAM_PLUS:
                    return TestTypes.GetGramPlus();
                case Family.FUNGI:
                    return TestTypes.GetFungi();
                default:
                    throw new ArgumentException("Unknown family type!");
            }
        }
    }
}
