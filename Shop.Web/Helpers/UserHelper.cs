namespace Shop.Web.Helpers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Data.Entities;
    using Shop.Web.Models;    

    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password) 
            => await _userManager.CreateAsync(user, password);

        //Expression body for methods (like delegates)
        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword) 
            => await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

        public async Task<User> GetUserByEmailAsync(string email) 
            => await _userManager.FindByEmailAsync(email);

        public async Task<SignInResult> LoginAsync(LoginViewModel model) 
            => await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);

        public async Task LogoutAsync() 
            => await _signInManager.SignOutAsync();

        public async Task<IdentityResult> UpdateUserAsync(User user) 
            => await _userManager.UpdateAsync(user);
    }
}
