using UnityEngine;
using System.Collections;

public class BulletLifeTime : MonoBehaviour
{
    private BulletsPool _bulletPool;
    private Coroutine _coroutineLifecycle;
    void Start()
    {
        _bulletPool = BulletsPool.Instance;
        EnableBulletLifecycle();
    }

    /// <summary>
    /// Запуск ЖЦ в 3 секунды
    /// </summary>
    /// 
    public void EnableBulletLifecycle()
    {
        if (_coroutineLifecycle == null)
        {
            _coroutineLifecycle = StartCoroutine(EnableLifecycleCoroutine());
        } else
        {
            StopAllCoroutines();
            _coroutineLifecycle = StartCoroutine(EnableLifecycleCoroutine());
        }
    }
    /// <summary>
    /// очистка ЖЦ
    /// </summary>
    public void DisableBulletLifecycle()
    {
        _coroutineLifecycle = null;
        StopAllCoroutines();
    }

    public IEnumerator EnableLifecycleCoroutine()
    {
        yield return new WaitForSeconds(3);
        _bulletPool.Release(gameObject);
    }

}
