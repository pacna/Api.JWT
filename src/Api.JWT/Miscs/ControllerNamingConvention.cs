using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Api.JWT.Miscs;

public class ControllerNamingConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        controller.ControllerName = controller.ControllerName.ToLowerInvariant();
    }
}