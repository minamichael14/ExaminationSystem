using AutoMapper.Features;
using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models.Enums;
using ExaminationSystem.Models.Users;

namespace ExaminationSystem.Services.RoleFeatures
{
    public class RoleFeatureService : IRoleFeatureService
    {
        IRepository<RoleFeature> _repository;
        public RoleFeatureService(IRepository<RoleFeature> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Feature> GetFeaturesAssignedToRole(Role role)
        {
            return _repository.Get(x => x.Role == role)
                .Select(x => x.Feature)
                .ToList();
        }

        public bool HasAccess(Role role, Feature feature)
        {
            return _repository.Get(x => x.Role == role && x.Feature == feature).Any();
        }
    }
}
