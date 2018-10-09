using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthAndYearFromSpanishRegistration
{
   
    class SpanishRegistrationAge
    {
        private static List<SpanishRegistrationAgeItem> items = new List<SpanishRegistrationAgeItem>();

        static SpanishRegistrationAge()
        {
            var strCsvContents = File.ReadAllText("ES.csv");
            var strLines = strCsvContents.Split('\n');
            foreach (var strLine in strLines)
            {
                var strColumns = strLine.Split(',');
                var intYear = Convert.ToInt16(strColumns[0]);
                for (int intMonth = 1; intMonth < 12; intMonth++)
                {
                    var item = new SpanishRegistrationAgeItem
                    {
                        month = intMonth,
                        year = intYear,
                        prefix = strColumns[intMonth]
                    };
                    items.Add(item);
                }
            }
        }

        public static SpanishRegistrationAgeItem NearestMonth(string regNumber)
        {
            var strPrefix = regNumber.Substring(regNumber.Length - 3 , 3);
            var list = items.OrderBy(i => i.year * 12 + i.month);
            var nearest = list.First(i => string.CompareOrdinal(i.prefix, strPrefix) >= 0);
            return nearest;
        }
        
    }
}
