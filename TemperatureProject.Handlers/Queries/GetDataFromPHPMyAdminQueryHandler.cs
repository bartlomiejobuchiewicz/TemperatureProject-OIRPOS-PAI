using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Contract.Query;
using TemperatureProject.Core.Cqrs;
using TemperatureProject.Domain.Interfaces;

namespace TemperatureProject.Handlers.Queries
{
    public class GetDataFromPHPMyAdminQueryHandler : AutomateRequestHandler<GetDataFromPHPMyAdminQuery>
    {
        private readonly ITemperatureDeviceRepository _temperatureDeviceRepository;
        public GetDataFromPHPMyAdminQueryHandler()
        {

        }

        protected override Task ExecuteRequestDelegate(GetDataFromPHPMyAdminQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
