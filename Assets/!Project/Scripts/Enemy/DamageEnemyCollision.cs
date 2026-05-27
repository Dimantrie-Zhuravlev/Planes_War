using UnityEngine;

public class DamageEnemyCollision : MonoBehaviour
{
    [SerializeField] int _damageOnCollision = 15;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<DurabilitySystem>(out var durability))
        {
            durability.TakeDamage(_damageOnCollision);
            Destroy(gameObject);
        }
    }
}
