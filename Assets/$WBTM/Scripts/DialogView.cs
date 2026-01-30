using TMPro;
using UnityEngine;
using System.Collections;

public class DialogView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _dialogText;
    [SerializeField]
    private float _textDelay = 0.05f;

    public void ShowDialog(DialogModelSO dialogModelSO)
    {
        StartCoroutine(TypeText(dialogModelSO.Message));
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

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 50), "Test Typing Effect"))
        {
            var testDialog = ScriptableObject.CreateInstance<DialogModelSO>();
            testDialog.Message = "Hello, this is a test message for the typing effect!";
            ShowDialog(testDialog);
        }
    }
}
