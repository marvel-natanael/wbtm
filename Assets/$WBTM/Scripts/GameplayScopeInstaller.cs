using Reflex.Core;
using UnityEngine;

public class GameplayScopeInstaller : MonoBehaviour, IInstaller
{
    [SerializeField]
    private GameplayParametersModelSO _gameplayParameters;

    public void InstallBindings(ContainerBuilder builder)
    {
        //Details View
        var detailsView = FindFirstObjectByType<DetailsView>(FindObjectsInactive.Include);
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

        //Gameplay Parameters
        builder.RegisterValue(_gameplayParameters);

        //Entity Model Controller
        var entitiesModelController = FindFirstObjectByType<EntityModelController>(FindObjectsInactive.Include);
        builder.RegisterValue(entitiesModelController);

        //Entity Subject Controller
        var entitySubjectController = FindFirstObjectByType<EntitySubjectController>(FindObjectsInactive.Include);
        builder.RegisterValue(entitySubjectController);
    }
}
