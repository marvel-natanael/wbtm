using UnityEngine;

public class EndingController : MonoBehaviour
{ 
    private RoutingService _routingService => Ctx.Resolve<RoutingService>();

    public void GoToMenu()
    {
        _routingService.LoadMenuScene();
    }
}
