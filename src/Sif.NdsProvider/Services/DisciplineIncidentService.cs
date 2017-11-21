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

namespace Sif.NdsProvider.Services
{
    public class DisciplineIncidentService : IBasicProviderService<DisciplineIncident>
    {
        public DisciplineIncident Create(DisciplineIncident disciplineIncidentObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            var incidentObj = new Incident();
            // incidentObj.refId = disciplineIncidentObj.refId;
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                if (disciplineIncidentObj.incidentCategoryList != null || disciplineIncidentObj.weaponTypeList != null || disciplineIncidentObj.victimList != null || disciplineIncidentObj.secondaryBehaviorList != null || disciplineIncidentObj.offenderList != null)
                {
                    incidentObj = Mapper.Map<Incident>(disciplineIncidentObj);
                    incidentObj.IncidentId = 0;
                    _context.Incident.Add(incidentObj);
                }
              
                if (disciplineIncidentObj.incidentActionList != null || disciplineIncidentObj.offenderList != null)
                {
                    var k12StuDiscipline = Mapper.Map<K12StudentDiscipline>(disciplineIncidentObj);
                    k12StuDiscipline.IncidentId = incidentObj.IncidentId;
                   _context.K12StudentDiscipline.Add(k12StuDiscipline);
                }               
                _context.SaveChanges();
               
            }
            return disciplineIncidentObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public DisciplineIncident Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<DisciplineIncident> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<DisciplineIncident> Retrieve(DisciplineIncident obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<DisciplineIncident> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(DisciplineIncident obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

    }
}
