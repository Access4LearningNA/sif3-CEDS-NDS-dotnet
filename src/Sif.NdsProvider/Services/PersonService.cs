using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sif.Framework.Model.Query;
using Sif.Framework.Service.Providers;
using Person=Sif.NdsProvider.Model.Person;
using Sif.NdsProvider.Services.Commons;
using Sif.Specification.DataModel.Us;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;

namespace Sif.NdsProvider.Services
{
    public class PersonService : IBasicProviderService<Person>
    {
        public Person Create(Person personObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            var person = new SIF.NDSDataModel.Person();
            person.refId = personObj.refId;
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                _context.Person.Add(person);
                if (personObj != null)
                {
                    if (personObj.name.nameOfRecord != null && personObj.demographics != null)
                    {
                        var perDetails = Mapper.Map<PersonDetail>(personObj);
                        var perDemographics = Mapper.Map<PersonDetail>(personObj);
                        perDetails.PersonId = person.PersonId;
                        perDetails.RecordStartDateTime = DateTime.Now;
                        _context.PersonDetail.Add(perDetails);
                    }
                    if (personObj.demographics.countryOfBirth != null)
                    {
                        var perBirthPlace = Mapper.Map<PersonBirthplace>(personObj);
                        perBirthPlace.PersonId = person.PersonId;
                        _context.PersonBirthplace.Add(perBirthPlace);
                    }
                    if (personObj.demographics.raceList != null)
                    {
                        List<PersonDemographicRace> personRace = new List<PersonDemographicRace>();
                        foreach (var races in personObj.demographics.raceList)
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
                    if (personObj.emailList != null)
                    {
                        var stuEmail = Mapper.Map<PersonEmailAddress>(personObj);
                        stuEmail.PersonId = person.PersonId;
                        _context.PersonEmailAddress.Add(stuEmail);

                    }
                    if (personObj.demographics.languageList != null)
                    {
                        var stuLanguage = Mapper.Map<PersonLanguage>(personObj);
                        stuLanguage.PersonId = person.PersonId;
                        _context.PersonLanguage.Add(stuLanguage);
                    }
                    if (personObj.otherNameList != null)
                    {
                        var stuOtherName = Mapper.Map<PersonOtherName>(personObj);
                        stuOtherName.PersonId = person.PersonId;
                        _context.PersonOtherName.Add(stuOtherName);
                    }
                    if (personObj.phoneNumberList != null)
                    {
                        var perPhoneDtls = Mapper.Map<PersonTelephone>(personObj);
                        perPhoneDtls.PersonId = person.PersonId;
                        _context.PersonTelephone.Add(perPhoneDtls);
                    }
                    if(personObj.demographics.languageProficiency !=null)
                    {
                        var perStatus = Mapper.Map<PersonStatus>(personObj);
                        perStatus.PersonId = person.PersonId;
                        perStatus.StatusValue = Convert.ToBoolean(YesNoUnknown.Yes);
                        perStatus.StatusStartDate = DateTime.Now;
                        _context.PersonStatus.Add(perStatus);
                    }
                    if (personObj.electronicIdList != null || personObj.externalId != null || personObj.localId != null)
                    {

                        List<PersonIdentifier> perIdentifier = new List<PersonIdentifier>();
                        if (personObj.localId != null)
                        {
                            var perLocalIdIdentifier = new PersonIdentifier();
                            perLocalIdIdentifier.Identifier = personObj.localId.idValue.ToString();
                            perLocalIdIdentifier.PersonId = person.PersonId;
                            perLocalIdIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(StudentLocalId.localIdPersonIdentificationSystemId);
                            //stuIdentifier.RefPersonalInformationVerificationId = "";
                            perIdentifier.Add(perLocalIdIdentifier);
                        }
                        if (personObj.externalId != null)
                        {
                            var perExternalIdIdentifier = new PersonIdentifier();
                            perExternalIdIdentifier.Identifier = personObj.externalId.idValue.ToString();
                            perExternalIdIdentifier.PersonId = person.PersonId;
                            perExternalIdIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(StudentExternalId.externalIdPersonIdentificationSystemId);
                            // stuIdentifier.RefPersonalInformationVerificationId = "";
                            perIdentifier.Add(perExternalIdIdentifier);
                        }
                        if (personObj.electronicIdList != null)
                        {
                            var perElectronicIdIdentifier = new PersonIdentifier();
                            foreach (var electronicId in personObj.electronicIdList)
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
            return personObj;
        }

       
        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public Model.Person Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Model.Person> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Model.Person> Retrieve(Model.Person obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Model.Person> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Model.Person obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }
    }
}
