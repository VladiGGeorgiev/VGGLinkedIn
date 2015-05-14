namespace VGGLinkedIn.Web.ViewModels.Users
{
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using VGGLinkedIn.Common;
using VGGLinkedIn.Data.Models;

    public class UserProfileViewModel : IMapFrom<User>
    {
        public static Expression<Func<User, UserProfileViewModel>> ViewModel
        {
            get
            {
                return x => new UserProfileViewModel
                {
                    UserName = x.UserName,
                    AvatarUrl = x.AvatarUrl,
                    ContactInfo = x.ContactInfo,
                    FullName = x.FullName,
                    Summary = x.Summary,
                    Certifications = x.Certifications.AsQueryable().Select(CertificationViewModel.ViewModel),
                    Projects = x.Projects.AsQueryable().Select(ProjectViewModel.ViewModel),
                    Skills = x.Skills.AsQueryable().Select(SkillViewModel.ViewModel),
                    Languages = x.Languages.AsQueryable().Select(LanguageViewModel.ViewModel)
                };
            }
        }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public IEnumerable<CertificationViewModel> Certifications { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public IEnumerable<SkillViewModel> Skills { get; set; }

        public IEnumerable<LanguageViewModel> Languages { get; set; }
    }
}