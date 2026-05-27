using UnityEngine;

public class EnemyRotateToPlayer : MonoBehaviour
{
    private PlayerController player;
    public float rotationSpeed = 90f;
    private ObjectDestroy _objectDestroy;
    private void Start()
    {
        if (PlayerController.Instance != null)
        {
            player = PlayerController.Instance;
        }
        if (ObjectDestroy.Instance != null)
        {
            _objectDestroy = ObjectDestroy.Instance;
        }
    }

    private void Update()
    {
        if (player == null) { return; }
        Vector3 targetDirection = (player.gameObject.transform.position - transform.position).normalized;
        Quaternion targetRotation = _objectDestroy.IsPlayerDestroy ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
