using FluentValidation;
using Igrm.OpenSkyApi.Models.Request;

namespace Igrm.OpenSkyApi.Validation
{
    public class AllStateVectorsRequestModelValidator : AbstractValidator<AllStateVectorsRequestModel>
    {
        public AllStateVectorsRequestModelValidator()
        {
            RuleFor(model => model.BoundingBox.Lamax).ExclusiveBetween(-90, 90);
            RuleFor(model => model.BoundingBox.Lamin).ExclusiveBetween(-90, 90);
            RuleFor(model => model.BoundingBox.Lomax).ExclusiveBetween(-180, 180);
            RuleFor(model => model.BoundingBox.Lomin).ExclusiveBetween(-180, 180);
        }
    }
}
