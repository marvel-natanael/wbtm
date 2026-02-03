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

    private EntityModel _entityModelSO;
    private MoveSubject _moveSubject;
    private WiggleSubject _wiggleSubject;

    public EntityModel EntityModelSO
    {
        get => _entityModelSO;
    }

    private void Awake()
    {
        _moveSubject = GetComponent<MoveSubject>();
        _wiggleSubject = GetComponent<WiggleSubject>();
    }

    public async UniTask OnSpawn(EntityModel entityModel, Transform destination, Action onFinish)
    {
        _entityModelSO = entityModel;
        _headImage.sprite = entityModel.HeadDescription.VisualContent;
        _clothImage.sprite = entityModel.ClothDescription.VisualContent;

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
