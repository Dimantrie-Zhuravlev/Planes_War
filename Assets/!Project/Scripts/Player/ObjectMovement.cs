using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private PlayerCharacteristics _playerCharacter;

    [SerializeField] private PlayerEnergy _playerEnergy;

    private bool _isSprinting = false;
    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = _playerCharacter.MoveSpeed;
    }

    public void Rotate(float rotationInput)
    {
        float rotationAmount = rotationInput * _playerCharacter.RotationSpeed * Time.fixedDeltaTime;
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(0, rotationAmount, 0));
    }
    private float SetCurrentSpeed()
    {
        if (_isSprinting && _playerEnergy.checkActivateAccelerate())
        {
            _playerEnergy.EnableAccelerate();
            return _playerCharacter.SprintSpeed;
        }
        return _playerCharacter.MoveSpeed;
    }

    public void MoveForward()
    {
        if (!_rb.isKinematic)
        {
            _currentSpeed = SetCurrentSpeed();
            _rb.linearVelocity = transform.forward * _currentSpeed;
        }
    }
    public void SetSprint(bool isSprinting)
    {
        _isSprinting = isSprinting;
        if (!_isSprinting)
        {
            _playerEnergy.StopAccelerate();
        }
    }
}
