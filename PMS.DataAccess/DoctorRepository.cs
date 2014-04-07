using System.Linq;


namespace PMS.DataAccess
{
    public class DoctorRepository
    {
        PmsEntities entities = new PmsEntities();

        public IQueryable<doctor> GetAll()
        {
            return entities.doctors.AsQueryable();
        }
    }
}
