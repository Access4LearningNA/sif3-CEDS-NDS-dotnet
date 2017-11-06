using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sif.NdsProvider.Services.Commons
{
    public enum StudentExternalId
    {
         externalIdPersonIdentificationSystemId = 4,
        externalIdPersonIdentifierId = 5
    }
    public  enum StudentLocalId
    {
         localIdPersonIdentificationSystemId = 4,
         localIdPersonIdentifierId = 5
    }
    public enum YesNoUnknown
    {
        Yes=1,
        No=2,
        UnKnown=3
    }
    public static class MyEnumClass
    {
        public const string EconomicDisadvantage = "Economic Disadvantage";
        public const string StudentRole = "K12 Student";
        public const string CalendarCode = "CalendarCode";
        public const string EntryType = "EntryType";

    }
}
