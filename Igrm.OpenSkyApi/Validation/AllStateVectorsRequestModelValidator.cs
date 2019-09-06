using FluentValidation;
using Igrm.OpenSkyApi.Models.Request;

namespace Igrm.OpenSkyApi.Validation
{
    public class AllStateVectorsRequestModelValidator : AbstractValidator<AllStateVectorsRequestModel>
    {
        public AllStateVectorsRequestModelValidator()
        {
            RuleFor(model => model.BoundingBox).SetValidator(new BoundingBoxValidator());
        }
    }
}
