﻿#region Namespace
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
#endregion

namespace Sif.NdsProvider.Services
{
    public class StudentSchoolAsociationService : IBasicProviderService<StudentSchoolAssociation>
    {
        public StudentSchoolAssociation Create(StudentSchoolAssociation studentSchoolAssociationObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            string refId = Guid.NewGuid().ToString();
            studentSchoolAssociationObj.refId = refId;
            var optionsBuilder = new DbContextOptionsBuilder<CEDSContext>();
            optionsBuilder.UseSqlServer("Server=10.10.1.219;Database=CEDS_NDS;User Id=SIFNDSAdmin;password=admin#123;MultipleActiveResultSets=true;App=EntityFramework");
            var k12stuEnrollment = new K12StudentEnrollment();
            using (var _context = new CEDSContext(optionsBuilder.Options))
            {
               
            
               if(studentSchoolAssociationObj.entryDate !=null)
                {
                    var orgPersonRole = new OrganizationPersonRole();
                    orgPersonRole.EntryDate = studentSchoolAssociationObj.entryDate;
                    orgPersonRole.ExitDate = studentSchoolAssociationObj.exitDate;
                    orgPersonRole.PersonId = (_context.Person.Where(i => i.refId == studentSchoolAssociationObj.studentRefId.ToString()).Select(x => x.PersonId).FirstOrDefault());
                    orgPersonRole.OrganizationId= (_context.Organization.Where(i => i.refId == studentSchoolAssociationObj.schoolRefId.ToString()).Select(x => x.OrganizationId).FirstOrDefault());
                    orgPersonRole.RoleId = Convert.ToInt32(_context.Role.Where(x => x.Name == MyEnumClass.StudentRole).Select(y => y.RoleId).FirstOrDefault());
                    orgPersonRole.refId = Guid.NewGuid().ToString();
                    _context.OrganizationPersonRole.Add(orgPersonRole);
                    if (studentSchoolAssociationObj.entryType != null)
                    {
                        var k12Enrollment = Mapper.Map<K12StudentEnrollment>(studentSchoolAssociationObj);
                        k12Enrollment.RecordStartDateTime = DateTime.Now;
                        k12Enrollment.OrganizationPersonRoleId= Convert.ToInt32(orgPersonRole.OrganizationPersonRoleId);
                        _context.K12StudentEnrollment.Add(k12Enrollment);
                    }
                    var elEnrollement = Mapper.Map<ELEnrollment>(studentSchoolAssociationObj);
                        elEnrollement.OrganizationPersonRoleId = Convert.ToInt32(orgPersonRole.OrganizationPersonRoleId);
                        _context.ELEnrollment.Add(elEnrollement);
                }
                _context.SaveChanges();
            }
                return studentSchoolAssociationObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public StudentSchoolAssociation Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<StudentSchoolAssociation> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<StudentSchoolAssociation> Retrieve(StudentSchoolAssociation obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<StudentSchoolAssociation> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentSchoolAssociation obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }
    }
}
