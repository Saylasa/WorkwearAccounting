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

        public static PersonProcessDB GetPersonProcessDB()
        {
            return new PersonProcessDB();
        }

        public static IssueProcessDB GetIssuedProcessDB()
        {
            return new IssueProcessDB();
        }

        public static RevenueProcessDB GetRevenueProcessDB()
        {
            return new RevenueProcessDB();
        }

        public static SettingProcess GetSettingProcess()
        {
            return new SettingProcess();
        }
    }
}
