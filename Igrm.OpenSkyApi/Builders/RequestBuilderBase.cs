using FluentValidation;
using Igrm.OpenSkyApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public abstract class RequestBuilderBase<T, U> : IRequestBuilder
                                                     where U : AbstractValidator<T>, new()
                                                     where T : IRequestModel, new()
    {
        protected T requestModel;

        public RequestBuilderBase()
        {
            requestModel = new T();
        }

        public IRequestModel Build()
        {
            var copy = requestModel.Clone();
            requestModel = new T();
            return (T)copy;
        }

        protected bool Validate(T requestModel)
        {
            var validator = new U();
            return validator.Validate(requestModel).IsValid;
        }
    }
}
