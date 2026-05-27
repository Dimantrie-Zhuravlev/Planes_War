using System.Collections;
using TMPro;
using UnityEngine;

public class HintAchivement : MonoBehaviour
{
    [SerializeField] TMP_Text _hintText;
    private Coroutine _coroutine;

    public void DisplayHint(string text)
    {
        _hintText.text = text;
        if (_coroutine != null )
        {
            StopAllCoroutines();
        }
        _coroutine = StartCoroutine(DisplayHint());
    }
    private IEnumerator DisplayHint()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            _hintText.text = "";
            _coroutine = null;
        }
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
