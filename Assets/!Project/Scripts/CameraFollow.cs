using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 10f, -10f);

    private void LateUpdate()
    {
        if (_target != null)
        {
            Vector3 desiredPosition = _target.position + _offset;

            Vector3 smoothedPosition = Vector3.Lerp(
                transform.position,
                desiredPosition,
                1
                );
            transform.position = smoothedPosition;
        }
    }
}
