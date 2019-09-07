using FluentValidation;
using Igrm.OpenSkyApi.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Validation
{
    public class FlightsInTimeIntervalRequestModelValidator: AbstractValidator<FlightsInTimeIntervalRequestModel>
    {
        public FlightsInTimeIntervalRequestModelValidator()
        {
            RuleFor(model => model.Begin).GreaterThan(0);
            RuleFor(model => model.End).GreaterThan(0);
            RuleFor(model => model.Begin).Must((model, value) => value < model.End);
        }
    }
}
