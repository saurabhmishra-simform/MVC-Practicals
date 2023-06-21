using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical17.Models;
using System.Security.Claims;

namespace Practical17.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminstrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Users> _userManager;

        public AdminstrationController(RoleManager<IdentityRole> roleManager, UserManager<Users> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ListUser()
        {
            var users = _userManager.Users;
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found!!";
                return View("NotFound");
            }
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            var model = new EditUserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                MobileNumber = user.PhoneNumber,
                UserName = user.UserName,
                Claims = userClaims.Select(x => x.Value).ToList(),
                Roles = userRoles
            };
            return View(model);
            
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found!!";
                return View("NotFound");
            }
            else
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.MobileNumber;
                user.UserName = model.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUser");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }
                return View(model);
            }
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found!!";
                return View("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUser");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }
                return View("ListUser");
            }
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole","Adminstration");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListRole()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound($"Role with Id = {id} cannot be found");
            }
            var model = new EditRoleModel
            {
                Id = role.Id,
                RoleName = role.Name,
            };
            foreach(var user in _userManager.Users)
            {
                if(await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.User.Add(user.UserName);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                return NotFound($"Role with Id = {model.Id} cannot be found");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditUserInRole(string roleId)
        {
            ViewBag.RoleId = roleId;
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound($"Role with Id = {roleId} cannot be found");
            }
            var model = new List<UserRoleModel>();
            foreach(var user in _userManager.Users)
            {
                var userRoleModel = new UserRoleModel
                {
                    UserId = user.Id,
                    Username = user.UserName,
                };
                if(await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleModel.IsSelected = true;
                }
                else
                {
                    userRoleModel.IsSelected = false;
                }
                model.Add(userRoleModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserInRole(List<UserRoleModel> model, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound($"Role with Id = {roleId} cannot be found");
            }
            for(int i = 0; i < model.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);

                IdentityResult? result = null;

                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                }
            }
            return RedirectToAction("EditRole", new { Id = roleId });
        }
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound($"Role with Id = {id} cannot be found");
            }
            else
            {
                try
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRole");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View("ListRole");
                }
                catch(DbUpdateException ex)
                {
                    ViewBag.ErrorTitle = $"{role.Name} role is in use";
                    ViewBag.ErrorMessage = $"{role.Name} role can not deleted as there are users on this are users" +
                        $"in this role. If you want to delete this role, Please remove the users from" +
                        $"the role and then try to delete";
                    return View("Error");
                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> ManageUserRole(string userId)
        {
            ViewBag.UserId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {userId} cannot be found";
                return View("NotFound");
            }
            var model = new List<UserRolesModel>();
            foreach(var role in _roleManager.Roles)
            {
                var userRolesModel = new UserRolesModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };
                if(await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesModel.IsSelected = true;
                }
                else
                {
                    userRolesModel.IsSelected = false;
                }
                model.Add(userRolesModel);   
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ManageUserRole(List<UserRolesModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Role with Id = {userId} cannot be found");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(result);
            }

            result = await _userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(result);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }
        [HttpGet]
        public async Task<IActionResult> ManageUserClaim(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return NotFound($"Role with Id = {userId} cannot be found");
            }
            var existingUserClaims = await _userManager.GetClaimsAsync(user);
            var model = new UserClaimModel
            {
                UserId = userId,
            };
            foreach (Claim claim in ClaimsStore.AllClaims)
            {
                UserClaim userClaim = new UserClaim
                {
                    ClaimType = claim.Type,
                };
                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }
                model.Claims.Add(userClaim);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ManageUserClaim(UserClaimModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.UserId} cannot be found";
                return View("NotFound");
            }

            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(result);
            }

            result = await _userManager.AddClaimsAsync(user,
                model.Claims.Where(x => x.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to user");
                return View(result);
            }

            return RedirectToAction("EditUser", new { Id = model.UserId });
        }
    }
}
