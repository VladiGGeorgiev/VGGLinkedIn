namespace VGGLinkedIn.Web.ViewModels.Users
{
    using System;
    using System.Linq.Expressions;

    using VGGLinkedIn.Common;
    using VGGLinkedIn.Data.Models;

    public class ProjectViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public static Expression<Func<Project, ProjectViewModel>> ViewModel
        {
            get
            {
                return x => new ProjectViewModel
                {
                    Name = x.Name,
                    Url = x.Url,
                    Date = x.Date,
                    OccupationExperience = x.OccupationExperience.CompanyName,
                    Description = x.Description
                };
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Url { get; set; }

        public string OccupationExperience { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectViewModel>()
                .ForMember(x => x.OccupationExperience,
                    config => config.MapFrom(p => p.OccupationExperience.CompanyName));
        }
    }
}
