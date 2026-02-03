using TMPro;
using UnityEngine;
using System.Collections;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

public class DialogView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _dialogText;
    [SerializeField]
    private float _textDelay = 0.05f; 

    private MoveSubject _moveSubject;
    private Vector3 _originalPos;
    private Vector3 _hidePos;
    private RectTransform _rectTransform;

    private MoveSubject MoveSubject {
        get {
            if (_moveSubject == null) _moveSubject = GetComponent<MoveSubject>();
            return _moveSubject;
        }
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalPos = _rectTransform.anchoredPosition3D;
        _hidePos = _originalPos + Vector3.up * 1000;
    }

    public async UniTask ShowDialog()
    {
        await MoveSubject.MoveTo(_rectTransform, _originalPos); 
    }

    public async UniTask HideDialog()
    {
        _dialogText.text = "";
        await MoveSubject.MoveTo(_rectTransform, _hidePos);
    }

    public void UpdateDialogText(VerbalDescriptionModelSO descriptionModel)
    {
        StartCoroutine(TypeText(descriptionModel.VerbalContent));
    }

    private IEnumerator TypeText(string message)
    {
        _dialogText.text = "";
        foreach (char c in message)
        {
            _dialogText.text += c;
            yield return new WaitForSeconds(_textDelay);
        }
    } 
}
