using AutoMapper;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Services.Commons;
using SIF.NDSDataModel;
using System.Linq;

namespace Sif.NdsProvider.Mappers
{
    public class DisciplineIncidentMapper:Profile
    {
        public override string ProfileName
        {
            get { return "DisciplineIncidentMapper"; }
        }
        public DisciplineIncidentMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DisciplineIncident, K12StudentDiscipline>()
            .ForMember(dest => dest.DurationOfDisciplinaryAction, map => map.MapFrom(src => src.incidentActionList.Select(x => x.duration).FirstOrDefault()))
            .ForMember(dest => dest.DisciplinaryActionEndDate, map => map.MapFrom(src => src.incidentActionList.Select(x => x.endDate).FirstOrDefault()))
            .ForMember(dest => dest.RefDisciplinaryActionTakenId, map => map.MapFrom(src => src.incidentActionList.Select(x => x.policeNotification.ToString() != null ? CommonMethods.GetCodesetCode("RefDisciplinaryActionTaken", "RefDisciplinaryActionTakenId", x.policeNotification.ToString()) : null)))
            .ForMember(dest => dest.RefDisciplinaryActionTakenId, map => map.MapFrom(src => src.incidentActionList.Select(x => x.startDate).FirstOrDefault()))
            .ForMember(dest => dest.RelatedToZeroTolerancePolicy, map => map.MapFrom(src => src.incidentActionList.Select(x => x.zeroTolerance).FirstOrDefault()))
            .ForMember(dest=>dest.DurationOfDisciplinaryAction,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.actionList.Select(y=>y.actionDuration).FirstOrDefault())))
            .ForMember(dest=>dest.DisciplinaryActionEndDate,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.actionList.Select(y=>y.actionEndDate).FirstOrDefault())))
            .ForMember(dest=>dest.DisciplinaryActionStartDate,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.actionList.Select(y=>y.actionEndDate).FirstOrDefault())))
            .ForMember(dest=>dest.RefDisciplinaryActionTakenId,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.actionList.Select(y=>y.code).FirstOrDefault())))
            .ForMember(dest=>dest.FullYearExpulsion,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.actionList.Any(y=>y.fullYearExpulsion.ToString()=="Yes"))))
            .ForMember(dest=>dest.ShortenedExpulsion,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.actionList.Any(y=>y.shortenedExpulsion.ToString()=="Yes"))))
            .ForMember(dest=>dest.RelatedToZeroTolerancePolicy,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.actionList.Any(y=>y.zeroTolerance.ToString()=="Yes"))))
            );

            Mapper.Initialize(cfg => cfg.CreateMap<DisciplineIncident, Incident>()
            .ForMember(dest => dest.RefIncidentBehaviorId, map => map.MapFrom(src => src.incidentCategoryList.Select(x => x.code).FirstOrDefault()))
            .ForMember(dest => dest.IncidentCost, map => map.MapFrom(src => src.incidentCost))
            .ForMember(dest => dest.IncidentDate, map => map.MapFrom(src => src.incidentDate.ToLongDateString().FirstOrDefault()))
            .ForMember(dest => dest.IncidentDescription, map => map.MapFrom(src => src.incidentDescription.FirstOrDefault()))
            .ForMember(dest => dest.IncidentIdentifier, map => map.MapFrom(src => src.incidentId.FirstOrDefault()))
            .ForMember(dest => dest.RefIncidentLocationId, map => map.MapFrom(src => src.incidentLocationId.ToString() != null ? CommonMethods.GetCodesetCode("RefIncidentLocation", "RefIncidentLocationId", src.incidentLocationId.ToString()) : null))
            .ForMember(dest => dest.RefIncidentReporterTypeId, map => map.MapFrom(src => src.incidentReporter.reporterType.ToString() != null ? CommonMethods.GetCodesetCode("RefIncidentReporterType", "RefIncidentReporterTypeId", src.incidentReporter.reporterType.ToString()) : null))
            .ForMember(dest => dest.IncidentTime, map => map.MapFrom(src => src.incidentTime.ToLongDateString().FirstOrDefault()))
            .ForMember(dest => dest.RefIncidentTimeDescriptionCodeId, map => map.MapFrom(src => src.incidentTimeType.ToString() != null ? CommonMethods.GetCodesetCode("RefIncidentTimeDescriptionCode", "RefIncidentTimeDescriptionCodeId", src.incidentTimeType.ToString()) : null))
             .ForMember(dest => dest.ReportedToLawEnforcementInd, map => map.MapFrom(src => src.offenderList.Select(x => x.actionList.Any(y => y.policeNotification.ToString()== "Yes"))))
             .ForMember(dest=>dest.RelatedToDisabilityManifestationInd,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.manifestationDetermination.dueToDisability).FirstOrDefault()))
             .ForMember(dest=>dest.RefIncidentPerpetratorInjuryTypeId,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.offenderInjury.ToString() !=null?CommonMethods.GetCodesetCode("RefIncidentPerpetratorInjuryType", "RefIncidentPerpetratorInjuryTypeId", x.offenderInjury.ToString()):null)))
            // .ForMember(dest=>dest//no map,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.offenderType)))
             .ForMember(dest=>dest.RefIncidentBehaviorSecondaryId,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.secondaryBehaviorCodeList).FirstOrDefault()))
             .ForMember(dest=>dest.RefWeaponTypeId,map=>map.MapFrom(src=>src.offenderList.Select(x=>x.weaponTypeList.Select(y=>y.code).FirstOrDefault())))
            // .ForMember(dest=>dest//No map,map=>map.MapFrom(src=>src.schoolYear))
            .ForMember(dest=>dest.RefIncidentInjuryTypeId, map=>map.MapFrom(src=>src.victimList.Select(x=>x.injury).FirstOrDefault()))
            //.ForMember(dest=>dest//no map,map=>map.MapFrom(src=>src.victimList.Select(x=>x.victimType.FirstOrDefault())))
            
             );
        }
    }
}
