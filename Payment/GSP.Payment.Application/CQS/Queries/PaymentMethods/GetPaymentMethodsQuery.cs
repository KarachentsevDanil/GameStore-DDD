﻿using GSP.Payment.Application.UseCases.DTOs.PaymentMethods;
using MediatR;
using System.Collections.Immutable;

namespace GSP.Payment.Application.CQS.Queries.PaymentMethods
{
    public class GetPaymentMethodsQuery : IRequest<IImmutableList<GetPaymentMethodDto>>
    {
        public long AccountId { get; set; }
    }
}