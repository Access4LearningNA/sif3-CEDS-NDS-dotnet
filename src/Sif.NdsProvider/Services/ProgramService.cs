using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sif.Framework.Model.Query;
using Sif.Framework.Service.Providers;
using Program=Sif.NdsProvider.Model.Program;
using Sif.NdsProvider.Services.Commons;
using Sif.Specification.DataModel.Us;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;

namespace Sif.NdsProvider.Services
{
    public class ProgramService : IBasicProviderService<Program>
    {
        public Program Create(Program programObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            var person = new SIF.NDSDataModel.Person();

            person.refId = programObj.refId;
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                _context.SaveChanges();

            }
            return programObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public Program Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Program> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Program> Retrieve(Program obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Program> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Program obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }
    }
}
