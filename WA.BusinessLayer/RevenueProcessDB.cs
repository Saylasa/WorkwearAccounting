using System.Collections.Generic;
using WA.Dto;
using WA.DataAccess;

namespace WA.BusinessLayer
{
    public class RevenueProcessDB
    {
        private readonly RevenueDao _revenueDao;

        public RevenueProcessDB()
        {
            _revenueDao = DaoFactory.GetRevenueDao();
        }

        public IList<RevenueDto> GetList()
        {
            return DtoConverter.Convert(_revenueDao.GetAll());
        }

        public RevenueDto Get(int id)
        {
            return DtoConverter.Convert(_revenueDao.Get(id));
        }

        public void Add(RevenueDto revenueDto)
        {
            _revenueDao.Add(DtoConverter.Convert(revenueDto));
        }

        public void Update(RevenueDto revenueDto)
        {
            _revenueDao.Update(DtoConverter.Convert(revenueDto));
        }

        public void Delete(int id)
        {
            _revenueDao.Delete(id);
        }

        public IList<RevenueDto> SearchRevenue()
        {
            return DtoConverter.Convert(_revenueDao.SearchRevenue());
        }
    }
}
