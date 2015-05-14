namespace VGGLinkedIn.Web.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc.Expressions;

    using AutoMapper;
    using System.Web.Mvc;

    using VGGLinkedIn.Common.SystemMessages;
    using VGGLinkedIn.Data;
    using VGGLinkedIn.Data.Models;
    using VGGLinkedIn.Web.InputModels;
    using VGGLinkedIn.Web.ViewModels;
    using VGGLinkedIn.Web.ViewModels.Users;

    [Authorize]
    public class UsersController : BaseController
    {

        public UsersController(IVggLinkedInData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index(string username)
        {
            var userProfile = this.Data.Users.All()
                .Include(x => x.Certifications)
                .Include(x => x.Projects)
                .Include(x => x.Skills)
                .Where(x => x.UserName == username)
                .Select(UserProfileViewModel.ViewModel)
                .FirstOrDefault();

            return this.View(userProfile);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var inputModel = EditUserInputModel.FromModel(this.UserProfile);
            return this.View(inputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var updatedUser = model.UpdateUser(this.UserProfile);
                this.Data.Users.Update(updatedUser);
                this.Data.SaveChanges();

                this.TempData[SystemMessageType.Information.ToString()] = "Profile updated";
                return this.RedirectToAction(x => x.Index(this.UserProfile.UserName));
            }

            return this.View(model);
        }

        [HttpPost]
        public ActionResult EndorseUserForSkill(int id)
        {
            // TODO: Optimize queries!
            var hasExistingEndorcement =
                this.Data.Endorcements.All().Any(x => x.UserId == this.UserProfile.Id && x.UserSkillId == id);
            if (!hasExistingEndorcement)
            {
                this.Data.Endorcements.Add(new Endorcement
                {
                    UserId = this.UserProfile.Id,
                    UserSkillId = id
                });
                this.Data.SaveChanges();
            }

            var endorcements =
                this.Data.Endorcements.All().Where(x => x.UserSkillId == id);
            var endorcementsCount = endorcements.Count();
            var endorcers = endorcements.Select(x => x.User.UserName).ToList();


            return this.Content(string.Format("{0} ({1})", endorcementsCount, string.Join(",", endorcers)));
        }
    }
}