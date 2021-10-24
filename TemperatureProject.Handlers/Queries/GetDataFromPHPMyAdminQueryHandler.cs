using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Contract.Query;
using TemperatureProject.Core.Cqrs;

namespace TemperatureProject.Handlers.Queries
{
    public class GetDataFromPHPMyAdminQueryHandler : AutomateRequestHandler<GetDataFromPHPMyAdminQuery>
    {
        public GetDataFromPHPMyAdminQueryHandler()
        {

        }

        protected override Task ExecuteRequestDelegate(GetDataFromPHPMyAdminQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
