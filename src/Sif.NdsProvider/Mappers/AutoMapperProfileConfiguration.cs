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
            });
        }
    }
}
