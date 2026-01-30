using UnityEngine;

public class MenuController : MonoBehaviour
{
    private RoutingService _routingService => Ctx.Resolve<RoutingService>();

    public void GoToGameplay()
    {
        _routingService.LoadGameScene();
    }
}
