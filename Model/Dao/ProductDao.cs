using Model.EF;
using Model.ViewModel;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(Product entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Product GetById(long id)
        {
            return db.Products.Find(id);
        }

        public bool Update(Product entity)
        {
            var product = db.Products.Find(entity.ID);
            product.Name = entity.Name;
            product.MetaTitle = entity.MetaTitle;
            product.Price = entity.Price;
            product.ModifiedDate = DateTime.Now;
            product.Image = entity.Image;
            product.Detail = entity.Detail;
            product.Status = entity.Status;
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return true;
        }

        public bool ChangeStatus(long id)
        {
            var product = db.Products.Find(id);
            product.Status = !product.Status;
            db.SaveChanges();
            return product.Status;
        }

        public IEnumerable<Product> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Product> product = db.Products;
            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(x => x.Name.Contains(searchString));
            }
            return product.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        
        public List<Product> ListNewProducts(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        
        public List<Product> ListFeatureProducts(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).ToList();
        }
        
        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryId == product.CategoryId).ToList();
        }

        public List<ProductViewModel> ListByCategoryId(long categoryId)
        {
            //var model = db.Products.Where(x => x.CategoryId == categoryId).ToList(); or
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryId equals b.ID
                        where a.CategoryId == categoryId
                        select new ProductViewModel()
                        {
                            ID=a.ID,
                            Images=a.Image,
                            Name=a.Name,
                            Price=a.Price,
                            MetaTitle=a.MetaTitle,
                            CreatedDate=a.CreatedDate,
                            CateName=b.Name,
                            CateMetaTitle=b.MetaTitle
                        };
            return model.ToList();
        }
        
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
    }
}
