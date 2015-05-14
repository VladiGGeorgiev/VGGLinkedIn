namespace VGGLinkedIn.Web.ViewModels.Users
{
    using System;
    using System.Linq.Expressions;

    using VGGLinkedIn.Common;
    using VGGLinkedIn.Data.Models;

    public class LanguageViewModel : IMapFrom<UserLanguage>
    {
        public static Expression<Func<UserLanguage, LanguageViewModel>> ViewModel
        {
            get
            {
                return x => new LanguageViewModel
                {
                    Name = x.Name
                };
            }
        }

        public string Name { get; set; }
    }
}
