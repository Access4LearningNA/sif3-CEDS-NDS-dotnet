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
    public class AddressService : IBasicProviderService<Address>
    {
        public Address Create(Address addrObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
           
          
                var location = new Location();
                using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
                {
                _context.Location.Add(location);
                    if(addrObj !=null)
                    {
                    var locAddress = Mapper.Map<LocationAddress>(addrObj);
                    locAddress.LocationId = location.LocationId;
                    _context.LocationAddress.Add(locAddress);

                    }
                    _context.SaveChanges();
                }

            
            return addrObj;
        }

        

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public Address Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Address> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Address> Retrieve(Address obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Address> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Address obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }
    }
}
