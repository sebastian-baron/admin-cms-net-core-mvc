using AdminCMS.Core.Models.Domains;
using AdminCMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Persistence.Services
{
    public class PageService : IPageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Page> Get(string userId, bool isActive = false, int categoryId = 0, string title = null)
        {
            return _unitOfWork.Page.Get(userId, isActive, categoryId, title);
        }

        public Page Get(int id, string userId)
        {
            return _unitOfWork.Page.Get(id, userId);
        }

        public void Add(Page page)
        {
            _unitOfWork.Page.Add(page);
            _unitOfWork.Complete();
        }

        public void Update(Page page)
        {
            _unitOfWork.Page.Update(page);
            _unitOfWork.Complete();
        }

        public void Delete(int id, string userId)
        {
            _unitOfWork.Page.Delete(id, userId);
            _unitOfWork.Complete();
        }

        public void Active(int id, string userId)
        {
            _unitOfWork.Page.Active(id, userId);
            _unitOfWork.Complete();
        }

        public void Hide(int id, string userId)
        {
            _unitOfWork.Page.Hide(id, userId);
            _unitOfWork.Complete();
        }

    }
}
