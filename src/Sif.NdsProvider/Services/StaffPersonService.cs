using AutoMapper;
using Sif.Framework.Model.Query;
using Sif.Framework.Service.Providers;
using Sif.Framework.Service.Serialisation;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Services.Commons;
using SIF.NDSDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Person = SIF.NDSDataModel.Person;

namespace Sif.NdsProvider.Services
{
    public class StaffPersonService : IBasicProviderService<StaffPerson>
    {
        public StaffPerson Create(StaffPerson staffPersonObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            var person = new Person();

            person.refId = staffPersonObj.refId;
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                _context.Person.Add(person);
                if (staffPersonObj.name.nameOfRecord != null && staffPersonObj.demographics != null)
                {
                    var staffDetails = Mapper.Map<PersonDetail>(staffPersonObj);
                    var staffDemographics = Mapper.Map<PersonDetail>(staffPersonObj);
                    staffDetails.PersonId = person.PersonId;
                    staffDetails.RecordStartDateTime = DateTime.Now;
                    _context.PersonDetail.Add(staffDetails);
                }
                if (staffPersonObj.demographics.raceList != null)
                {
                    List<PersonDemographicRace> personRace = new List<PersonDemographicRace>();
                    foreach (var races in staffPersonObj.demographics.raceList)
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
                if (staffPersonObj.emailList != null)
                {
                    var staffEmail = Mapper.Map<PersonEmailAddress>(staffPersonObj);
                    staffEmail.PersonId = person.PersonId;
                    _context.PersonEmailAddress.Add(staffEmail);

                }
                if (staffPersonObj.phoneNumberList != null)
                {
                    var staffPhoneDtls = Mapper.Map<PersonTelephone>(staffPersonObj);
                    staffPhoneDtls.PersonId = person.PersonId;
                    _context.PersonTelephone.Add(staffPhoneDtls);
                }
                if(staffPersonObj.title !=null)
                {
                    var staffTitle = Mapper.Map<StaffEmployment>(staffPersonObj);
                    //staffTitle.OrganizationPersonRoleId=
                    _context.StaffEmployment.Add(staffTitle);

                }
                if(staffPersonObj.otherNameList !=null)
                {
                    var staffOtherName = Mapper.Map<PersonOtherName>(staffPersonObj);
                    staffOtherName.PersonId = person.PersonId;
                    _context.PersonOtherName.Add(staffOtherName);
                }
                if(staffPersonObj.demographics.languageList !=null)
                {
                    var staffLang = Mapper.Map<PersonLanguage>(staffPersonObj);
                    staffLang.PersonId = person.PersonId;
                    _context.PersonLanguage.Add(staffLang);
                }
                List<PersonIdentifier> perIdentifier = new List<PersonIdentifier>();
                if (staffPersonObj.localId != null)
                {
                    var refPersonIdentificationSystemId = _context.RefPersonIdentificationSystem.Where(x => x.RefPersonIdentifierTypeId == 3 && x.Code == staffPersonObj.localId.idType.code.ToString()).Select(y => y.RefPersonIdentificationSystemId).FirstOrDefault();
                    var stuLocalIdIdentifier = new PersonIdentifier();
                    stuLocalIdIdentifier.Identifier = staffPersonObj.localId.idValue.ToString();
                    stuLocalIdIdentifier.PersonId = person.PersonId;
                    stuLocalIdIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(refPersonIdentificationSystemId);
                    perIdentifier.Add(stuLocalIdIdentifier);
                }
                if (staffPersonObj.externalId != null)
                {
                    var refPersonIdentificationSystemId = _context.RefPersonIdentificationSystem.Where(x => x.RefPersonIdentifierTypeId == 3 && x.Code == staffPersonObj.externalId.idType.code.ToString()).Select(y => y.RefPersonIdentificationSystemId).FirstOrDefault();
                    var stuExternalIdIdentifier = new PersonIdentifier();
                    stuExternalIdIdentifier.Identifier = staffPersonObj.externalId.idValue.ToString();
                    stuExternalIdIdentifier.PersonId = person.PersonId;
                    stuExternalIdIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(refPersonIdentificationSystemId);
                    perIdentifier.Add(stuExternalIdIdentifier);
                }
                if (staffPersonObj.electronicIdList != null)
                {
                    var stuElectronicIdIdentifier = new PersonIdentifier();
                    foreach (var electronicId in staffPersonObj.electronicIdList)
                    {
                        stuElectronicIdIdentifier.Identifier = electronicId.idValue.ToString();
                        stuElectronicIdIdentifier.PersonId = person.PersonId;
                    }

                    perIdentifier.Add(stuElectronicIdIdentifier);
                }
                if (perIdentifier.Count > 0)
                    _context.PersonIdentifier.AddRange(perIdentifier);

                    _context.SaveChanges();
            }
                return staffPersonObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public StaffPerson Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<StaffPerson> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<StaffPerson> Retrieve(StaffPerson obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<StaffPerson> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(StaffPerson obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }
    }
}
