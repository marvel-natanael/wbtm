using UnityEngine;

public class EndingController : MonoBehaviour
{
    private GameplayParametersModelSO _gameplayParams => Ctx.Resolve<GameplayParametersModelSO>();
    private EndingView _endingView => Ctx.Resolve<EndingView>();
    private RoutingService _routingService => Ctx.Resolve<RoutingService>();

    public static int BadEntitesAmount;

    private void OnEnable()
    {
        ManageEndingView();
    }

    public void ManageEndingView()
    {
        if (BadEntitesAmount == 0)
        {
            _endingView.ShowEnding1();
        }
        else if (BadEntitesAmount > 0 && BadEntitesAmount < _gameplayParams.BadEntitiesToLose)
        {
            _endingView.ShowEnding2();
        }
        else
        {
            _endingView.ShowEnding3();
        }
    }

    public void GoToMenu()
    {
        _routingService.LoadMenuScene();
    }
}
