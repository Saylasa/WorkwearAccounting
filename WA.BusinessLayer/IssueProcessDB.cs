using System.Collections.Generic;
using WA.Dto;
using WA.DataAccess;

namespace WA.BusinessLayer
{
    public class IssueProcessDB
    {
        private readonly IssuedDao _issueDao;

        public IssueProcessDB()
        {
            _issueDao = DaoFactory.GetIssuedDao();
        }

        public IList<IssuedDto> GetList()
        {
            return DtoConverter.Convert(_issueDao.GetAll());
        }

        public IssuedDto Get(int id)
        {
            return DtoConverter.Convert(_issueDao.Get(id));
        }

        public void Add(IssuedDto issuedDto)
        {
            _issueDao.Add(DtoConverter.Convert(issuedDto));
        }

        public void Update(IssuedDto issuedDto)
        {
            _issueDao.Update(DtoConverter.Convert(issuedDto));
        }

        public void Delete(int id)
        {
            _issueDao.Delete(id);
        }

        public IList<IssuedDto> SearchIssued(int id)
        {
            return DtoConverter.Convert(_issueDao.SearchIssued(id));
        }
    }
}
