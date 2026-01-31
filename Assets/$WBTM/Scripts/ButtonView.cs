using SpeechBubble;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject _outline;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        StopAnimation();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayAnimation();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAnimation();
    }

    void StopAnimation()
    {
        _animator.enabled = false;
        _outline.SetActive(false);
    }

    void PlayAnimation()
    {
        _animator.enabled = true;
        _outline.SetActive(true);
    }
}
