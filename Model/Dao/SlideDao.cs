using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SlideDao
    {
        OnlineShopDbContext db;
        public SlideDao()
        {
            db = new EF.OnlineShopDbContext();
        }

        public List<Slide> ListAll()
        {
            var slide = db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
            return slide;
        }
    }
}
