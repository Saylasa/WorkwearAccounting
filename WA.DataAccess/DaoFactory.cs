
namespace WA.DataAccess
{
    public class DaoFactory
    {
        public static WorkwearDirectoryDao GetWorkwearDirectoryDao()
        {
            return new WorkwearDirectoryDao();
        }

        public static NormDao GetNormDao()
        {
            return new NormDao();
        }

        public static EmplPositionDao GetEmplPositionDao()
        {
            return new EmplPositionDao();
        }

        public static ManufactoryDao GetManufactoryDao()
        {
            return new ManufactoryDao();
        }

        public static RevenueDao GetRevenueDao()
        {
            return new RevenueDao();
        }

        public static IssuedDao GetIssuedDao()
        {
            return new IssuedDao();
        }

        public static CancellationDao GetCancellationDao()
        {
            return new CancellationDao();
        }

        public static PersonDao GetPersonDao()
        {
            return new PersonDao();
        }

        public static SettingDao GetSettingDao()
        {
            return new SettingDao();
        }


    }
}
