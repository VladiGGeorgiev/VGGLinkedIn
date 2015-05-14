namespace VGGLinkedIn.Web.ViewModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using VGGLinkedIn.Common;
    using VGGLinkedIn.Data.Models;

    public class SkillViewModel : IMapFrom<UserSkill>, IHaveCustomMappings
    {
        public static Expression<Func<UserSkill, SkillViewModel>> ViewModel
        {
            get
            {
                return x => new SkillViewModel
                {
                    Id = x.Id,
                    Name = x.Skill.Name,
                    Endorcements = x.Endorcements.Count,
                    Endorcers = x.Endorcements.Select(e => e.User.UserName)
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
        }

        public int Endorcements { get; set; }

        public IEnumerable<string> Endorcers { get; set; }
    }
}
