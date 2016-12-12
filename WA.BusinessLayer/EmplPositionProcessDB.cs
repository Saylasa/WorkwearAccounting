using System.Collections.Generic;
using WA.Dto;
using WA.DataAccess;

namespace WA.BusinessLayer
{
    public class EmplPositionProcessDB
    {
        private readonly EmplPositionDao _emplPositionDao;

        public EmplPositionProcessDB()
        {
            _emplPositionDao = DaoFactory.GetEmplPositionDao();
        }

        public IList<EmplPositionDto> GetList()
        {
            return DtoConverter.Convert(_emplPositionDao.GetAll());
        }

        public EmplPositionDto Get(int id)
        {
            return DtoConverter.Convert(_emplPositionDao.Get(id));
        }

        public void Add(EmplPositionDto emplPositionDto)
        {
            _emplPositionDao.Add(DtoConverter.Convert(emplPositionDto));
        }

        public void Update(EmplPositionDto emplPositionDto)
        {
            _emplPositionDao.Update(DtoConverter.Convert(emplPositionDto));
        }

        public void Delete(int id)
        {
            _emplPositionDao.Delete(id);
        }

        public IList<EmplPositionDto> SearchEmplPosition(int id_manufactory)
        {
            return DtoConverter.Convert(_emplPositionDao.SearchEmplPosition(id_manufactory));
        }
    }
}
