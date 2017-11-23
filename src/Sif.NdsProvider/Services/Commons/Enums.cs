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
        localIdOrganizationIdentificationSystemId = 13,
        localIdOrganizationIdentifierTypeId = 9
    }
    public enum PrgoramIdetifierLocalId
    {
        refOrgIdentificationSystemId=66,
        refOrgIdentifierTypeId=15
    }
    public enum SchoolContactPersonLocalId
    {
        localIdPersonIdentificationSystemId = 20,
        
    }
    public enum SchoolContactPersonExternalId
    {
        ExternalIdPersonIdentificationSystemId = 21,

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
        public const string OrganizationContactRole = "Organization Contact";
        public const string CalendarCode = "CalendarCode";
        public const string EntryType = "EntryType";
        public const string PrimaryDisabilityType = "PrimaryDisabilityType";
        public const string LEPStatus = "LEPStatus";
        public const string FinancialExpenditureK12ProjectReportingCode = "FinancialExpenditureK12ProjectReportingCode";

    }
}
