namespace WA.BusinessLayer
{
    public class ProcessFactory
    {
        public static WorkwearDirectoryProcessDB GetWorkwearDirectoryProcessDB()
        {
            return new WorkwearDirectoryProcessDB();
        }

        public static NormProcessDB GetNormProcessDB()
        {
            return new NormProcessDB();
        }

        public static EmplPositionProcessDB GetEmplPositionProcessDB()
        {
            return new EmplPositionProcessDB();
        }

        public static ManufactoryProcessDB GetManufactoryProcessDB()
        {
            return new ManufactoryProcessDB();
        }

        public static SettingProcess GetSettingProcess()
        {
            return new SettingProcess();
        }

        


    }
}
