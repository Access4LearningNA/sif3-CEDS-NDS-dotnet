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
using System.Linq;

namespace Sif.NdsProvider.Services
{
    public class ProgramService : IBasicProviderService<Program>
    {
        public Program Create(Program programObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
           
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                var org = new Organization();
                org.refId = programObj.refId;
                
                if(programObj.programName !=null)
                {
                    _context.Organization.Add(org);
                    var prg = new SIF.NDSDataModel.Program();
                    prg.OrganizationId = org.OrganizationId;
                    _context.Program.Add(prg);
                    
                    var orgDetail = Mapper.Map<OrganizationDetail>(programObj);
                    orgDetail.OrganizationId = org.OrganizationId;
                    _context.OrganizationDetail.Add(orgDetail);
                }
                if(programObj.programType1 !=null)
                {
                    var orgPrgType = Mapper.Map<OrganizationProgramType>(programObj);
                    orgPrgType.OrganizationId = org.OrganizationId;
                    _context.OrganizationProgramType.Add(orgPrgType);
                }
                if(programObj.managingSchoolRefId !=null || programObj.managingSchoolLocalId !=null)
                {
                    var parentOrgId = 0;
                    if (programObj.managingSchoolRefId != null)
                     parentOrgId = _context.Organization.Where(x => x.refId == programObj.managingSchoolRefId).Select(y => y.OrganizationId).FirstOrDefault();
                    if (programObj.managingSchoolLocalId != null)
                        parentOrgId = _context.OrganizationIdentifier.Where(x => x.Identifier == programObj.managingSchoolLocalId.idValue.ToString()).Select(y => y.OrganizationId).FirstOrDefault();
                    var orgRelationship = new OrganizationRelationship();
                    orgRelationship.Parent_OrganizationId = parentOrgId;
                    orgRelationship.OrganizationId = org.OrganizationId;
                    _context.OrganizationRelationship.Add(orgRelationship);
                }
                if(programObj.programIdentifier !=null)
                {
                    var prgIdentifier = new OrganizationIdentifier();
                    var refOrgIdentificationSystemId = _context.RefOrganizationIdentificationSystem.Where(x => x.RefOrganizationIdentifierTypeId == 15 && x.Code == programObj.programIdentifier.idType.code.ToString()).Select(y => y.RefOrganizationIdentificationSystemId).FirstOrDefault();
                    if (refOrgIdentificationSystemId == 0)
                        refOrgIdentificationSystemId = Convert.ToInt32(PrgoramIdetifierLocalId.refOrgIdentificationSystemId);
                    var refOrgIdentifierTypeId = PrgoramIdetifierLocalId.refOrgIdentifierTypeId;
                    prgIdentifier.RefOrganizationIdentificationSystemId = refOrgIdentificationSystemId;
                    prgIdentifier.RefOrganizationIdentifierTypeId = Convert.ToInt32(refOrgIdentifierTypeId);
                    prgIdentifier.OrganizationId = org.OrganizationId;
                    _context.OrganizationIdentifier.Add(prgIdentifier);
                }
                if(programObj.fundingSourceList !=null)
                {
                    var finAccount = Mapper.Map<FinancialAccount>(programObj);
                    _context.FinancialAccount.Add(finAccount);

                }
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
