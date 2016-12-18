using System.Collections.Generic;
using WA.Dto;
using WA.DataAccess;

namespace WA.BusinessLayer
{
    public class PersonProcessDB
    {
        private readonly PersonDao _personDao;

        public PersonProcessDB()
        {
            _personDao = DaoFactory.GetPersonDao();
        }

        public IList<PersonDto> GetList()
        {
            return DtoConverter.Convert(_personDao.GetAll());
        }

        public PersonDto Get(int id)
        {
            return DtoConverter.Convert(_personDao.Get(id));
        }

        public void Add(PersonDto personDto)
        {
            _personDao.Add(DtoConverter.Convert(personDto));
        }

        public void Update(PersonDto emplPositionDto)
        {
            _personDao.Update(DtoConverter.Convert(emplPositionDto));
        }

        public void Delete(int id)
        {
            _personDao.Delete(id);
        }

        public IList<PersonDto> SearchPersonN(string surname)
        {
            return DtoConverter.Convert(_personDao.SearchPersonsN(surname));
        }

        public IList<PersonDto> SearchPersonP(int id)
        {
            return DtoConverter.Convert(_personDao.SearchPersonsP(id));
        }
    }
}
