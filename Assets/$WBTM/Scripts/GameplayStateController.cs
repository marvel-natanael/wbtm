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

    private async void Start()
    {
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
        EndingView.IsWin = _entitiesModelController.BadEntitiesInside < _gameplayParameters.BadEntitiesToLose;
        _routingService.LoadEndingScene();
    }

    public void CallNextEntity()
    {
        _currentEntitySubject = _entitySubjectController.SpawnEntity(async () =>
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
