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

    private void Awake()
    {
        _moveSubject = GetComponent<MoveSubject>();
    }

    public async UniTask ShowDialog()
    {
        await _moveSubject.MoveDown();
    }

    public async UniTask HideDialog()
    {
        _dialogText.text = "";
        await _moveSubject.MoveUp();
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
