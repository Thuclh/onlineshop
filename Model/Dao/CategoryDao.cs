using AutoMapper;
using Model.EF;
using Model.UpdateViewModel;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        public CategoryDao()
        {

        }

        public IEnumerable<Category> ListAll(string searchString)
        {
            IQueryable<Category> category = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                category = category.Where(x => x.Name.Contains(searchString));
            }
            return category.ToList();
            //return db.Categories.Where(x => x.Status == true).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }


        public long Insert(Category entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Category GetById(long id)
        {
            return db.Categories.Find(id);
        }

        public bool Update(Category category)
        {
            var cate = db.Categories.Find(category.ID);
            cate.Name = category.Name;
            cate.MetaTitle = category.MetaTitle;
            cate.ParentId = category.ParentId;
            cate.SeoTitle = category.SeoTitle;
            cate.ModifiedDate = DateTime.Now;
            cate.MetaDescriptions = category.MetaDescriptions;
            cate.Status = category.Status;
            cate.ShowOnHome = category.ShowOnHome;
            db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            try
            {
                var category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
