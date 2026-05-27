using TMPro;
using UnityEngine;

public class EnemySystemScores : MonoBehaviour
{
    [Tooltip("Количество очков за убийство")]
    [SerializeField] int addScores = 20;

    private ScoreAndUpgradesSystem _scoreSystem;

    private void Start()
    {
        if (ScoreAndUpgradesSystem.Instance != null)
        {
            _scoreSystem = ScoreAndUpgradesSystem.Instance;
        }
    }
    public void AddScoresForKillEnemy()
    {
        _scoreSystem.ChangeScoresOnCount(addScores);
    }
}
