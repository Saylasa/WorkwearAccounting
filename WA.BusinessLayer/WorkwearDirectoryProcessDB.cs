using System.Collections.Generic;
using WA.Dto;
using WA.DataAccess;

namespace WA.BusinessLayer
{
    public class WorkwearDirectoryProcessDB
    {
        private readonly WorkwearDirectoryDao _workwearDirectoryDao;

        public WorkwearDirectoryProcessDB()
        {
            _workwearDirectoryDao = DaoFactory.GetWorkwearDirectoryDao();
        }

        public IList<WorkwearDirectoryDto> GetList()
        {
            return DtoConverter.Convert(_workwearDirectoryDao.GetAll());
        }

        public WorkwearDirectoryDto Get(int id)
        {
            return DtoConverter.Convert(_workwearDirectoryDao.Get(id));
        }

        public void Add(WorkwearDirectoryDto workwearDirectory)
        {
            _workwearDirectoryDao.Add(DtoConverter.Convert(workwearDirectory));
        }

        public void Update(WorkwearDirectoryDto workwearDirectory)
        {
            _workwearDirectoryDao.Update(DtoConverter.Convert(workwearDirectory));
        }

        public void Delete(int id)
        {
            _workwearDirectoryDao.Delete(id);
        }

        public IList<WorkwearDirectoryDto> SearchWorkwearDirectory(string Name)
        {
                return DtoConverter.Convert(_workwearDirectoryDao.SearchWorkwearDirectories(Name));
        }
    }
}
