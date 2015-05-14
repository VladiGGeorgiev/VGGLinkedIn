namespace VGGLinkedIn.Web.ViewModels.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
using System.Web.Mvc;
using VGGLinkedIn.Data.Models;
    
    public class DropdownViewModel
    {
        public static Expression<Func<User, SelectListItem>> FromUser
        {
            get
            {
                return x => new SelectListItem
                {
                    Value = x.Id,
                    Text = x.UserName
                };
            }
        }

        public static IEnumerable<SelectListItem> GetEnumValues<T>() where T : struct, IConvertible
        {
            return Enum.GetValues(typeof (T))
                .Cast<T>()
                .Select(x => new SelectListItem
                {
                    Value = Convert.ToInt32(x).ToString(),
                    Text = x.GetType().GetEnumName(x)
                })
                .ToList();
        } 

        public int Id { get; set; }

        public string Name { get; set; }
    }
}