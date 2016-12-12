using WA.DataAccess;

namespace WA.BusinessLayer
{
    public class SettingProcess
    {
        private readonly SettingDao _settingdao;
        public SettingProcess()
        {
            _settingdao = new SettingDao();
        }
        public string GetSettings()
        {
            return _settingdao.GetSettings();
        }
        public bool SetSettings(string server, string db, string user, string password)
        {
            return _settingdao.SetSettings(server, db, user, password);
        }
    }
}
