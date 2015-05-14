namespace VGGLinkedIn.Web.InputModels
{
    using VGGLinkedIn.Data.Models;

    public class EditUserInputModel
    {
        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public static EditUserInputModel FromModel(User user)
        {
            return new EditUserInputModel
            {
                FullName = user.FullName,
                Summary = user.Summary,
                AvatarUrl = user.AvatarUrl,
                ContactInfo = user.ContactInfo
            };
        }

        internal User UpdateUser(User user)
        {
            user.FullName = this.FullName;
            user.AvatarUrl = this.AvatarUrl;
            user.Summary = this.Summary;
            user.ContactInfo = this.ContactInfo;

            return user;
        }
    }
}