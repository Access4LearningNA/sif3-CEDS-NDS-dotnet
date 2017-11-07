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
    public class SchoolCalendarItemService : IBasicProviderService<SchoolCalendarItem>
    {
        public SchoolCalendarItem Create(SchoolCalendarItem schoolCalendarItemObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            string refId = Guid.NewGuid().ToString();
            schoolCalendarItemObj.refId = refId;
            var optionsBuilder = new DbContextOptionsBuilder<CEDSContext>();
            optionsBuilder.UseSqlServer("Server=10.10.1.219;Database=CEDS_NDS;User Id=SIFNDSAdmin;password=admin#123;MultipleActiveResultSets=true;App=EntityFramework");
            using (var _context = new CEDSContext(optionsBuilder.Options))
            {
                if(schoolCalendarItemObj !=null)
                {
                    var organizationId = _context.Organization.Where(x => x.refId == schoolCalendarItemObj.schoolRefId).Select(y => y.OrganizationId).FirstOrDefault(); 
                    var calEvent = Mapper.Map<OrganizationCalendarEvent>(schoolCalendarItemObj);
                    calEvent.OrganizationCalendarId = _context.OrganizationCalendar.Where(x => x.OrganizationId == organizationId).Select(y => y.OrganizationCalendarId).FirstOrDefault();
                    _context.OrganizationCalendarEvent.Add(calEvent);
                }
                _context.SaveChanges();
            }
                return schoolCalendarItemObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public SchoolCalendarItem Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<SchoolCalendarItem> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<SchoolCalendarItem> Retrieve(SchoolCalendarItem obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<SchoolCalendarItem> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(SchoolCalendarItem obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

      
    }
}
