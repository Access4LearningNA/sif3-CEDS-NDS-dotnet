#region Namespace
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sif.Framework.Model.Query;
using Sif.Framework.Service.Providers;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Services.Commons;
using Sif.Specification.DataModel.Us;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Sif.Framework.Service;
#endregion

namespace Sif.NdsProvider.Services
{
    public class StudentProgramAssociationService : IBasicProviderService<StudentProgramAssociations>
    {
        public StudentProgramAssociations Create(StudentProgramAssociations StudentProgramAssociationObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            string refId = Guid.NewGuid().ToString();
            StudentProgramAssociationObj.refId = refId;
            
            var k12stuEnrollment = new K12StudentEnrollment();
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {


               
                _context.SaveChanges();
            }
            return StudentProgramAssociationObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public StudentProgramAssociations Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<StudentProgramAssociations> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<StudentProgramAssociations> Retrieve(StudentProgramAssociations obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<StudentProgramAssociations> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentProgramAssociations obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }
    }
}
