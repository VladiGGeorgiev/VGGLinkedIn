namespace VGGLinkedIn.Web.ViewModels.Users
{
    using System;
    using System.Linq.Expressions;

    using VGGLinkedIn.Common;
    using VGGLinkedIn.Data.Models;

    public class CertificationViewModel : IMapFrom<Certification>
    {
        public static Expression<Func<Certification, CertificationViewModel>> ViewModel
        {
            get
            {
                return x => new CertificationViewModel
                {
                    Url = x.Url,
                    Name = x.Name,
                    ExpirationDate = x.ExpirationDate,
                    LicenseNumber = x.LicenseNumber,
                    TakenDate = x.TakenDate,
                    Id = x.Id
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string LicenseNumber { get; set; }

        public string Url { get; set; }

        public DateTime TakenDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
