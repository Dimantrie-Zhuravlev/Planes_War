using TMPro;
using UnityEngine;

public class DisplayScores : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private void Start()
    {
        _text.text = $"Ваш результат: {GameResults.Scores} очков, {GameResults.LifeTime} сек прожитого времени";
    }
}
