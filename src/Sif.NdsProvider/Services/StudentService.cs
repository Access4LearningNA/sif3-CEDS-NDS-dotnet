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
    public class StudentService : IBasicProviderService<Student>
    {
        public Student Create(Student studentObj, bool? mustUseAdvisory = null, string zone = null, string context = null)
        {
            
            
            var person = new SIF.NDSDataModel.Person();

            person.refId = studentObj.refId;
            using (var _context = new CEDSContext(CommonMethods.GetConncetionString()))
            {
                _context.Person.Add(person);
                if (studentObj.name.nameOfRecord != null && studentObj.demographics != null)
                {
                    var stuDetails = Mapper.Map<PersonDetail>(studentObj);
                    var stuDemographics = Mapper.Map<PersonDetail>(studentObj);
                    stuDetails.PersonId = person.PersonId;
                    stuDetails.RecordStartDateTime = DateTime.Now;
                    _context.PersonDetail.Add(stuDetails);
                }
                if (studentObj.demographics.countryOfBirth != null)
                {
                    var stuBirthPlace = Mapper.Map<PersonBirthplace>(studentObj);
                    stuBirthPlace.PersonId = person.PersonId;
                    _context.PersonBirthplace.Add(stuBirthPlace);
                }
                if (studentObj.demographics.raceList != null)
                {
                    List<PersonDemographicRace> personRace = new List<PersonDemographicRace>();
                    foreach (var races in studentObj.demographics.raceList)
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
                if (studentObj.stateProvinceId != null)
                {
                    var stuAddress = Mapper.Map<PersonAddress>(studentObj);
                    stuAddress.PersonId = person.PersonId;
                    _context.PersonAddress.Add(stuAddress);
                }
                if (studentObj.disability != null)
                {
                    if (studentObj.disability.primaryDisability.codesetName == MyEnumClass.PrimaryDisabilityType)
                    {
                        var stuDisability = Mapper.Map<PersonDisability>(studentObj);
                        stuDisability.PersonId = person.PersonId;
                        stuDisability.RecordStartDateTime = DateTime.Now;
                        _context.PersonDisability.Add(stuDisability);
                    }
                }
                if (studentObj.emailList != null)
                {
                    var stuEmail = Mapper.Map<PersonEmailAddress>(studentObj);
                    stuEmail.PersonId = person.PersonId;
                    _context.PersonEmailAddress.Add(stuEmail);

                }
                if (studentObj.demographics.languageList != null)
                {
                    var stuLanguage = Mapper.Map<PersonLanguage>(studentObj);
                    stuLanguage.PersonId = person.PersonId;
                    _context.PersonLanguage.Add(stuLanguage);
                }
                if (studentObj.otherNameList != null)
                {
                    var stuOtherName = Mapper.Map<PersonOtherName>(studentObj);
                    stuOtherName.PersonId = person.PersonId;
                    _context.PersonOtherName.Add(stuOtherName);
                }
                if (studentObj.phoneNumberList != null)
                {
                    var stuPhoneDtls = Mapper.Map<PersonTelephone>(studentObj);
                    stuPhoneDtls.PersonId = person.PersonId;
                    _context.PersonTelephone.Add(stuPhoneDtls);
                }
                if (studentObj.mostRecentEnrollment != null)
                {
                    var orgPersonRole = new OrganizationPersonRole();
                    orgPersonRole.PersonId = person.PersonId;
                    orgPersonRole.RoleId = Convert.ToInt32(CommonMethods.GetCodesetCode("Role", "RoleId","Name", MyEnumClass.StudentRole));
                    orgPersonRole.OrganizationId = Convert.ToInt32(CommonMethods.GetCodesetCode("organizationidentifier", "OrganizationId", "Identifier", studentObj.mostRecentEnrollment.schoolLocalId.ToString()));
                    _context.OrganizationPersonRole.Add(orgPersonRole);
                    var stuPerProgParticipation = new PersonProgramParticipation();
                    if (studentObj.projectedGraduationYear != null)
                    {
                        var stuK12AcedamicRecord = Mapper.Map<K12StudentAcademicRecord>(studentObj);
                        stuK12AcedamicRecord.OrganizationPersonRoleId = orgPersonRole.OrganizationPersonRoleId;
                        _context.K12StudentAcademicRecord.Add(stuK12AcedamicRecord);
                    }
                    if (studentObj.onTimeGraduationYear != null)
                    {
                        var stuK12StudentCohort = Mapper.Map<K12StudentCohort>(studentObj);
                        stuK12StudentCohort.OrganizationPersonRoleId = orgPersonRole.OrganizationPersonRoleId;
                        _context.K12StudentCohort.Add(stuK12StudentCohort);
                    }
                    if (studentObj.disability.section504Status.ToLower() == "yes")
                    {
                        stuPerProgParticipation.OrganizationPersonRoleId = orgPersonRole.OrganizationPersonRoleId;
                        stuPerProgParticipation.RefParticipationTypeId = Convert.ToInt32(CommonMethods.GetCodesetCode("RefParticipationType", "RefParticipationTypeId", "Code", "Section504"));
                        stuPerProgParticipation.RecordStartDateTime = DateTime.Now;
                        _context.PersonProgramParticipation.Add(stuPerProgParticipation);
                    }
                    if (studentObj.neglectedDelinquent.ToString().ToLower() == "yes")
                    {
                        stuPerProgParticipation.RefParticipationTypeId = Convert.ToInt32(CommonMethods.GetCodesetCode("RefParticipationType", "RefParticipationTypeId", "Code", "Section504"));
                        stuPerProgParticipation.RecordStartDateTime = DateTime.Now;
                        stuPerProgParticipation.OrganizationPersonRoleId = orgPersonRole.OrganizationPersonRoleId;
                        _context.PersonProgramParticipation.Add(stuPerProgParticipation);
                    }
                    if (stuPerProgParticipation.PersonProgramParticipationId != 0)
                    {
                        var stuProgPartSplEducation = Mapper.Map<ProgramParticipationSpecialEducation>(studentObj);
                        stuProgPartSplEducation.PersonProgramParticipationId = stuPerProgParticipation.PersonProgramParticipationId;
                        stuProgPartSplEducation.RecordStartDateTime = DateTime.Now;
                        _context.ProgramParticipationSpecialEducation.Add(stuProgPartSplEducation);
                    }
                    if (studentObj.title1 != null && stuPerProgParticipation.PersonProgramParticipationId != 0)
                    {
                        var stuTitle = Mapper.Map<ProgramParticipationTitleI>(studentObj);
                        stuTitle.PersonProgramParticipationId = stuPerProgParticipation.PersonProgramParticipationId;
                        _context.ProgramParticipationTitleI.Add(stuTitle);
                    }
                }

                if (studentObj.economicDisadvantage.ToString().ToLower() == "yes")
                {
                    var perStatus = new PersonStatus();
                    perStatus.PersonId = person.PersonId;
                    perStatus.RefPersonStatusTypeId = Convert.ToInt32(CommonMethods.GetCodesetCode("RefPersonstatustype", "RefPersonStatusTypeId", "Code", MyEnumClass.EconomicDisadvantage));
                    perStatus.StatusValue =Convert.ToBoolean(YesNoUnknown.Yes);
                    perStatus.StatusStartDate = DateTime.Now;
                    _context.PersonStatus.Add(perStatus);
                }
                if (studentObj.ell.ToString().ToLower() == "yes")
                {
                    var perStatus = new PersonStatus();
                    perStatus.PersonId = person.PersonId;
                    perStatus.RefPersonStatusTypeId = Convert.ToInt32(CommonMethods.GetCodesetCode("RefPersonstatustype", "RefPersonStatusTypeId", "Code", MyEnumClass.EconomicDisadvantage));
                    perStatus.StatusValue = Convert.ToBoolean(YesNoUnknown.Yes);
                    perStatus.StatusStartDate = DateTime.Now;
                    _context.PersonStatus.Add(perStatus);
                }
                if (studentObj.demographics.languageList != null)
                {
                    var stuISO6393Language = Mapper.Map<RefISO6393Language>(studentObj);
                    _context.RefISO6393Language.Add(stuISO6393Language);
                }
                if (studentObj.electronicIdList != null || studentObj.externalId != null || studentObj.localId != null)
                {

                    List<PersonIdentifier> perIdentifier = new List<PersonIdentifier>();
                    if (studentObj.localId != null)
                    {
                        var stuLocalIdIdentifier = new PersonIdentifier();
                        stuLocalIdIdentifier.Identifier = studentObj.localId.idValue.ToString();
                        stuLocalIdIdentifier.PersonId = person.PersonId;
                        stuLocalIdIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(StudentLocalId.localIdPersonIdentificationSystemId);
                        //stuIdentifier.RefPersonalInformationVerificationId = "";
                        perIdentifier.Add(stuLocalIdIdentifier);
                    }
                    if (studentObj.externalId != null)
                    {
                        var stuExternalIdIdentifier = new PersonIdentifier();
                        stuExternalIdIdentifier.Identifier = studentObj.externalId.idValue.ToString();
                        stuExternalIdIdentifier.PersonId = person.PersonId;
                        stuExternalIdIdentifier.RefPersonIdentificationSystemId = Convert.ToInt32(StudentExternalId.externalIdPersonIdentificationSystemId);
                        // stuIdentifier.RefPersonalInformationVerificationId = "";
                        perIdentifier.Add(stuExternalIdIdentifier);
                    }
                    if (studentObj.electronicIdList != null)
                    {
                        var stuElectronicIdIdentifier = new PersonIdentifier();
                        foreach (var electronicId in studentObj.electronicIdList)
                        {

                            stuElectronicIdIdentifier.Identifier = electronicId.idValue.ToString();
                            stuElectronicIdIdentifier.PersonId = person.PersonId;
                            //stuIdentifier.RefPersonIdentificationSystemId = "";
                            // stuIdentifier.RefPersonalInformationVerificationId = "";
                        }
                        perIdentifier.Add(stuElectronicIdIdentifier);


                    }

                    _context.PersonIdentifier.AddRange(perIdentifier);

                }
                _context.SaveChanges();

            }
            return studentObj;
        }

        public void Delete(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public Student Retrieve(string refId, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Student> Retrieve(uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Student> Retrieve(Student obj, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public List<Student> Retrieve(IEnumerable<EqualCondition> conditions, uint? pageIndex = null, uint? pageSize = null, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Student obj, string zone = null, string context = null)
        {
            throw new NotImplementedException();
        }
    }
}
