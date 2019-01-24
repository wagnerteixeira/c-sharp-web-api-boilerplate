using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace WebApi.App_Start
{  

    public class ObservableDirectRouteProvider : IDirectRouteProvider
    {
        public IEnumerable<RouteEntry> DirectRoutes { get; private set; }

        public IReadOnlyList<RouteEntry> GetDirectRoutes(HttpControllerDescriptor controllerDescriptor, IReadOnlyList<HttpActionDescriptor> actionDescriptors, IInlineConstraintResolver constraintResolver)
        {
            var realDirectRouteProvider = new CustomDirectRouteProvider();
            var directRoutes = realDirectRouteProvider.GetDirectRoutes(controllerDescriptor, actionDescriptors, constraintResolver);
            // Store the routes in a property so that they can be retrieved later
            if (DirectRoutes == null)
                DirectRoutes = directRoutes;
            else
                DirectRoutes = DirectRoutes.Union(directRoutes);
            return directRoutes;
        }
    }
}