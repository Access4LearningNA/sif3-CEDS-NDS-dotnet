using AutoMapper;
using Course=Sif.NdsProvider.Model.Course;
using Sif.NdsProvider.Services.Commons;
using EntityCourse = SIF.NDSDataModel.Course;
using System.Linq;

namespace Sif.NdsProvider.Mappers
{
    public class CourseMapper: Profile
    {
        public override string ProfileName
        {
            get { return "SectionMapper"; }
        }
        public CourseMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Course, EntityCourse>()
            //.ForMember(dest=>dest//No mapping,map=>map.MapFrom(src=>src.courseCode.code))
            .ForMember(dest => dest.CreditValue, map => map.MapFrom(src => src.courseCredits.creditValue))
            //.ForMember(dest=>dest//No Mapping,map=>map.MapFrom(src=>src.courseTitle))
            .ForMember(dest=>dest.Description,map=>map.MapFrom(src=>src.description.FirstOrDefault()))
            .ForMember(dest=>dest.RefCourseApplicableEducationLevelId,map=>map.MapFrom(src=>src.instructionalLevel.code.ToString() !=null?CommonMethods.GetCodesetCode("RefCourseApplicableEducationLevel", "RefCourseApplicableEducationLevelId", src.instructionalLevel.code.ToString()):null))
           // .ForMember(dest=>dest//No mapping,map=>map.MapFrom(src=>src.subjectAreaList.Select(x=>x.code)))
            );
        }
    }
}
