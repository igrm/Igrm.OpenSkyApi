using FluentValidation;
using Igrm.OpenSkyApi.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Validation
{
    public class OwnStateVectorsRequestModelValidator:AbstractValidator<OwnStateVectorsRequestModel>
    {
        public OwnStateVectorsRequestModelValidator()
        {
            RuleFor(model => model.Time).Custom((value, context) => {
                if (value.HasValue && value < 0)
                    context.AddFailure("Time should be greater or equal to 0");
            });
            RuleFor(model => model.Icao24).Must((value) => value != null);
            RuleFor(model => model.Serials).Must((value) => value != null);
        }
    }
}
