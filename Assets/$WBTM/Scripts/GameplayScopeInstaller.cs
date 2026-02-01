using Reflex.Core;
using UnityEngine;

public class GameplayScopeInstaller : MonoBehaviour, IInstaller
{

    public void InstallBindings(ContainerBuilder builder)
    {
        //Details View
        var detailsView = FindFirstObjectByType<HintView>(FindObjectsInactive.Include);
        builder.RegisterValue(detailsView);

        //Dialog View
        var dialogView = FindFirstObjectByType<DialogView>(FindObjectsInactive.Include);
        builder.RegisterValue(dialogView);

        //Hint Controller
        var hintController = FindFirstObjectByType<HintController>(FindObjectsInactive.Include);
        builder.RegisterValue(hintController);

        //Zoom Controller
        var zoomController = FindFirstObjectByType<ZoomController>(FindObjectsInactive.Include);
        builder.RegisterValue(zoomController);

        //Entity Model Controller
        var entitiesModelController = FindFirstObjectByType<EntityModelController>(FindObjectsInactive.Include);
        builder.RegisterValue(entitiesModelController);

        //Entity Subject Controller
        var entitySubjectController = FindFirstObjectByType<EntitySubjectController>(FindObjectsInactive.Include);
        builder.RegisterValue(entitySubjectController);

        //Visitor Count View
        var visitorCountView = FindFirstObjectByType<VisitorCountView>(FindObjectsInactive.Include);
        builder.RegisterValue(visitorCountView);
    }
}
