using System;
using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sif.NdsProvider.Mappers
{
    public class StudentSectionAssociationsMapper : Profile
    {
        public override string ProfileName
        {
            get { return "StudentSchoolAssociationMapper"; }
        }
        public StudentSectionAssociationsMapper()
        {
            var createdBy = "SIFAdmin";
            var statusId = "1";
            Random ran = new Random();
            Mapper.Initialize(cfg => cfg.CreateMap<StudentSectionAssociation, K12StudentCourseSection>()
            .ForMember(dest => dest.NumberOfCreditsEarned, map => map.MapFrom(s => s.creditsEarned.creditValue))
            .ForMember(dest => dest.RefCreditTypeEarnedId, map => map.MapFrom(s => s.creditsEarned.creditValueType.code)));

            Mapper.Initialize(cfg => cfg.CreateMap<StudentSectionAssociation, ProgramParticipationCte>()
           .ForMember(dest => dest.CteConcentrator, map => map.MapFrom(s => s.cteConcentrator)));

            Mapper.Initialize(cfg => cfg.CreateMap<StudentSectionAssociation, CourseSectionSchedule>()
          .ForMember(dest => dest.TimeDayIdentifier, map => map.MapFrom(s => s.scheduleOverride.meetingTimeList.First().timeTableDay)));

            Mapper.Initialize(cfg => cfg.CreateMap<StudentSectionAssociation, K12StaffAssignment>()
           .ForMember(dest => dest.RefTeachingAssignmentRoleId, map => map.MapFrom(s => s.scheduleOverride.sectionTeacherList.First().teachingAssignmentRole.code)));
        }
    }
}
