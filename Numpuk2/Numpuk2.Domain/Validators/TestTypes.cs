using System;
using System.Collections.Generic;
using System.Linq;

namespace Numpuk2.Domain.Validators
{
    public static class TestTypes
    {
        private static List<string> TEST_TYPES = new List<string>
        {
            // anaerobic
            "Lactobacillus spp.",
            "Lactobacillus – H2O2",
            "Bifidobacterium spp.",
            "Bacteroides spp.",
            "Bacteroides ovatus",
            "Campylobacter spp.",
            "Clostridium spp.",
            "Clostridium innocuum",
            "Clostridium ramosum",
            "Clostridium bolteae",
            "Collinsella spp.",
            "Peptococcus spp.",
            "Peptostreptococcus spp.",
            "Prevotella spp.",
            "Eggerthella lenta",
            "Fusobacterium spp.",

            // aerobic
            // gram +
            "Enterococcus spp.",
            "Streptococcus spp.",
            "Staphylococcus spp.",
            "Staphylococcus aureus",

            // gram -
            "Escherichia coli",
            "Proteus spp.",
            "Proteus vulgaris",
            "Proteus mirabilis",
            "Pseudomonas spp.",
            "Pseudomonas aeruginosa",
            "Klebsiella spp.",
            "Klebsiella pneumoniae",
            "Klebsiella oxytoca",
            "Enterobacter spp.",
            "Enterobacter cloacae",
            "Citrobacter spp.",
            "Citrobacter freundii",
            "Morganella spp.",
            "Morganella morganii",
            "Serratia spp.",
            "Escherichia coli Biovare",
            "Salmonella spp.",
            "Shigella spp.",
            "Yersinia spp.",
            "Hafnia alvei",
            "Providencia spp.",
            "Providencia alcalifaciens",
            "Aeromonas caviae",

            // others
            "Bacillus spp.",

            // fungi
            "Candida albicans",
            "Candida non-albicans",
            "Grzyby pleśniowe"
        };

        private static Dictionary<string, string> COMMONLY_MISSPELLED = new Dictionary<string, string>
        {
            ["Clostridium innocum"] = "Clostridium innocuum",
            ["Enterobacter cloaceae"] = "Enterobacter cloacae",
            ["Colinsella spp."] = "Collinsella spp.",
            ["Staphyloccocus spp."] = "Staphylococcus spp."
        };

        public static bool IsValidName(string name)
        {
            return TEST_TYPES.Any(x => name.Equals(x));
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
