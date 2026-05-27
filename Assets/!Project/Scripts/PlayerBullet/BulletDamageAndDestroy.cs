using TMPro;
using UnityEngine;

public class BulletDamageAndDestroy : MonoBehaviour
{
    private PlayerCharacteristics _playerCharacter;
    private BulletsPool _bulletPool;
    void Start()
    {
        _bulletPool = BulletsPool.Instance;
        if (PlayerCharacteristics.Instance != null)
        {
            _playerCharacter = PlayerCharacteristics.Instance;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyDurabilitySystem>(out var enemy))
        {
            enemy.TakeDamage(_playerCharacter.BulletDamage);
        }
        _bulletPool.Release(gameObject);
        //Destroy(gameObject);
    }
}
