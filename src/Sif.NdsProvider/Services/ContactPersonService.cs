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
    public class ContactPersonService : IBasicProviderService<ContactPerson>
    {
        public ContactPerson Create(ContactPerson conPersonObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            var person = new SIF.NDSDataModel.Person();
            person.refId = conPersonObj.refId;
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                _context.Person.Add(person);
                if (conPersonObj != null)
                {
                    if (conPersonObj.name.nameOfRecord != null && conPersonObj.demographics != null)
                    {
                        var perDetails = Mapper.Map<PersonDetail>(conPersonObj);
                        var perDemographics = Mapper.Map<PersonDetail>(conPersonObj);
                        perDetails.PersonId = person.PersonId;
                        perDetails.RecordStartDateTime = DateTime.Now;
                        _context.PersonDetail.Add(perDetails);
                    }
                    if (conPersonObj.demographics.countryOfBirth != null)
                    {
                        var perBirthPlace = Mapper.Map<PersonBirthplace>(conPersonObj);
                        perBirthPlace.PersonId = person.PersonId;
                        _context.PersonBirthplace.Add(perBirthPlace);
                    }
                    if (conPersonObj.demographics.raceList != null)
                    {
                        List<PersonDemographicRace> personRace = new List<PersonDemographicRace>();
                        foreach (var races in conPersonObj.demographics.raceList)
                        {
                            var race = new PersonDemographicRace();
                            race.RefRaceId = Convert.ToInt32(CommonMethods.GetCodesetCode("RefRace", "RefRaceId", "Code", races.code.ToString()));
                            race.RecordStartDateTime = DateTime.Now;
                            race.PersonId = person.PersonId;
                            personRace.Add(race);
                        }
                        if (personRace.Count > 0)
                        {
                            _context.PersonDemographicRace.AddRange(personRace);
                        }
                    }
                    if (conPersonObj.emailList != null)
                    {
                        var stuEmail = Mapper.Map<PersonEmailAddress>(conPersonObj);
                        stuEmail.PersonId = person.PersonId;
                        _context.PersonEmailAddress.Add(stuEmail);

                    }
                    if (conPersonObj.demographics.languageList != null)
                    {
                        var stuLanguage = Mapper.Map<PersonLanguage>(conPersonObj);
                        stuLanguage.PersonId = person.PersonId;
                        _context.PersonLanguage.Add(stuLanguage);
                    }
                    if (conPersonObj.otherNameList != null)
                    {
                        var stuOtherName = Mapper.Map<PersonOtherName>(conPersonObj);
                        stuOtherName.PersonId = person.PersonId;
                        _context.PersonOtherName.Add(stuOtherName);
                    }
                    if (conPersonObj.phoneNumberList != null)
                    {
                        var perPhoneDtls = Mapper.Map<PersonTelephone>(conPersonObj);
                        perPhoneDtls.PersonId = person.PersonId;
                        _context.PersonTelephone.Add(perPhoneDtls);
                    }
                    if (conPersonObj.demographics.languageProficiency != null)
                    {
                        var perStatus = Mapper.Map<PersonStatus>(conPersonObj);
                        perStatus.PersonId = person.PersonId;
                        perStatus.StatusValue = Convert.ToBoolean(YesNoUnknown.Yes);
                        perStatus.StatusStartDate = DateTime.Now;
                        _context.PersonStatus.Add(perStatus);
                    }
                    if (conPersonObj.electronicIdList != null || conPersonObj.externalId != null || conPersonObj.localId != null)
                    {

                        List<PersonIdentifier> perIdentifier = new List<PersonIdentifier>();
                        if (conPersonObj.localId != null)
                        {
                            var perLocalIdIdentifier = new PersonIdentifier();
                            perLocalIdIdentifier.Identifier = conPersonObj.localId.idValue.ToString();
                            perLocalIdIdentifier.PersonId = person.PersonId;
                            perLocalIdIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(StudentLocalId.localIdPersonIdentificationSystemId);
                            //stuIdentifier.RefPersonalInformationVerificationId = "";
                            perIdentifier.Add(perLocalIdIdentifier);
                        }
                        if (conPersonObj.externalId != null)
                        {
                            var perExternalIdIdentifier = new PersonIdentifier();
                            perExternalIdIdentifier.Identifier = conPersonObj.externalId.idValue.ToString();
                            perExternalIdIdentifier.PersonId = person.PersonId;
                            perExternalIdIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(StudentExternalId.externalIdPersonIdentificationSystemId);
                            // stuIdentifier.RefPersonalInformationVerificationId = "";
                            perIdentifier.Add(perExternalIdIdentifier);
                        }
                        if (conPersonObj.electronicIdList != null)
                        {
                            var perElectronicIdIdentifier = new PersonIdentifier();
                            foreach (var electronicId in conPersonObj.electronicIdList)
                            {
                                perElectronicIdIdentifier.Identifier = electronicId.idValue.ToString();
                                perElectronicIdIdentifier.PersonId = person.PersonId;
                                //stuIdentifier.RefPersonIdentificationSystemId = "";
                                // stuIdentifier.RefPersonalInformationVerificationId = "";
                            }
                            perIdentifier.Add(perElectronicIdIdentifier);
                        }

                        _context.PersonIdentifier.AddRange(perIdentifier);
                    }
                }
                _context.SaveChanges();

            }
            return conPersonObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public ContactPerson Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<ContactPerson> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<ContactPerson> Retrieve(ContactPerson obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<ContactPerson> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(ContactPerson obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }
    }
}
