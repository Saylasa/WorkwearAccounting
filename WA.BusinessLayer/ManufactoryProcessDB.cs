using System.Collections.Generic;
using WA.Dto;
using WA.DataAccess;

namespace WA.BusinessLayer
{
    public class ManufactoryProcessDB
    {
        private readonly ManufactoryDao _manufactoryDao;

        public ManufactoryProcessDB()
        {
            _manufactoryDao = DaoFactory.GetManufactoryDao();
        }

        public IList<ManufactoryDto> GetList()
        {
            return DtoConverter.Convert(_manufactoryDao.GetAll());
        }

        public ManufactoryDto Get(int id)
        {
            return DtoConverter.Convert(_manufactoryDao.Get(id));
        }

        public void Add(ManufactoryDto manufactoryDto)
        {
            _manufactoryDao.Add(DtoConverter.Convert(manufactoryDto));
        }

        public void Update(ManufactoryDto manufactoryDto)
        {
            _manufactoryDao.Update(DtoConverter.Convert(manufactoryDto));
        }

        public void Delete(int id)
        {
            _manufactoryDao.Delete(id);
        }
    }
}
