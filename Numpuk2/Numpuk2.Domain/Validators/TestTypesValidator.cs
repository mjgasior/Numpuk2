using Numpuk2.Domain.Parameters;
using System.Collections.Generic;
using System.Linq;

namespace Numpuk2.Domain.Validators
{
    public static class TestTypesValidator
    {
        private static Dictionary<string, string> COMMONLY_MISSPELLED = new Dictionary<string, string>
        {
            ["Clostridium innocum"] = "Clostridium innocuum",
            ["Enterobacter cloaceae"] = "Enterobacter cloacae",
            ["Colinsella spp."] = "Collinsella spp.",
            ["Staphyloccocus spp."] = "Staphylococcus spp."
        };

        public static bool IsValidName(string name)
        {
            return TestTypes.GetAll().Any(x => name.Equals(x));
        }

        public static string TryFix(string name)
        {
            string trimmed = name.Trim();
            if (IsValidName(trimmed))
            {
                return trimmed;
            }

            string withDot = trimmed + ".";
            if (IsValidName(withDot))
            {
                return withDot;
            }

            if (COMMONLY_MISSPELLED.Any(x => x.Key == trimmed))
            {
                return COMMONLY_MISSPELLED[trimmed];
            }

            if (trimmed.EndsWith("spp.") && !trimmed.EndsWith(" spp."))
            {
                return trimmed.Remove(trimmed.Length - 4) + " spp.";
            }

            return trimmed;
        }
    }
}
