using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class LifetimeSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text _lifiTimeText;

    private void Start()
    {
        GameResults.LifeTime = 0;
        StartCoroutine(AddTimeManager());
    }
    private IEnumerator AddTimeManager()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            DisplayLifetime();
        }
    }
    private void DisplayLifetime() {
        GameResults.LifeTime += 1;
        _lifiTimeText.text = $"lifeTime: {Math.DivRem(GameResults.LifeTime, 60, out _):D2}-{GameResults.LifeTime % 60:D2}";
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
