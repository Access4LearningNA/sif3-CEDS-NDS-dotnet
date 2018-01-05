using FluentValidation;
using Sif.NdsProvider.Services.Commons;
using Sif.Specification.DataModel.Us;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sif.NdsProvider.Validators
{
    public class StudentValidator: AbstractValidator<Model.Student>
    {
        public StudentValidator()
        {
            try
            {
                //Family Name
                RuleFor(p => p.name).NotEmpty();
                RuleFor(p => p.name.nameOfRecord).NotEmpty().When(t => t.name != null);
                RuleFor(p => p.name.nameOfRecord.familyName).NotEmpty().When(t => t.name != null && t.name.nameOfRecord != null);
                RuleFor(p => p.name.nameOfRecord.familyName).Length(1, 50).When(t => t.name != null && t.name.nameOfRecord != null);
                //Given Name
                RuleFor(p => p.name).NotEmpty();
                RuleFor(p => p.name.nameOfRecord).NotEmpty().When(t => t.name != null);
                RuleFor(p => p.name.nameOfRecord.givenName).NotEmpty().When(t => t.name != null && t.name.nameOfRecord != null);
                RuleFor(p => p.name.nameOfRecord.givenName).Length(1, 50).When(t => t.name != null && t.name.nameOfRecord != null);
                //MiddleName
                RuleFor(p => p.name).NotEmpty();
                RuleFor(p => p.name.nameOfRecord).NotEmpty().When(t => t.name != null);
                RuleFor(p => p.name.nameOfRecord.middleName).Length(1, 50).When(t => t.name != null && t.name.nameOfRecord != null);
                //Suffix
                RuleFor(p => p.name).NotEmpty();
                RuleFor(p => p.name.nameOfRecord).NotEmpty().When(t => t.name != null);
                RuleFor(p => p.name.nameOfRecord.suffix).Length(0, 20).When(t => t.name != null && t.name.nameOfRecord != null);
                //Prefix
                RuleFor(p => p.name).NotEmpty();
                RuleFor(p => p.name.nameOfRecord).NotEmpty().When(t => t.name != null);
                RuleFor(p => p.name.nameOfRecord.prefix).Length(0, 50).When(t => t.name != null && t.name.nameOfRecord != null);
                //PrefferedFamilyName
                RuleFor(p => p.name).NotEmpty();
                RuleFor(p => p.name.nameOfRecord).NotEmpty().When(t => t.name != null);
                RuleFor(p => p.name.nameOfRecord.preferredFamilyName).Length(0, 50).When(t => t.name != null && t.name.nameOfRecord != null);
                //PrefferedGivenName
                RuleFor(p => p.name).NotEmpty();
                RuleFor(p => p.name.nameOfRecord).NotEmpty().When(t => t.name != null);
                RuleFor(p => p.name.nameOfRecord.preferredGivenName).Length(0, 50).When(t => t.name != null && t.name.nameOfRecord != null);
                //BirthDateVerification
                RuleFor(p => p.demographics.birthDateVerification).Length(1, 120).When(t => t.demographics != null && t.demographics.birthDateVerification != null);
                //LocalId
                RuleFor(p => p.localId).NotEmpty();
                RuleFor(p => p.localId.idValue).NotEmpty().When(t => t.localId != null);
                RuleFor(p => p.localId.idValue.ToString()).Length(0, 80).When(t => t.localId != null && t.localId.idValue != null);
                RuleFor(p => p.localId.idType.codesetName.ToString()).Must(x => x.ToString() == MyEnumClass.StudentIdentificationSystem).When(t => t.localId != null && t.localId.idType != null && t.localId.idType.codesetName != null)
                    .WithMessage("Invalid CodesetName for LocalId.");
                RuleFor(p => p.localId.idType.code.ToString()).Must(x => CommonMethods.GetCodesetCode("RefPersonIdentificationSystem", "RefPersonIdentificationSystemId", "Code", x.ToString()) != null)//.When(t => t.localId != null && t.localId.idType != null && t.localId.idType.codesetName != null)
                .WithMessage("Invalid Code for LocalId.");
               // ExternalId
                RuleFor(p => p.externalId).NotEmpty();
                RuleFor(p => p.externalId.idValue).NotEmpty().When(t => t.externalId != null);
                RuleFor(p => p.externalId.idValue.ToString()).Length(0, 80).When(t => t.externalId != null && t.externalId.idValue != null);
                RuleFor(p => p.externalId.idType.codesetName.ToString()).Must(x => x.ToString() == MyEnumClass.StudentIdentificationSystem).When(t => t.externalId != null && t.externalId.idType != null && t.externalId.idType.codesetName != null).WithMessage("Invalid CodesetName for ExternalId");
                RuleFor(p => p.externalId.idType.code.ToString()).Must(x => CommonMethods.GetCodesetCode("RefPersonIdentificationSystem", "RefPersonIdentificationSystemId", "Code", x.ToString()) != null)//.When(t => t.localId != null && t.localId.idType != null && t.localId.idType.codesetName != null)
                .WithMessage("Invalid Code for externalId.");
                //Sex
                RuleFor(t => t.demographics).Must(x => x.ToString() != null && x.sex.ToString() != null && x.sex.ToString().Length > 0)
                .WithMessage("Sex must have at least one entry.");
                RuleFor(p => p.demographics).Must(x => x.ToString() != null && x.sex.ToString() != null && x.sex.ToString() == "M" || x.ToString() == "F" || x.ToString() == "N");
                //Races
                RuleFor(t => t.demographics).Must(x => x.raceList != null && x.raceList.Length > 0)
                   .WithMessage("RaceList must have at least one entry.")
                   .Must(x => x.raceList != null && x.raceList.All(y => y != null && (y.code.ToString() == xRaceTypeType.Asian.ToString() || y.code.ToString() == xRaceTypeType.BlackOrAfricanAmerican.ToString() || y.code.ToString() == xRaceTypeType.AmericanIndianOrAlaskaNative.ToString() || y.code.ToString() == xRaceTypeType.White.ToString() || y.code.ToString() == xRaceTypeType.NativeHawaiianOrOtherPacificIslander.ToString())))
                   .WithMessage("Valid values for RaceList Code are : BlackorAfricanAmerican, AmericanIndianorAlaskaNative, Asian, NativeHawaiianorOtherPacificIslander, White.");
                RuleFor(t => t.demographics).Must(x => x.raceList != null && x.raceList.Any(y => y.codesetName == MyEnumClass.race));
                //Ethnicity
                RuleFor(t => t.demographics).Must(x => x.ethnicityList != null && x.ethnicityList.Length > 0).WithMessage("Ethnicity must have at least one entry.")
                     .Must(x => x.ethnicityList != null && x.ethnicityList.All(y => y != null && (y.code.ToString() == "1" || y.code.ToString() == "2")))
                     .WithMessage("Valid values for EthnicityList Code are : 1, 2.");
                RuleFor(t => t.demographics).Must(x => x.ethnicityList != null && x.ethnicityList.Any(y => y.codesetName == MyEnumClass.ethnicity));
                //EmailType Codeset Name
                RuleFor(t => t.emailList.Select(x => x.emailType.codesetName).FirstOrDefault()).Must(p => p.ToString() != null).When(z => z.emailList != null && z.emailList.Select(y => y.emailAddress).FirstOrDefault().ToString() != null);
                RuleFor(t => t.emailList.Select(x => x.emailType.codesetName).FirstOrDefault()).Must(p => p.ToString() == MyEnumClass.ElectronicMailAddressType).WithMessage("EmailType codesetname is not a valid.").When(z => z.emailList != null && z.emailList.Select(y => y.emailAddress).FirstOrDefault().ToString() != null);
                //EmailType Code
                RuleFor(t => t.emailList.Select(x => x.emailType.code).FirstOrDefault()).Must(p => p.ToString() != null).When(z => z.emailList != null && z.emailList.Select(y => y.emailAddress).FirstOrDefault().ToString() != null);
                RuleFor(p => p.emailList.Select(x => x.emailType.code).FirstOrDefault()).Must(x => CommonMethods.GetCodesetCode("refemailtype", "RefEmailTypeId", "Code", x.ToString()) != null).When(z => z.emailList != null && z.emailList.Select(y => y.emailAddress).FirstOrDefault().ToString() != null)
                .WithMessage("EmailType should be valid code set.");
                //section504Status
                RuleFor(t => t.disability.section504Status.ToString()).Must(x => x.ToString() == gYesNoUnknownType.Yes.ToString() || x.ToString() == gYesNoUnknownType.No.ToString()).WithMessage("section504Status should be YesNoUnKnown type.");

                // RuleFor(t => t.emailList.Select(x => x.emailType.code).FirstOrDefault().ToString() == "")
                //EmailAddress
                RuleFor(t => t.emailList.Select(x => x.emailAddress).FirstOrDefault()).NotEmpty().When(z => z.emailList != null);
                RuleFor(t => t.emailList.Select(x => x.emailAddress).FirstOrDefault()).EmailAddress().WithMessage("Email Address  is not a valid email address.").When(p => p.emailList != null && p.emailList.Select(k => k.emailAddress).FirstOrDefault() != null);
                RuleFor(t => t.emailList.Select(x => x.emailAddress).FirstOrDefault()).Length(0, 50).When(y => y.emailList != null && y.emailList.Select(x => x.emailAddress).FirstOrDefault() != null);
                //PhoneType Codesetname
                RuleFor(t => t.phoneNumberList.Select(x => x.phoneNumberType.codesetName).FirstOrDefault()).Must(y => y.ToString() != null).WithMessage("PhoneNumberType CodesetName Should not empty.").When(z => z.phoneNumberList != null && z.phoneNumberList.Select(k => k.number).FirstOrDefault() != null);
                RuleFor(t => t.phoneNumberList.Select(x => x.phoneNumberType.codesetName).FirstOrDefault()).Must(p => p.ToString() == MyEnumClass.TelephoneNumberType).WithMessage("Phone Number Type is not a valid.").When(z => z.phoneNumberList != null && z.phoneNumberList.Select(k => k.number).FirstOrDefault() != null);

                //PhoneNumberType Code
                RuleFor(t => t.phoneNumberList.Select(x => x.phoneNumberType.code).FirstOrDefault()).Must(y => y.ToString() != null).WithMessage("PhoneNumberType Code should not empty.").When(z => z.phoneNumberList != null && z.phoneNumberList.Select(k => k.number).FirstOrDefault() != null);
                RuleFor(p => p.phoneNumberList.Select(x => x.phoneNumberType.code).FirstOrDefault()).Must(x => CommonMethods.GetCodesetCode("RefPersonTelephoneNumberType", "RefPersonTelephoneNumberTypeId", "Code", x.ToString()) != null).When(z => z.phoneNumberList != null && z.phoneNumberList.Select(k => k.number).FirstOrDefault() != null)
                .WithMessage("PhoneNumberType should valid code set.");
                //Phone Number
                RuleFor(t => t.phoneNumberList.Select(x => x.number).FirstOrDefault()).NotEmpty().When(z => z.phoneNumberList != null);
                RuleFor(t => t.phoneNumberList.Select(x => x.number).FirstOrDefault()).Length(0, 50).When(z => z.phoneNumberList != null && z.phoneNumberList.Select(k => k.number).FirstOrDefault() != null);
                //Title1
                RuleFor(t => t.title1.ToString()).Length(0, 50).When(x => x.title1 != null);
                RuleFor(t => t.title1.ToString()).Must(x => x.ToString() == "01" || x.ToString() == "02" || x.ToString() == "03" || x.ToString() == "04" || x.ToString() == "05")
                     .WithMessage("Valid Values for title1 are :01,02,03,04,05");
                //ell
                RuleFor(t => t.ell.ToString()).Length(0, 50).When(x => x.ell.ToString() != null);
                RuleFor(t => t.ell.ToString()).Must(x => x.ToString() == gYesNoUnknownType.Yes.ToString() || x.ToString() == gYesNoUnknownType.No.ToString()).WithMessage("ell should be YesNoUnKnown type.").When(y => y.ell.ToString() != null);
                //economicdisadvantage
                RuleFor(t => t.economicDisadvantage.ToString()).Length(0, 50).When(x => x.economicDisadvantage.ToString() != null);
                RuleFor(t => t.economicDisadvantage.ToString()).Must(x => x.ToString() == gYesNoUnknownType.Yes.ToString() || x.ToString() == gYesNoUnknownType.No.ToString()).WithMessage("economicDisadvantage should be YesNoUnKnown type.").When(y => y.economicDisadvantage.ToString() != null);
                //onTimeGraduationYear
                RuleFor(t => t.onTimeGraduationYear.ToString()).Length(0, 8).When(x => x.onTimeGraduationYear != null);
                //OtherName/familyName
                RuleFor(t => t.otherNameList.Select(x => x.otherName.familyName.FirstOrDefault()).ToString()).Length(1, 70).When(y => y.otherNameList != null && y.otherNameList.Select(j => j.otherName).FirstOrDefault() != null && y.otherNameList.Select(k => k.otherName.familyName).FirstOrDefault() != null);
                //OtherName/givenName
                RuleFor(t => t.otherNameList.Select(x => x.otherName.givenName.FirstOrDefault()).ToString()).Length(1, 70).When(y => y.otherNameList != null && y.otherNameList.Select(j => j.otherName).FirstOrDefault() != null && y.otherNameList.Select(k => k.otherName.givenName).FirstOrDefault() != null);
                //OtherName/middleName
                RuleFor(t => t.otherNameList.Select(x => x.otherName.middleName.FirstOrDefault()).ToString()).Length(1, 70).When(y => y.otherNameList != null && y.otherNameList.Select(j => j.otherName).FirstOrDefault() != null && y.otherNameList.Select(k => k.otherName.middleName).FirstOrDefault() != null);
                //demographics/languageList/language/languageCode/code
                RuleFor(t => t.demographics.languageList.Select(x => x.languageCode.code).FirstOrDefault()).Must(y => CommonMethods.GetCodesetCode("RefLanguage", "RefLanguageId", "Code", y.ToString()) != null).When(k=>k.demographics !=null && k.demographics.languageList !=null && k.demographics.languageList.Select(l=>l.languageCode.code).FirstOrDefault() !=null).WithMessage("LanguageCode.Code should be valid code set.");
                //demographics/languageList/language/languageType
                RuleFor(t => t.demographics.languageList.Select(x => x.languageType).FirstOrDefault()).Must(y => CommonMethods.GetCodesetCode("RefLanguageUseType", "RefLanguageUseTypeId", "Code", y.ToString()) != null).When(k=>k.demographics !=null && k.demographics.languageList !=null &&k.demographics.languageList.Select(l=>l.languageType).FirstOrDefault() !=null) .WithMessage("LanguageType should be valid Code set code.");
               // RuleFor(t => t.disability.awaitingInitialIDEAEvaluation.ToString()).Length(1, 1).When(x => x.disability.awaitingInitialIDEAEvaluation.ToString() != null);
                RuleFor(t => t.disability.ideaEnvironment.code.ToString()).Must(x => CommonMethods.GetCodesetCode("RefIDEAEducationalEnvironmentSchoolAge", "RefIDESEducationalEnvironmentSchoolAge", "Code", x.ToString()) != null).When(k=>k.disability !=null &&k.disability.ideaEnvironment !=null  && k.disability.ideaEnvironment.code.ToString() !=null).WithMessage("disability.ideaEnvironment.code should be codeset code.");
                RuleFor(t => t.disability.ideaIndicator.ToString()).Must(x => x.ToString() == gYesNoUnknownType.Yes.ToString() || x.ToString() == gYesNoUnknownType.No.ToString()).When(k=>k.disability !=null && k.disability.ideaIndicator.ToString() !=null).WithMessage("IdealIndicator should be valid codeset code.");
                RuleFor(t => t.disability.primaryDisability.code.ToString()).Must(x => CommonMethods.GetCodesetCode("RefDisabilityType", "RefDisabilityTypeId", "Code", x.ToString()) != null).When(y=>y.disability !=null && y.disability.primaryDisability !=null && y.disability.primaryDisability.code !=null).WithMessage("Primary disability should be valid codeset code.");
               // RuleFor(t => t.disability.Status.ToString()).Length(1, 1).When(x =>x.disability !=null &&  x.disability.Status.ToString() != null);
                RuleFor(t => t.neglectedDelinquent.ToString()).Must(x => x.ToString() == gYesNoUnknownType.Yes.ToString() || x.ToString() == gYesNoUnknownType.No.ToString()).When(y=>y.neglectedDelinquent.ToString() !=null).WithMessage("neglectedDelinquent should be valid codeset code.");
                RuleFor(t => t.mostRecentEnrollment.schoolLocalId.idType.code.ToString()).Must(x => CommonMethods.GetCodesetCode("reforganizationIdentificationsystem", "reforganizationIdentificationsystemId", "Code", x.ToString()) != null).When(y=>y.mostRecentEnrollment !=null && y.mostRecentEnrollment.schoolLocalId !=null && y.mostRecentEnrollment.schoolLocalId.idType!=null && y.mostRecentEnrollment.schoolLocalId.idType.code !=null).WithMessage("SchoolLocalId code should be valid codeset code.");
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }
    }
}
