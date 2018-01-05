using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sif.Framework.Model.Query;
using Sif.Framework.Service.Providers;
using Sif.Framework.Service.Serialisation;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Services.Commons;
using Sif.Specification.DataModel.Us;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sif.NdsProvider.Services
{
    public class ContactPersonAssociationService : IBasicProviderService<ContactPersonAssociation>
    {
        public ContactPersonAssociation Create(ContactPersonAssociation conPerAssociationObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                var perRelationship = new PersonRelationship();
                if(conPerAssociationObj !=null)
                {
                    var perId = (_context.Person.Where(x => x.refId == conPerAssociationObj.personRefId.ToString()).Select(y => y.PersonId).FirstOrDefault());
                    var contPersonId = (_context.Person.Where(x => x.refId == conPerAssociationObj.contactPersonRefId.ToString()).Select(y => y.PersonId).FirstOrDefault());
                    perRelationship = Mapper.Map<PersonRelationship>(conPerAssociationObj);
                    perRelationship.PersonId = perId;
                    perRelationship.RelatedPersonId =contPersonId;
                    _context.PersonRelationship.Add(perRelationship);
                }
            }
                return conPerAssociationObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public ContactPersonAssociation Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<ContactPersonAssociation> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<ContactPersonAssociation> Retrieve(ContactPersonAssociation obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<ContactPersonAssociation> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(ContactPersonAssociation obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }
    }
}
