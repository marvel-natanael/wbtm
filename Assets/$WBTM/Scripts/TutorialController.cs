using UnityEngine;

public class TutorialController : MonoBehaviour
{
    private RoutingService _routingService => Ctx.Resolve<RoutingService>();

    public void GoToGameplay()
    {
        _routingService.LoadGameScene();
    }
}
