using FluentValidation;
using Igrm.OpenSkyApi.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Validation
{
    public class TrackByAircraftRequestModelValidator:AbstractValidator<TrackByAircraftRequestModel>
    {
        public TrackByAircraftRequestModelValidator()
        {
            RuleFor(model => model.Icao24).NotEmpty();
            RuleFor(model=>model.Time).Custom((value, context) => {
                if (value.HasValue && value < 0)
                    context.AddFailure("Time should be greater or equal to 0");
            });
        }
    }
}
