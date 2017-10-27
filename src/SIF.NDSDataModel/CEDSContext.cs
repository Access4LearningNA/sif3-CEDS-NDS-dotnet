namespace SIF.NDSDataModel
{
    using Microsoft.EntityFrameworkCore;
    using System.Data.Entity.ModelConfiguration.Conventions;
   
    public partial class CEDSContext : DbContext
    {

        public CEDSContext(DbContextOptions<CEDSContext> options)
            : base(options)
        {
        }

        
        //public virtual DbSet<Location> Location { get; set; }
        //public virtual DbSet<LocationAddress> LocationAddress { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationDetail> OrganizationDetail { get; set; }
        public virtual DbSet<OrganizationTelephone> OrganizationTelephone { get; set; }
        public virtual DbSet<OrganizationEmail> OrganizationEmail { get; set; }
        public virtual DbSet<OrganizationOperationalStatus> OrganizationOperationalStatus { get; set; }
        public virtual DbSet<K12School> K12School { get; set; }
        public virtual DbSet<OrganizationIdentifier> OrganizationIdentifier { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonDetail> PersonDetail { get; set; }
        public virtual DbSet<PersonAddress> PersonAddress { get; set; }
        public virtual DbSet<PersonEmailAddress> PersonEmailAddress { get; set; }
        public virtual DbSet<PersonTelephone> PersonTelephone { get; set; }
        public virtual DbSet<PersonOtherName> PersonOtherName { get; set; }
        public virtual DbSet<OrganizationWebsite> OrganizationWebsite { get; set; }

        //public virtual DbSet<OrganizationIdentifier> OrganizationIdentifier { get; set; }



        //public virtual DbSet<OrganizationLocation> OrganizationLocation { get; set; }
        //public virtual DbSet<Person> Person { get; set; }

        //public virtual DbSet<PersonDegreeOrCertificate> PersonDegreeOrCertificate { get; set; }
        




        //public virtual DbSet<RefAddressType> RefAddressType { get; set; }
        //public virtual DbSet<RefCountry> RefCountry { get; set; }
        //public virtual DbSet<RefEmailType> RefEmailType { get; set; }
        //public virtual DbSet<RefGradeLevel> RefGradeLevel { get; set; }
        //public virtual DbSet<RefGradeLevelType> RefGradeLevelType { get; set; }
        //public virtual DbSet<RefOrganizationIdentifierType> RefOrganizationIdentifierType { get; set; }
        //public virtual DbSet<RefOrganizationLocationType> RefOrganizationLocationType { get; set; }
        //public virtual DbSet<RefOrganizationType> RefOrganizationType { get; set; }
        //public virtual DbSet<RefSchoolLevel> RefSchoolLevel { get; set; }
        //public virtual DbSet<RefSchoolType> RefSchoolType { get; set; }
        //public virtual DbSet<RefSex> RefSex { get; set; }
        //public virtual DbSet<RefState> RefState { get; set; }
        //public virtual DbSet<RefTelephoneNumberType> RefTelephoneNumberType { get; set; }
        //public virtual DbSet<SchoolAttributes> SchoolAttributes { get; set; }
        //public virtual DbSet<SchoolAttributesCleanRecords> SchoolAttributesCleanRecords { get; set; }
        //public virtual DbSet<SchoolAttributesErrorRecords> SchoolAttributesErrorRecords { get; set; }
        //public virtual DbSet<K12StudentAcademicRecord> K12StudentAcademicRecord { get; set; }
        //public virtual DbSet<K12StudentCohort> K12StudentCohort { get; set; }
        //public virtual DbSet<PersonBirthplace> PersonBirthplace { get; set; }
        //public virtual DbSet<PersonDisability> PersonDisability { get; set; }
        //public virtual DbSet<PersonLanguage> PersonLanguage { get; set; }
        //public virtual DbSet<ProgramParticipationSpecialEducation> ProgramParticipationSpecialEducation { get; set; }
        //public virtual DbSet<ProgramParticipationTitleI> ProgramParticipationTitleI { get; set; }
        //public virtual DbSet<PsStudentCohort> PsStudentCohort { get; set; }
        //public virtual DbSet<RefISO6393Language> RefISO6393Language { get; set; }
        //public virtual DbSet<ELEnrollment> ELEnrollment { get; set; }
        //public virtual DbSet<K12StudentEnrollment> K12StudentEnrollment { get; set; }
        //public virtual DbSet<CourseSectionSchedule> CourseSectionSchedule { get; set; }
        //public virtual DbSet<CteCourse> CteCourse { get; set; }
        //public virtual DbSet<K12StaffAssignment> K12StaffAssignment { get; set; }
        //public virtual DbSet<K12StudentCourseSection> K12StudentCourseSection { get; set; }
        //public virtual DbSet<ProgramParticipationCte> ProgramParticipationCte { get; set; }
        //public virtual DbSet<PsStudentSection> PsStudentSection { get; set; }
        //public virtual DbSet<RoleAttendanceEvent> RoleAttendanceEvent { get; set; }
        //public virtual DbSet<K12StudentCourseSectionMark> K12StudentCourseSectionMark { get; set; }
        //public virtual DbSet<OrganizationCalendar> OrganizationCalendar { get; set; }
        //public virtual DbSet<OrganizationCalendarEvent> OrganizationCalendarEvent { get; set; }
        //public virtual DbSet<OrganizationCalendarSession> OrganizationCalendarSession { get; set; }
        //public virtual DbSet<RoleAttendance> RoleAttendance { get; set; }
        //public virtual DbSet<CourseSection> CourseSection { get; set; }
        //public virtual DbSet<CourseSectionLocation> CourseSectionLocation { get; set; }
        //public virtual DbSet<Course> Courses { get; set; }
        //public virtual DbSet<Incident> Incident { get; set; }
        //public virtual DbSet<K12StudentDiscipline> K12StudentDiscipline { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
           // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
   
}
}
