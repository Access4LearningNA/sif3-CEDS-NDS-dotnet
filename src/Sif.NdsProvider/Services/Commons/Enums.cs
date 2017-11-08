using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sif.NdsProvider.Services.Commons
{
    public enum SchoolExternalId
    {

        externalIdOrganizationIdentificationSystemId = 77,
        externalIdOrganizationIdentifierTypeId = 18
    }
    public enum SchoolLocalId
    {
        localIdOrganizationIdentificationSystemId = 36,
        localIdOrganizationIdentifierTypeId = 13
    }

    public enum StudentExternalId
    {
         externalIdPersonIdentificationSystemId = 8,
        
    }
    public  enum StudentLocalId
    {
         localIdPersonIdentificationSystemId = 2,
        
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
        public const string PrimaryDisabilityType = "PrimaryDisabilityType";
        public const string LEPStatus = "LEPStatus";

    }
}
