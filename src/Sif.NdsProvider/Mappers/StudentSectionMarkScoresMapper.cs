using AutoMapper;
using Sif.NdsProvider.Model;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sif.NdsProvider.Services.Commons;

namespace Sif.NdsProvider.Mappers
{
    public class StudentSectionMarkScoresMapper : Profile
    {
        public override string ProfileName
        {
            get { return "StudentSectionMarkScoresMapper"; }
        }
        public StudentSectionMarkScoresMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<StudentSectionMarkScores, K12StudentCourseSectionMark>()
            .ForMember(dest => dest.FinalIndicator, map => map.MapFrom(src => src.isFinal))
            .ForMember(dest => dest.StudentCourseSectionGradeNarrative, map => map.MapFrom(src => src.markScoreList.Any() ? src.markScoreList.FirstOrDefault().narrative : null))
            );
        }
    }
}
