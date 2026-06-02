using System.Collections;
using System.Linq;
using UnityEngine;

public class GunSystemController : MonoBehaviour
{
    [SerializeField] private Transform[] _bulletPoints;
    [SerializeField] private float _gunPeriodActivate = 0.5f;
    private BulletsPool _bulletPool;

    private void Start()
    {
        _bulletPool = BulletsPool.Instance;
    }


    private bool _canAttack = true;
    public void activateGun()
    {
        if (_canAttack)
        {
            StartCoroutine(EnableGun());
            DefaultNameSpace.PlayerStats.Instance.AddBullet(_bulletPoints.Length);
            foreach (Transform firePoint in _bulletPoints)
            {
                _bulletPool.Get(firePoint);
            }

            _canAttack = false;
            StartCoroutine(EnableGun());
        }

    }

    private IEnumerator EnableGun()
    {
        yield return new WaitForSeconds(_gunPeriodActivate);
        _canAttack = true;
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
