namespace PMS.DataAccess.Repositories
{
// ReSharper disable once InconsistentNaming
    public class PMSRepository
    {
        public DoctorRepository Doctors { get { return new DoctorRepository(); } }
        public LoginRepository Logins { get { return new LoginRepository(); } }
        public PatientRepository Patients { get { return new PatientRepository(); } }
        public DrugRepository Drugs { get { return new DrugRepository(); } }
    }
}
