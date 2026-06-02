using System.Collections;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    [SerializeField] SceneSwitcher _sceneSwitcher;
    [SerializeField] float loseInterval = 2f;
    [SerializeField] AudioSource _audioFailed;
    [Space(10)]
    [Header("Свойства-объекта")]
    [Space(5)]
    [SerializeField] Rigidbody _rb;
    [SerializeField] Collider _collider;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private PlayerController _playerController;

    private bool isPlayerDestroy;
    public static ObjectDestroy Instance { get; private set; }

    public bool IsPlayerDestroy => isPlayerDestroy;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        isPlayerDestroy = false;
    }

    public void ObjectDefeat()
    {
        isPlayerDestroy = true;
        _rb.isKinematic = true;
        _rb.detectCollisions = false;
        _collider.enabled = false;
        _renderer.enabled = false;
        _audioFailed.Play();
        StartCoroutine(DestroyPlayer());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    private IEnumerator DestroyPlayer()
    {
        DefaultNameSpace.PlayerStats.Instance.SaveBullets();
        _playerController.OnDisable();
        yield return new WaitForSeconds(loseInterval);
        if (GameResults.Scores >= 300)
        {
            _sceneSwitcher.LoadWinScene();
        }
        else
        {
            _sceneSwitcher.LoadFailedScene();
        }

    }
}
