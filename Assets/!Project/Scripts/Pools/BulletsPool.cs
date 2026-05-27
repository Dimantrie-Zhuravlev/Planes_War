using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private List<GameObject> _bullets = new List<GameObject>();


    public static BulletsPool Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void Get(Transform firePoint)
    {
        var obj = _bullets?.FirstOrDefault(x => !x.activeSelf);
        if (obj == null)
        {
            obj = Create(firePoint);
        }
        else
        {
            obj.SetActive(true);
            obj.transform.position = firePoint.transform.position;
            obj.GetComponent<BulletMovement>().ChangeBulletTransform(firePoint);
            obj.GetComponent<BulletLifeTime>().EnableBulletLifecycle();
        }
    }

    public void Release(GameObject obj)
    {
        obj.GetComponent<BulletLifeTime>().DisableBulletLifecycle();
        obj.SetActive(false);
    }

    private GameObject Create(Transform firePoint)
    {
        var obj = Instantiate(_bulletPrefab, firePoint.position, firePoint.rotation, transform);
        obj.GetComponent<BulletLifeTime>().EnableBulletLifecycle();
        _bullets.Add(obj);
        return obj;
    }
}
