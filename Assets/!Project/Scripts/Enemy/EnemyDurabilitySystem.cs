using TMPro;
using UnityEngine;

public class EnemyDurabilitySystem : MonoBehaviour, IDamage
{
    [SerializeField] int _maxDurability = 100;
    [SerializeField] EnemySystemScores _scores;

    private int currentHealth;

    private void Start()
    {
        currentHealth = _maxDurability;
    }
    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, _maxDurability);
        if (currentHealth == 0)
        {
            _scores.AddScoresForKillEnemy();
            Destroy(gameObject);
        }
    }
}
