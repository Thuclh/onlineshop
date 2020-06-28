using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentDao
    {
        private OnlineShopDbContext _context;
        public ContentDao()
        {
            _context = new OnlineShopDbContext();
        }
        public IEnumerable<Content> ListAllPaging(string searchString, int page,int pageSize)
        {
            IQueryable<Content> content = _context.Contents;
            if (!string.IsNullOrEmpty(searchString))
            {
                content = content.Where(x => x.Name.Contains(searchString));
            }
            return content.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
    }
}
