using Reflex.Core;
using UnityEngine;

public class EndingScopeInstaller : MonoBehaviour, IInstaller
{
    public void InstallBindings(ContainerBuilder builder)
    {
        //Ending View
        var endingView = FindFirstObjectByType<EndingView>(FindObjectsInactive.Include);
        builder.RegisterValue(endingView);
    }
}
