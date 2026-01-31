using Reflex.Attributes;
using UnityEngine;
using EasyTransition;

public class RoutingService : MonoBehaviour
{
    [SerializeField]
    TransitionSettings transition;
    [SerializeField]
    float startDelay;

    private SceneRefs _sceneRefs => Ctx.Resolve<SceneRefs>();

    public void LoadEndingScene()
    { 
        TransitionManager.Instance().Transition(_sceneRefs.EndingScene.Name, transition, startDelay);
    }

    public void LoadGameScene()
    {
        TransitionManager.Instance().Transition(_sceneRefs.GameScene.Name, transition, startDelay);
    }

    public void LoadMenuScene()
    {
        TransitionManager.Instance().Transition(_sceneRefs.MenuScene.Name, transition, startDelay);
    }
}