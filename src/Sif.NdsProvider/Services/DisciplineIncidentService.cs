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
                List<IncidentPerson> IncidentPer = new List<IncidentPerson>();
                if (disciplineIncidentObj.victimList !=null )
                {
                    
                        var incPerson = new IncidentPerson();
                        var victimPersonId = _context.Person.Where(x => x.refId == disciplineIncidentObj.victimList.Select(y => y.victimRefId).ToString()).Select(z => z.PersonId).FirstOrDefault();
                        incPerson.IncidentId = incidentObj.IncidentId;
                    incPerson.RefIncidentPersonRoleTypeId =Convert.ToInt32(CommonMethods.GetCodesetCode("RefIncidentPersonRoleType", "RefIncidentPersonRoleTypeId", "Code", disciplineIncidentObj.victimList.Select(x => x.victimType).FirstOrDefault()));
                    IncidentPer.Add(incPerson);
                }
                if(disciplineIncidentObj.offenderList != null)
                {
                    var incOffenderPerson = new IncidentPerson();
                      var offPersonId = _context.Person.Where(x => x.refId == disciplineIncidentObj.offenderList.Select(y => y.offenderRefId).ToString()).Select(z => z.PersonId).FirstOrDefault();
                    incOffenderPerson.IncidentId = incidentObj.IncidentId;
                    incOffenderPerson.RefIncidentPersonRoleTypeId = Convert.ToInt32(CommonMethods.GetCodesetCode("RefIncidentPersonRoleType", "RefIncidentPersonRoleTypeId", "Code", disciplineIncidentObj.offenderList.Select(x => x.offenderType).FirstOrDefault()));
                    IncidentPer.Add(incOffenderPerson);
                }
                _context.IncidentPerson.AddRange(IncidentPer);
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
