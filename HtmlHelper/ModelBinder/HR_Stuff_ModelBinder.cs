using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.Comm;
using System.Web.Mvc;
using QX.Model;

namespace QX.HtmlHelperLib.ModelBinder
{
    public class Dict_ModelBinder : IModelBinder

    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = (Bse_Dict)(bindingContext.Model ?? new Bse_Dict());
            //book.Title = GetValue<string>(bindingContext, "Title");
            //book.Author = GetValue<string>(bindingContext, "Author");
            //book.DatePublished = GetValue<DateTime>(bindingContext, "DatePublished");
            //if (String.IsNullOrEmpty(book.Title))
            //{
            //    bindingContext.ModelState.AddModelError("Title", "书名不能为空?");
            //}

            return model;
        }


        private T GetValue<T>(ModelBindingContext bindingContext, string key)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(key);
            bindingContext.ModelState.SetModelValue(key, valueResult);
            return (T)valueResult.ConvertTo(typeof(T));
        }

    }
}
