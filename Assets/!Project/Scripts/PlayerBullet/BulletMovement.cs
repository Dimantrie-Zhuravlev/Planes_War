using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    private PlayerCharacteristics _playerCharacter;



    private void Start()
    {
        if (PlayerCharacteristics.Instance != null)
        {
            _playerCharacter = PlayerCharacteristics.Instance;
        }
        ChangeBulletTransform(transform);
    }
    /// <summary>
    /// Необходимо чтобы перезаписывать направление при пересоздании пуль из пула
    /// </summary>
    public void ChangeBulletTransform(Transform bulletTransform)
    {
        _rb.linearVelocity = bulletTransform.forward * _playerCharacter.BulletSpeed;
    }
}
