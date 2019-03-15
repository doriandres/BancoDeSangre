using System.Web.Mvc;
using System.Web.Routing;

namespace BancoDeSangre
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            throw new System.NotImplementedException();
        }
    }
}