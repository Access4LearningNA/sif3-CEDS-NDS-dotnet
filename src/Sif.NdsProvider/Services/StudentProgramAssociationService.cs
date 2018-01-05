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
            string prgTable = string.Empty;
            var orgPersonRole = new OrganizationPersonRole();
            var perprgparticipation = new PersonProgramParticipation();
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                if(StudentProgramAssociationObj.studentRefId !=null && StudentProgramAssociationObj.programRefId != null)
                {
                    var stuentId = (_context.Person.Where(x => x.refId == StudentProgramAssociationObj.studentRefId).Select(y => y.PersonId)).FirstOrDefault();
                    var orgId = _context.Organization.Where(x => x.refId == StudentProgramAssociationObj.programRefId).Select(y => y.OrganizationId).FirstOrDefault();
                    orgPersonRole.RoleId = Convert.ToInt32(_context.Role.Where(x => x.Name == MyEnumClass.StudentRole).Select(y => y.RoleId).FirstOrDefault());
                    orgPersonRole = Mapper.Map<OrganizationPersonRole>(StudentProgramAssociationObj);
                    orgPersonRole.OrganizationId = orgId;
                    orgPersonRole.PersonId = stuentId;
                    orgPersonRole.refId = StudentProgramAssociationObj.refId;
                    _context.OrganizationPersonRole.Add(orgPersonRole);
                   
                }
                if(StudentProgramAssociationObj.entryType !=null)
                {
                     perprgparticipation = Mapper.Map<PersonProgramParticipation>(StudentProgramAssociationObj);
                    perprgparticipation.OrganizationPersonRoleId = orgPersonRole.OrganizationPersonRoleId;
                    perprgparticipation.RecordStartDateTime = DateTime.Now;
                    _context.PersonProgramParticipation.Add(perprgparticipation);

                }
                if (StudentProgramAssociationObj.entryType != null || StudentProgramAssociationObj.exitType != null)
                {
                    var orgId = _context.Organization.Where(x => x.refId == StudentProgramAssociationObj.programRefId).Select(y => y.OrganizationId).FirstOrDefault();
                    var programTypeId = _context.OrganizationProgramType.Where(x => x.OrganizationId == orgId).Select(y => y.RefProgramTypeId).FirstOrDefault();
                    var program = (_context.RefProgramType.Where(x => x.RefProgramTypeId == programTypeId).Select(y => y.Description)).FirstOrDefault();
                    switch (program)
                    {
                        case MyEnumClass.AdultBasicEducation:
                            var prgPartABE = new ProgramParticipationAE();
                            prgPartABE.PersonProgramParticipationId = perprgparticipation.PersonProgramParticipationId;
                            prgPartABE.RecordStartDateTime = DateTime.Now;
                            _context.ProgramParticipationAE.Add(prgPartABE);
                            break;
                        case MyEnumClass.AdultEnglishasaSecondLanguage:
                            var prgPartAESL = new ProgramParticipationAE();
                            prgPartAESL.PersonProgramParticipationId = perprgparticipation.PersonProgramParticipationId;
                            prgPartAESL.RecordStartDateTime = DateTime.Now;
                            _context.ProgramParticipationAE.Add(prgPartAESL);
                            break;
                        case MyEnumClass.AdultSecondaryEducation:

                            var prgPartASE = new ProgramParticipationAE();
                            prgPartASE.PersonProgramParticipationId = perprgparticipation.PersonProgramParticipationId;
                            prgPartASE.RecordStartDateTime = DateTime.Now;
                            _context.ProgramParticipationAE.Add(prgPartASE);
                            break;
                        case MyEnumClass.AlternativeEducation:

                            var prgPartAE = new ProgramParticipationAE();
                            prgPartAE.PersonProgramParticipationId = perprgparticipation.PersonProgramParticipationId;
                            prgPartAE.RecordStartDateTime = DateTime.Now;
                            _context.ProgramParticipationAE.Add(prgPartAE);
                            break;
                        case MyEnumClass.CareerandTechnicalEducation:
                            var prgCTE = new ProgramParticipationCte();
                            prgCTE.PersonProgramParticipationId= perprgparticipation.PersonProgramParticipationId;
                            prgCTE.RecordStartDateTime = DateTime.Now;
                            _context.ProgramParticipationCte.Add(prgCTE);
                            break;

                        case MyEnumClass.MigrantEducation:
                            var prgME = new ProgramParticipationMigrant();
                            prgME.PersonProgramParticipationId = perprgparticipation.PersonProgramParticipationId;
                            prgME.RecordEndDateTime = DateTime.Now;
                            _context.ProgramParticipationMigrant.Add(prgME);
                            break;
                        case MyEnumClass.SpecialEducationServices:
                            var prgSES = new ProgramParticipationSpecialEducation();
                            prgSES.PersonProgramParticipationId = perprgparticipation.PersonProgramParticipationId;
                            prgSES.RecordStartDateTime = DateTime.Now;
                            _context.ProgramParticipationSpecialEducation.Add(prgSES);
                            break;

                        case MyEnumClass.TeacherprofessionaldevelopmentMentoring:
                            var prgTPDM = new ProgramParticipationTeacherPrep();
                            prgTPDM.PersonProgramParticipationId = perprgparticipation.PersonProgramParticipationId;
                            prgTPDM.RecordStartDateTime = DateTime.Now;
                            _context.ProgramParticipationTeacherPrep.Add(prgTPDM);
                            break;

                        default:
                            break;
                    }

                }
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
