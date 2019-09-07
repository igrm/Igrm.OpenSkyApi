using FluentValidation;
using Igrm.OpenSkyApi.Models.Request;

namespace Igrm.OpenSkyApi.Validation
{
    public class AllStateVectorsRequestModelValidator : AbstractValidator<AllStateVectorsRequestModel>
    {
        public AllStateVectorsRequestModelValidator()
        {
            RuleFor(model => model.BoundingBox).SetValidator(new BoundingBoxValidator());
            RuleFor(model => model.Time).Custom((value, context) => {
                if (value.HasValue && value < 0)
                    context.AddFailure("Time should be greater or equal to 0");
            });
        }
    }
}
