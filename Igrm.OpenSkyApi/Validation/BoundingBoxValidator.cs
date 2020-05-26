using FluentValidation;
using Igrm.OpenSkyApi.Models.Request;

namespace Igrm.OpenSkyApi.Validation
{
    public class BoundingBoxValidator : AbstractValidator<BoundingBox>
    {
        public BoundingBoxValidator()
        {
            Unless(model => model.IsEmpty, () =>
            {
                RuleFor(model => model.Lamax).ExclusiveBetween(-90, 90);
                RuleFor(model => model.Lamin).ExclusiveBetween(-90, 90);
                RuleFor(model => model.Lomax).ExclusiveBetween(-180, 180);
                RuleFor(model => model.Lomin).ExclusiveBetween(-180, 180);
            });

        }
    }
}
