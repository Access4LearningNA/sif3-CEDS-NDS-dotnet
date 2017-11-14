using AutoMapper;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Services.Commons;
using SIF.NDSDataModel;
using System.Linq;

namespace Sif.NdsProvider.Mappers
{
    public class SectionMapper:Profile
    {
        public override string ProfileName
        {
            get { return "SectionMapper"; }
        }
        public SectionMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Section, K12StudentCourseSection>()
            .ForMember(dest => dest.RefCreditTypeEarnedId, map => map.MapFrom(src => src.courseOverride.courseCredits.creditValueType.code.ToString() != null ? CommonMethods.GetCodesetCode("RefCreditTypeEarned", "RefCreditTypeEarnedId", "Code", src.courseOverride.courseCredits.creditValueType.code.ToString()) : null)));
            Mapper.Initialize(cfg => cfg.CreateMap<Section, CourseSection>()
            .ForMember(dest => dest.RefInstructionLanguageId, map => map.MapFrom(src => src.languageOfInstruction.code.ToString() != null ? CommonMethods.GetCodesetCode("RefLanguage", "RefLanguageId", "Code", src.languageOfInstruction.code.ToString()) : null))
            .ForMember(dest=>dest.RefCourseSectionDeliveryModeId,map=>map.MapFrom(src=>src.mediumOfInstruction.code.ToString() !=null?CommonMethods.GetCodesetCode("RefCourseSectionDeliveryMode", "RefCourseSectionDeliveryModeId", "Code", src.mediumOfInstruction.code.ToString()):null)));
            Mapper.Initialize(cfg => cfg.CreateMap<Section, CourseSectionLocation>()
            .ForMember(dest => dest.RefInstructionLocationTypeId, map => map.MapFrom(src => src.locationOfInstruction.code.ToString() != null ? CommonMethods.GetCodesetCode("RefInstructionLocationType", "RefInstructionLocationTypeId", "Code", src.locationOfInstruction.code.ToString()) : null)));
            Mapper.Initialize(cfg => cfg.CreateMap<Section, CourseSectionSchedule>()
            .ForMember(dest => dest.TimeDayIdentifier, map => map.MapFrom(src => src.sessionScheduleList.Select(x => x.meetingTimeList.Select(y => y.timeTableDay).FirstOrDefault()))));
            Mapper.Initialize(cfg => cfg.CreateMap<Section, K12StaffAssignment>()
            .ForMember(dest => dest.RefTeachingAssignmentRoleId, map => map.MapFrom(src => src.sessionScheduleList.Select(x => x.sectionTeacherList.Select(y => y.teachingAssignmentRole.code.ToString() != null ? CommonMethods.GetCodesetCode("RefTeachingAssignmentRole", "RefTeachingAssignmentRoleId", "Code", y.teachingAssignmentRole.code.ToString()) : null)))));
            //Mapper.Initialize(cfg => cfg.CreateMap<Section, K12StaffAssignment>()
            //.ForMember(dest => dest//Mapping not exist, map => map.MapFrom(src => src.schoolYear)));
           // Mapper.Initialize(cfg => cfg.CreateMap<Section, K12StaffAssignment>()
            //.ForMember(dest => dest//Mapping not exist, map => map.MapFrom(src => src.localId.idValue)));

        }
    }
}
