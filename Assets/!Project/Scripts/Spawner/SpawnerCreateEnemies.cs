using System.Collections;
using UnityEngine;

public class SpawnerCreateEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] _planePrefabs;
    [SerializeField] private float _createEnemyInterval = 2f;
    [SerializeField] Transform player;

    private int currentIndexPlaneCreate = 0;

    private enum PlaneType
    {
        BlackPlane,
        FastPlane,
        SmallFastPlane,
        BigSlowPlane
    }

    private void Start()
    {
        StartCoroutine(createPlaneCoroutine());
    }
    private IEnumerator createPlaneCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_createEnemyInterval);
            currentIndexPlaneCreate = (currentIndexPlaneCreate+1) % _planePrefabs.Length;
            GameObject prefab = _planePrefabs[currentIndexPlaneCreate];
            PlaneType planeType = (PlaneType)currentIndexPlaneCreate;

            Vector3 directionToPlayer = player.position - transform.position;
            Quaternion spawnRotation = Quaternion.LookRotation(directionToPlayer);
            switch (planeType)
            {
                case PlaneType.BlackPlane:
                    Instantiate(_planePrefabs[currentIndexPlaneCreate], transform.position, spawnRotation, transform);
                    break;
                case PlaneType.FastPlane:
                    Instantiate(_planePrefabs[currentIndexPlaneCreate], transform.position, spawnRotation, transform);
                    break;
                case PlaneType.SmallFastPlane:
                    Instantiate(_planePrefabs[currentIndexPlaneCreate], transform.position, spawnRotation, transform);
                    break;
                case PlaneType.BigSlowPlane:
                    Instantiate(_planePrefabs[currentIndexPlaneCreate], transform.position, spawnRotation, transform);
                    break;
                default:
                    Instantiate(prefab, transform.position, transform.rotation);
                    break;
            }
        }
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
