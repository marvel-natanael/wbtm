using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EntitySubject : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _headImage;
    [SerializeField]
    private SpriteRenderer _clothImage;

    private EntityModelSO _entityModelSO;
    private MoveSubject _moveSubject;
    private WiggleSubject _wiggleSubject;

    public EntityModelSO EntityModelSO
    {
        get => _entityModelSO;  
    }

    private void Awake()
    {
        _moveSubject = GetComponent<MoveSubject>();
        _wiggleSubject = GetComponent<WiggleSubject>();
    }

    public async UniTask OnSpawn(EntityModelSO entityModelSO, Transform destination, Action onFinish)
    {
        _entityModelSO = entityModelSO;
        _headImage.sprite = entityModelSO.HeadDescription.VisualContent;
        _clothImage.sprite = entityModelSO.ClothDescription.VisualContent;

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
