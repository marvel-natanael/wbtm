using UnityEngine;
using PrimeTween;

public class WalkSubject : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;
    [SerializeField] private float _distance = 5f;
    [SerializeField] private float _duration = 1f;
    [SerializeField] private bool _walkEnabled = false;

    void Start()
    {
        StartRepeatingWalk();
    }

    private void StartRepeatingWalk()
    {
        Vector3 startPos = transform.position;
        Sequence.Create()
            .Chain(Tween.Position(transform, startPos + Vector3.right * _distance, _duration)) 
            .SetRemainingCycles(!_walkEnabled);
    }

    public void StartWalking(Vector3 direction)
    {
        Vector3 startPos = transform.position;
        Sequence.Create()
            .Chain(Tween.Position(transform, startPos + direction * _distance, _duration))
            .ChainDelay(_delay);
    }

    public void WalkRight()
    {
        StartWalking(Vector3.right);
    }

    public void WalkLeft()
    {
        StartWalking(Vector3.left);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(50, 50, 150, 50), "Test Walk Left"))
        {
            WalkLeft();
        }
        if (GUI.Button(new Rect(100, 50, 150, 50), "Test Walk Right"))
        {
            WalkRight();
        }
    }
}
