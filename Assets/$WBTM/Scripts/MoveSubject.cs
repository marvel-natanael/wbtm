using UnityEngine;
using PrimeTween;
using Cysharp.Threading.Tasks;

public class MoveSubject : MonoBehaviour
{ 
    [SerializeField]
    private float _distance = 5f;
    [SerializeField]
    private float _duration = 1f;

    public async UniTask Move(Vector3 direction)
    {
        Vector3 startPos = transform.position;
        await Tween.Position(transform, startPos + direction * _distance, _duration);
    }

    public async UniTask MoveRight()
    {
        await Move(Vector3.right);
    }

    public async UniTask MoveLeft()
    {
        await Move(Vector3.left);
    }

    public async UniTask MoveUp()
    {
        await Move(Vector3.up);
    }

    public async UniTask MoveDown()
    {
        await Move(Vector3.down);
    }

    public async UniTask MoveTo(Vector3 destination)
    {
        Vector3 startPos = transform.position;
        await Tween.Position(transform, destination, _duration);
    }

    public async UniTask MoveTo(Transform destination)
    {
        await Tween.Position(transform, destination.position, _duration);
    }

    public async UniTask MoveTo(RectTransform rectTransform, Vector3 destination)
    {
        if (rectTransform == null) return;
        Vector3 startPos = rectTransform.anchoredPosition3D;
        await Tween.UIAnchoredPosition3D(rectTransform, destination, _duration);
    }
}
