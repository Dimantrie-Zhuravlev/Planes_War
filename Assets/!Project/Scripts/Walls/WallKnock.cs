using Unity.VisualScripting;
using UnityEngine;

public class WallKnock : MonoBehaviour
{
    [SerializeField] private float _knockBackForce = 250f;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private int _damageForDurability = 10;
    private BulletsPool _bulletPool;

    private void Start()
    {
        _bulletPool = BulletsPool.Instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<DurabilitySystem>().TakeDamage(_damageForDurability);
            Vector3 normal = collision.contacts[0].normal;
            Vector3 forceDirection = new Vector3(normal.x, 2f, normal.z).normalized;
            collision.rigidbody.AddForce(-forceDirection * _knockBackForce, ForceMode.Impulse);

            _audioSource.Play();
        }
        else
        {
            if (collision.gameObject.GetComponent<BulletMovement>())
            {
                _bulletPool.Release(collision.gameObject);
            } else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
