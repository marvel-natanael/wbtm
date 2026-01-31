using UnityEngine;

public class GameplayStateController : MonoBehaviour
{ 
    private GameplayParametersModelSO _gameplayParameters => Ctx.Resolve<GameplayParametersModelSO>();
    private EntitiesController _entitiesController => Ctx.Resolve<EntitiesController>();

    public void DetermineWinOrLose()
    {
        _entitiesController.ProcessEntity();
        if(_entitiesController.BadEntitiesInside >= _gameplayParameters.BadEntitiesToLose)
        {
            Dbg.Log("LOSS");
        }
        else
        {
            Dbg.Log("WIN"); 
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 150, 150, 50), "Check Win or Lose"))
        {
            DetermineWinOrLose();
        }
    }
}
