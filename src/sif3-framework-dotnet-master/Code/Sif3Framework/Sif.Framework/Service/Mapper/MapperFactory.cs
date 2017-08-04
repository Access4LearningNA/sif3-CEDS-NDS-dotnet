/*
 * Copyright 2016 Systemic Pty Ltd
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using AutoMapper;
using Sif.Framework.Model.Infrastructure;
using Sif.Framework.Model.Requests;
using Sif.Framework.Model.Responses;
using Sif.Specification.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml;
using Environment = Sif.Framework.Model.Infrastructure.Environment;

namespace Sif.Framework.Service.Mapper
{

    public static class MapperFactory
    {

        class InfrastructureServicesConverter : ITypeConverter<infrastructureServiceType[], IDictionary<InfrastructureServiceNames, InfrastructureService>>
        {

            public IDictionary<InfrastructureServiceNames, InfrastructureService> Convert(ResolutionContext context)
            {
                ICollection<InfrastructureService> values = AutoMapper.Mapper.Map<infrastructureServiceType[], ICollection<InfrastructureService>>((infrastructureServiceType[])context.Items.Values);
                IDictionary<InfrastructureServiceNames, InfrastructureService> infrastructureServices = new Dictionary<InfrastructureServiceNames, InfrastructureService>();

                foreach (InfrastructureService infrastructureService in values)
                {
                    infrastructureServices.Add(infrastructureService.Name, infrastructureService);
                }

                return infrastructureServices;
            }

            public IDictionary<InfrastructureServiceNames, InfrastructureService> Convert(infrastructureServiceType[] source, IDictionary<InfrastructureServiceNames, InfrastructureService> destination, ResolutionContext context)
            {
                throw new NotImplementedException();
            }
        }

        class PropertiesConverter : ITypeConverter<propertyType[], IDictionary<string, Property>>
        {

            public IDictionary<string, Property> Convert(ResolutionContext context)
            {
                ICollection<Property> values = AutoMapper.Mapper.Map<propertyType[], ICollection<Property>>((propertyType[])context.Items.Values);
                IDictionary<string, Property> properties = new Dictionary<string, Property>();

                foreach (Property property in values)
                {
                    properties.Add(property.Name, property);
                }

                return properties;
            }

            public IDictionary<string, Property> Convert(propertyType[] source, IDictionary<string, Property> destination, ResolutionContext context)
            {
                throw new NotImplementedException();
            }
        }

        class ProvisionedZonesConverter : ITypeConverter<provisionedZoneType[], IDictionary<string, ProvisionedZone>>
        {

            public IDictionary<string, ProvisionedZone> Convert(ResolutionContext context)
            {
                ICollection<ProvisionedZone> values = AutoMapper.Mapper.Map<provisionedZoneType[], ICollection<ProvisionedZone>>((provisionedZoneType[])context.Items.Values);
                IDictionary<string, ProvisionedZone> provisionedZones = new Dictionary<string, ProvisionedZone>();

                foreach (ProvisionedZone provisionedZone in values)
                {
                    provisionedZones.Add(provisionedZone.SifId, provisionedZone);
                }

                return provisionedZones;
            }

            public IDictionary<string, ProvisionedZone> Convert(provisionedZoneType[] source, IDictionary<string, ProvisionedZone> destination, ResolutionContext context)
            {
                throw new NotImplementedException();
            }
        }

        class RightsConverter : ITypeConverter<rightType[], IDictionary<string, Right>>
        {

            public IDictionary<string, Right> Convert(ResolutionContext context)
            {
                ICollection<Right> values = AutoMapper.Mapper.Map<rightType[], ICollection<Right>>((rightType[])context.Items.Values);
                IDictionary<string, Right> rights = new Dictionary<string, Right>();

                foreach (Right right in values)
                {
                    rights.Add(right.Type, right);
                }

                return rights;
            }

            public IDictionary<string, Right> Convert(rightType[] source, IDictionary<string, Right> destination, ResolutionContext context)
            {
                throw new NotImplementedException();
            }
        }

        class StatesConverter : ITypeConverter<stateType[], IList<PhaseState>>
        {

            public IList<PhaseState> Convert(ResolutionContext context)
            {
                return new List<PhaseState>(AutoMapper.Mapper.Map<stateType[], ICollection<PhaseState>>((stateType[])context.Items.Values));
            }

            public IList<PhaseState> Convert(stateType[] source, IList<PhaseState> destination, ResolutionContext context)
            {
                throw new NotImplementedException();
            }
        }

        class PhasesConverter : ITypeConverter<phaseType[], IDictionary<string, Phase>>
        {

            public IDictionary<string, Phase> Convert(ResolutionContext context)
            {
                ICollection<Phase> values = AutoMapper.Mapper.Map<phaseType[], ICollection<Phase>>((phaseType[])context.Items.Values);
                IDictionary<string, Phase> phases = new Dictionary<string, Phase>();

                foreach (Phase phase in values)
                {
                    phases.Add(phase.Name, phase);
                }

                return phases;
            }

            public IDictionary<string, Phase> Convert(phaseType[] source, IDictionary<string, Phase> destination, ResolutionContext context)
            {
                throw new NotImplementedException();
            }
        }

        class DeleteIdsConverter : ITypeConverter<deleteIdType[], ICollection<string>>
        {

            public ICollection<string> Convert(ResolutionContext context)
            {
                ICollection<string> deleteIds = new List<string>();

                foreach (deleteIdType deleteId in (deleteIdType[])context.Items.Values)
                {
                    deleteIds.Add(deleteId.id);
                }

                return deleteIds;
            }

            public ICollection<string> Convert(deleteIdType[] source, ICollection<string> destination, ResolutionContext context)
            {
                throw new NotImplementedException();
            }
        }

        static MapperFactory()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ApplicationInfo, applicationInfoType>();
                cfg.CreateMap<applicationInfoType, ApplicationInfo>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());

                cfg.CreateMap<InfrastructureService, infrastructureServiceType>()
                    .ForMember(dest => dest.nameSpecified, opt => opt.UseValue<bool>(true))
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name));
                cfg.CreateMap<infrastructureServiceType, InfrastructureService>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name));
                cfg.CreateMap<infrastructureServiceType[], IDictionary<InfrastructureServiceNames, InfrastructureService>>()
                    .ConvertUsing<InfrastructureServicesConverter>();

                cfg.CreateMap<Environment, environmentType>()
                    .ForMember(dest => dest.infrastructureServices, opt => opt.MapFrom(src => src.InfrastructureServices.Values))
                    .ForMember(dest => dest.provisionedZones, opt => opt.MapFrom(src => src.ProvisionedZones.Values))
                    .ForMember(dest => dest.typeSpecified, opt => opt.UseValue<bool>(true));
                cfg.CreateMap<environmentType, Environment>();

                cfg.CreateMap<ProductIdentity, productIdentityType>();
                cfg.CreateMap<productIdentityType, ProductIdentity>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());

                cfg.CreateMap<Property, propertyType>();
                cfg.CreateMap<propertyType, Property>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
                cfg.CreateMap<propertyType[], IDictionary<string, Property>>()
                    .ConvertUsing<PropertiesConverter>();

                cfg.CreateMap<ProvisionedZone, provisionedZoneType>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.SifId));
                cfg.CreateMap<provisionedZoneType, ProvisionedZone>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.SifId, opt => opt.MapFrom(src => src.id));
                cfg.CreateMap<provisionedZoneType[], IDictionary<string, ProvisionedZone>>()
                    .ConvertUsing<ProvisionedZonesConverter>();

                cfg.CreateMap<Right, rightType>();
                cfg.CreateMap<rightType, Right>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
                cfg.CreateMap<rightType[], IDictionary<string, Right>>()
                    .ConvertUsing<RightsConverter>();

                cfg.CreateMap<Model.Infrastructure.Service, serviceType>()
                    .ForMember(dest => dest.rights, opt => opt.MapFrom(src => src.Rights.Values));
                cfg.CreateMap<serviceType, Model.Infrastructure.Service>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());

                cfg.CreateMap<Zone, zoneType>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.SifId))
                    .ForMember(dest => dest.properties, opt => opt.MapFrom(src => src.Properties.Values));
                cfg.CreateMap<zoneType, Zone>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.SifId, opt => opt.MapFrom(src => src.id));

                cfg.CreateMap<PhaseState, stateType>()
                    .ForMember(dest => dest.createdSpecified, opt => opt.MapFrom(src => src.Created != null))
                    .ForMember(dest => dest.lastModifiedSpecified, opt => opt.MapFrom(src => src.LastModified != null));
                cfg.CreateMap<stateType, PhaseState>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
                cfg.CreateMap<stateType[], IList<PhaseState>>()
                    .ConvertUsing<StatesConverter>();

                cfg.CreateMap<Phase, phaseType>()
                    .ForMember(dest => dest.rights, opt => opt.MapFrom(src => src.Rights.Values))
                    .ForMember(dest => dest.statesRights, opt => opt.MapFrom(src => src.StatesRights.Values));
                cfg.CreateMap<phaseType, Phase>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
                cfg.CreateMap<phaseType[], IDictionary<string, Phase>>()
                    .ConvertUsing<PhasesConverter>();

                cfg.CreateMap<Job, jobType>()
                    .ForMember(dest => dest.phases, opt => opt.MapFrom(src => src.Phases.Values))
                    .ForMember(dest => dest.createdSpecified, opt => opt.MapFrom(src => src.Created != null))
                    .ForMember(dest => dest.lastModifiedSpecified, opt => opt.MapFrom(src => src.LastModified != null))
                    .ForMember(dest => dest.stateSpecified, opt => opt.MapFrom(src => src.State != null))
                    .ForMember(dest => dest.timeout, opt => opt.MapFrom(src => XmlConvert.ToString(src.Timeout)));
                cfg.CreateMap<jobType, Job>()
                    .ForMember(dest => dest.Timeout, opt => opt.MapFrom(src => XmlConvert.ToTimeSpan(src.timeout)));

                cfg.CreateMap<ResponseError, errorType>();
                cfg.CreateMap<errorType, ResponseError>();

                cfg.CreateMap<CreateStatus, createType>();
                cfg.CreateMap<createType, CreateStatus>();

                cfg.CreateMap<DeleteStatus, deleteStatus>();
                cfg.CreateMap<deleteStatus, DeleteStatus>();

                cfg.CreateMap<UpdateStatus, updateType>();
                cfg.CreateMap<updateType, UpdateStatus>();

                cfg.CreateMap<MultipleCreateResponse, createResponseType>()
                    .ForMember(dest => dest.creates, opt => opt.MapFrom(src => src.StatusRecords));
                cfg.CreateMap<createResponseType, MultipleCreateResponse>()
                    .ForMember(dest => dest.StatusRecords, opt => opt.MapFrom(src => src.creates));

                cfg.CreateMap<MultipleDeleteResponse, deleteResponseType>()
                    .ForMember(dest => dest.deletes, opt => opt.MapFrom(src => src.StatusRecords));
                cfg.CreateMap<deleteResponseType, MultipleDeleteResponse>()
                    .ForMember(dest => dest.StatusRecords, opt => opt.MapFrom(src => src.deletes));

                cfg.CreateMap<MultipleUpdateResponse, updateResponseType>()
                    .ForMember(dest => dest.updates, opt => opt.MapFrom(src => src.StatusRecords));
                cfg.CreateMap<updateResponseType, MultipleUpdateResponse>()
                    .ForMember(dest => dest.StatusRecords, opt => opt.MapFrom(src => src.updates));

                cfg.CreateMap<deleteIdType[], ICollection<string>>()
                    .ConvertUsing<DeleteIdsConverter>();

                cfg.CreateMap<deleteRequestType, MultipleDeleteRequest>()
                    .ForMember(dest => dest.RefIds, opt => opt.MapFrom(src => src.deletes));
            });

            AutoMapper.Mapper.Configuration.AssertConfigurationIsValid();
        }

        public static D CreateInstance<S, D>(S source)
        {
            D destination = default(D);
            destination = AutoMapper.Mapper.Map<D>(source);
            return destination;
        }

        public static ICollection<D> CreateInstances<S, D>(IEnumerable<S> source)
        {
            ICollection<D> destination = null;
            destination = AutoMapper.Mapper.Map<IEnumerable<S>, ICollection<D>>(source);
            return destination;
        }

    }

}
