using System.Collections.Generic;

namespace Numpuk2.Domain.Parameters
{
    public class TestTypes
    {
        public static List<string> GetAll()
        {
            var all = new List<string>();
            all.AddRange(GetAnaerobic());
            all.AddRange(GetGramPlus());
            all.AddRange(GetGramMinus());
            all.AddRange(GetFungi());

            return all;
        }

        public static List<string> GetAnaerobic()
        {
            return new List<string>()
            {
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
                "Collinsella aerofaciens",
                "Peptococcus spp.",
                "Peptostreptococcus spp.",
                "Prevotella spp.",
                "Eggerthella lenta",
                "Fusobacterium spp.",
                "Megamonas spp."
            };
        }

        public static List<string> GetFungi()
        {
            return new List<string>()
            {
                "Candida albicans",
                "Candida non-albicans",
                "Grzyby pleśniowe"
            };
        }

        public static List<string> GetGramPlus()
        {
            return new List<string>()
            {
                "Enterococcus spp.",
                "Streptococcus spp.",
                "Staphylococcus spp.",
                "Staphylococcus aureus",
                "Bacillus spp.",
            };
        }

        public static List<string> GetGramMinus()
        {
            return new List<string>()
            {
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
                "Aeromonas caviae"
            };
        }
    }
}
