using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.Services.RoleFeatures
{
    public interface IRoleFeatureService
    {
        IEnumerable<Feature> GetFeaturesAssignedToRole(Role role);
        bool HasAccess(Role role, Feature feature);
    }
}
