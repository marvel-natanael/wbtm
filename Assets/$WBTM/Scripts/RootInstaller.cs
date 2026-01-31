using EasyTransition;
using Reflex.Core;
using UnityEngine;

public class RootInstaller : MonoBehaviour, IInstaller
{
    [SerializeField]
    private SceneRefs _sceneRefs;
    [SerializeField]
    private RoutingService _routingService; 

    public void InstallBindings(ContainerBuilder builder)
    {
        //Scene References
        builder.RegisterValue(_sceneRefs);

        //Routing Service
        builder.RegisterValue(_routingService); 
    }
}