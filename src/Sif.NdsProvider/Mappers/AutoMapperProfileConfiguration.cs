using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;


namespace Sif.NdsProvider.Mappers
{
    public static class AutoMapperProfileConfiguration
    {

        public static void Configure()
        {
            
            Mapper.Initialize(x =>
            {
                x.AddProfile<SchoolAttributesMapper>();
                x.AddProfile<OrganizationMapper>();
                x.AddProfile<StudentMapper>();
                x.AddProfile<StudentAttendanceEventMapper>();
                x.AddProfile<StudentSectionMarkScoresMapper>();
                x.AddProfile<StudentAttendanceSummaryMapper>();
                x.AddProfile<StudentProgramAssociationsMapper>();
                x.AddProfile<StudentSchoolAssociationMapper>();
                x.AddProfile<StudentSectionAssociationsMapper>();
                x.AddProfile<AddressMapper>();
                x.AddProfile<SectionMapper>();
                x.AddProfile<CourseMapper>();
                x.AddProfile<SchoolCalendarMapper>();
                x.AddProfile<SchoolCalendarItemMapper>();
                x.AddProfile<DisciplineIncidentMapper>();
                x.AddProfile<PersonMapper>();
                x.AddProfile<ProgramMapper>();
                x.AddProfile<SeaMapper>();
            });
        }
    }
}
