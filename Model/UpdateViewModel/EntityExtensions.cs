using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UpdateViewModel
{
    public static class EntityExtensions
    {
        public static void UpdateCategory(this Category category, CategoryViewModel categoryViewModel)
        {
            category.ID = categoryViewModel.ID;
            category.Name = categoryViewModel.Name;
            category.MetaTitle = categoryViewModel.MetaTitle;
            category.ParentId = categoryViewModel.ParentId;
            category.SeoTitle = categoryViewModel.SeoTitle;
            category.CreatedDate = categoryViewModel.CreatedDate;
            category.CreatedBy = categoryViewModel.CreatedBy;
            category.ModifiedDate = categoryViewModel.ModifiedDate;
            category.ModifieBy = categoryViewModel.ModifieBy;
            category.DisplayOrder = categoryViewModel.DisplayOrder;
            category.MetaDescriptions = categoryViewModel.MetaDescriptions;
            category.MetaKeywords = categoryViewModel.MetaKeywords;
            category.Status = categoryViewModel.Status;
            category.ShowOnHome = categoryViewModel.ShowOnHome;
        }
        public static void UpdateContent(this Content content, ContentViewModel contentViewModel)
        {
            content.ID = contentViewModel.ID;
            content.Name = contentViewModel.Name;
            content.MetaTitle = contentViewModel.MetaTitle;
            content.Description = contentViewModel.Image;
            content.Image = contentViewModel.Image;
            content.CategoryId = contentViewModel.CategoryId;
            content.Detail = contentViewModel.Detail;
            content.Warranty = contentViewModel.Warranty;
            content.CreatedBy = contentViewModel.CreatedBy;
            content.CreatedDate = contentViewModel.CreatedDate;
            content.ModifieBy = contentViewModel.ModifieBy;
            content.ModifiedDate = contentViewModel.ModifiedDate;
            content.MetaDescriptions = contentViewModel.MetaDescriptions;
            content.MetaKeywords = contentViewModel.MetaKeywords;
            content.Status = contentViewModel.Status;
            content.ViewCount = contentViewModel.ViewCount;
            content.TopHot = contentViewModel.TopHot;
            content.Tags = contentViewModel.Tags;
        }
    }
}
