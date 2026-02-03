using Cysharp.Threading.Tasks; 
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GameplayStateController : MonoBehaviour
{
    private EntitySubject _currentEntitySubject;
    private int _entityCount;

    private DialogView _dialogView;
    private GameplayParametersModelSO _gameplayParameters;
    private EntityModelController _entitiesModelController;
    private EntitySubjectController _entitySubjectController;
    private RoutingService _routingService;
    private HintController _hintController;
    private VisitorCountView _visitorCountView;

    private DialogView DialogView {
        get {
            if (_dialogView == null) _dialogView = Ctx.Resolve<DialogView>();
            return _dialogView;
        }
    }
    private GameplayParametersModelSO GameplayParameters {
        get {
            if (_gameplayParameters == null) _gameplayParameters = Ctx.Resolve<GameplayParametersModelSO>();
            return _gameplayParameters;
        }
    }
    private EntityModelController EntitiesModelController {
        get {
            if (_entitiesModelController == null) _entitiesModelController = Ctx.Resolve<EntityModelController>();
            return _entitiesModelController;
        }
    }
    private EntitySubjectController EntitySubjectController {
        get {
            if (_entitySubjectController == null) _entitySubjectController = Ctx.Resolve<EntitySubjectController>();
            return _entitySubjectController;
        }
    }
    private RoutingService RoutingService {
        get {
            if (_routingService == null) _routingService = Ctx.Resolve<RoutingService>();
            return _routingService;
        }
    }
    private HintController HintController {
        get {
            if (_hintController == null) _hintController = Ctx.Resolve<HintController>();
            return _hintController;
        }
    }
    private VisitorCountView VisitorCountView {
        get {
            if (_visitorCountView == null) _visitorCountView = Ctx.Resolve<VisitorCountView>();
            return _visitorCountView;
        }
    }

    private async void Start()
    {
        EndingController.GoodEntityLeft = false;
        VisitorCountView.UpdateText(_entityCount, GameplayParameters.EntitiesPerLevel);
        EntitiesModelController.GetPossibleEntities(GameplayParameters.EntitiesPerLevel, GameplayParameters.BadEntitiesToLose);

        await DialogView.HideDialog().ContinueWith(() =>
        {
            HintController.SetHintModel(EntitiesModelController.BadEntities);
            CallNextEntity();
        });
    }

    void DetermineWhatNext()
    {
        _entityCount++;
        if (_entityCount >= GameplayParameters.EntitiesPerLevel)
        {
            DetermineWinOrLose();
        }
        else
        {
            CallNextEntity();
        }
    }

    public void DetermineWinOrLose()
    {
        EntitiesModelController.ProcessEntity();
        EndingController.BadEntitesAmount = EntitiesModelController.BadEntitiesInside;
        RoutingService.LoadEndingScene();
    }

    public void CallNextEntity()
    {
        VisitorCountView.UpdateText(_entityCount, GameplayParameters.EntitiesPerLevel);
        _currentEntitySubject = EntitySubjectController.SpawnEntity(EntitiesModelController.PossibleEntities[_entityCount],
            async () =>
        {
            await DialogView.ShowDialog().ContinueWith(() =>
             {
                 DialogView.UpdateDialogText(_currentEntitySubject.EntityModelSO.VoiceDescription);
             });
        });
    }

    public async void AllowEntityIn()
    {
        EntitiesModelController.AddEntity(_currentEntitySubject.EntityModelSO);
        await DialogView.HideDialog().ContinueWith(async () =>
        {
            await _currentEntitySubject.OnIn(() =>
            {
                DetermineWhatNext();
            });
        });
    }

    public async void LeaveEntityOut()
    {
        if (!EntitiesModelController.IsBadEntity(_currentEntitySubject.EntityModelSO))
        {
            EndingController.GoodEntityLeft = true;
        } 
        await DialogView.HideDialog().ContinueWith(async () =>
        {
            await _currentEntitySubject.OnLeave(() =>
            {
                DetermineWhatNext();
            });
        });
    }
}
