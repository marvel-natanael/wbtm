using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayStateController : MonoBehaviour
{
    private EntitySubject _currentEntitySubject;
    private int _entityCount;

    private DialogView _dialogView => Ctx.Resolve<DialogView>();
    private GameplayParametersModelSO _gameplayParameters => Ctx.Resolve<GameplayParametersModelSO>();
    private EntityModelController _entitiesModelController => Ctx.Resolve<EntityModelController>();
    private EntitySubjectController _entitySubjectController => Ctx.Resolve<EntitySubjectController>();
    private RoutingService _routingService => Ctx.Resolve<RoutingService>();
    private HintController _hintController => Ctx.Resolve<HintController>();
    private VisitorCountView _visitorCountView => Ctx.Resolve<VisitorCountView>();

    private async void Start()
    {
        _visitorCountView.UpdateText(_entityCount, _gameplayParameters.EntitiesPerLevel);

        _entitiesModelController.GetPossibleEntities(_gameplayParameters.EntitiesPerLevel, _gameplayParameters.BadEntitiesToLose);
        _hintController.SetHintModel(_entitiesModelController.BadEntities);
        await _dialogView.HideDialog().ContinueWith(() =>
        {
            CallNextEntity();
        });
    }

    void DetermineWhatNext()
    {
        _entityCount++;
        if (_entityCount >= _gameplayParameters.EntitiesPerLevel)
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
        _entitiesModelController.ProcessEntity();
        EndingController.BadEntitesAmount = _entitiesModelController.BadEntitiesInside;
        _routingService.LoadEndingScene();
    }

    public void CallNextEntity()
    {
        _visitorCountView.UpdateText(_entityCount, _gameplayParameters.EntitiesPerLevel);
        _currentEntitySubject = _entitySubjectController.SpawnEntity(_entitiesModelController.PossibleEntities[_entityCount],
            async () =>
        {
            await _dialogView.ShowDialog().ContinueWith(() =>
             {
                 _dialogView.UpdateDialogText(_currentEntitySubject.EntityModelSO.VoiceDescription);
             });
        });
    }

    public async void AllowEntityIn()
    {
        _entitiesModelController.AddEntity(_currentEntitySubject.EntityModelSO);
        await _dialogView.HideDialog().ContinueWith(async () =>
        {
            await _currentEntitySubject.OnIn(() =>
            {
                DetermineWhatNext();
            });
        });
    }

    public async void LeaveEntityOut()
    {
        await _dialogView.HideDialog().ContinueWith(async () =>
        {
            await _currentEntitySubject.OnLeave(() =>
            {
                DetermineWhatNext();
            });
        });
    }
}
