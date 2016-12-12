using System.Collections.Generic;
using WA.Dto;
using WA.DataAccess;

namespace WA.BusinessLayer
{
    public class NormProcessDB
    {
        private readonly NormDao _normDao;

        public NormProcessDB()
        {
            _normDao = DaoFactory.GetNormDao();
        }

        public IList<NormDto> GetList()
        {
            return DtoConverter.Convert(_normDao.GetAll());
        }

        public NormDto Get(int id)
        {
            return DtoConverter.Convert(_normDao.Get(id));
        }

        public void Add(NormDto normDto)
        {
            _normDao.Add(DtoConverter.Convert(normDto));
        }

        public void Update(NormDto normDto)
        {
            _normDao.Update(DtoConverter.Convert(normDto));
        }

        public void Delete(int id)
        {
            _normDao.Delete(id);
        }

        public IList<NormDto> SearchNorm(int id_position)
        {
            return DtoConverter.Convert(_normDao.SearchNorm(id_position));
        }
    }
}
