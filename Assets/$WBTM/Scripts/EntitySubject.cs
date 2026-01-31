using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class EntitySubject : MonoBehaviour
{
    [SerializeField]
    private EntityModelSO _entityModelSO;

    private MoveSubject _moveSubject;
    private WiggleSubject _wiggleSubject;

    public EntityModelSO EntityModelSO => _entityModelSO;

    private void Awake()
    {
        _moveSubject = GetComponent<MoveSubject>();
        _wiggleSubject = GetComponent<WiggleSubject>();
    }

    public async UniTask OnSpawn(Transform destination, Action onFinish)
    {
        _wiggleSubject.SetWiggle(true);
        await _moveSubject.MoveTo(destination).ContinueWith(() =>
        {
            onFinish();
        });
    }

    public async UniTask OnIn(Action onFinish)
    {
        _wiggleSubject.SetWiggle(true);
        await _moveSubject.MoveRight().ContinueWith(() =>
        {
            onFinish();
        });
    }

    public async UniTask OnLeave(Action onFinish)
    {
        _wiggleSubject.SetWiggle(true);
        await _moveSubject.MoveLeft().ContinueWith(() =>
        {
            onFinish();
        });
    }
}
