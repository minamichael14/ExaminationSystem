using System.Security.Claims;
using ExaminationSystem.Models.Enums;
using ExaminationSystem.Services.RoleFeatures;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExaminationSystem.Filters
{
    public class CustomizeAuthorizeAttribute : ActionFilterAttribute
    {
        IRoleFeatureService _roleFeatureService;
        Feature _feature;
        public CustomizeAuthorizeAttribute(Feature feature ,
            IRoleFeatureService roleFeatureService)
        {
            _feature = feature;
            _roleFeatureService = roleFeatureService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var claims =  context.HttpContext.User;
            var roleID = claims.FindFirst(ClaimTypes.Role);
            if (roleID is null || string.IsNullOrEmpty(roleID.Value))
            {
                throw new UnauthorizedAccessException();
            }

            var role = (Role)int.Parse(roleID.Value);
            var hasAccess = _roleFeatureService.HasAccess(role, _feature);
            if (!hasAccess)
            {
                throw new UnauthorizedAccessException();
            }


            base.OnActionExecuting(context);
        }

    }
}
