
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




        public static SettingDao GetSettingDao()
        {
            return new SettingDao();
        }


    }
}
