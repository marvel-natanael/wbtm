using UnityEngine;

public class EndingController : MonoBehaviour
{
    private GameplayParametersModelSO _gameplayParams => Ctx.Resolve<GameplayParametersModelSO>();
    private EndingView _endingView => Ctx.Resolve<EndingView>();
    private RoutingService _routingService => Ctx.Resolve<RoutingService>();

    public static int BadEntitesAmount;
    public static bool GoodEntityLeft;

    private void Start()
    {
        ManageEndingView();
    }

    public void ManageEndingView()
    {
        if(GoodEntityLeft)
        {
            _endingView.ShowEnding2();
            return;
        }

        if (BadEntitesAmount == 0)
        {
            _endingView.ShowEnding1();
        }
        else if (BadEntitesAmount >= _gameplayParams.BadEntitiesToLose)
        {
            _endingView.ShowEnding3();
        }
        else
        {
            _endingView.ShowEnding4();
        }
    }

    public void GoToMenu()
    {
        _routingService.LoadMenuScene();
    }
}
