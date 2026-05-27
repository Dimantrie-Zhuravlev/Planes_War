using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ObjectMovement _objectMovement;
    [SerializeField] private GunSystemController _gunSystem;

    public static PlayerController Instance { get; private set; }


    [Header("Имена пользовательского ввода Player")]
    [SerializeField] private string _rotateActionName = "Rotate"; // Только поворот (A/D или геймпад)
    [SerializeField] private string _accelerationActionName = "Accelerate"; // Ускорение (W)
    [SerializeField] private string _gunActionName = "Gun"; // стрельба (LeftMouse)

    private InputAction _rotateAction;
    private InputAction _accelerationAction;
    private InputAction _gunAction;

    private float _rotationInput;
    private bool _gunEnabled = false;

    private void Awake()
    {
        if (Instance !=null && Instance !=this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void OnEnable()
    {
        _rotateAction?.Enable();
        _accelerationAction?.Enable();
        _gunAction?.Enable();
    }
    public void OnDisable()
    {
        _rotateAction?.Disable();
        _accelerationAction?.Disable();
        _gunAction?.Disable();//выключить обработку действий движения
    }

    private void Start()
    {
        _rotateAction = _playerInput.actions[_rotateActionName];
        _accelerationAction = _playerInput.actions[_accelerationActionName];
        _gunAction = _playerInput.actions[_gunActionName];

        _rotateAction.performed += OnRotate;
        _rotateAction.canceled += OnRotate;
        _accelerationAction.performed += OnSprint;
        _accelerationAction.canceled += OnSprint;
        _gunAction.performed += OnActivateGunSystem;
        _gunAction.canceled += OnActivateGunSystem;
    }
    public void OnRotate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _rotationInput = context.ReadValue<Vector2>().x; // Только горизонтальный ввод (A/D)
        }
        else if (context.canceled)
        {
            _rotationInput = 0;
        }
    }
    public void OnActivateGunSystem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _gunEnabled = true;

        }
        else if (context.canceled)
        {
            _gunEnabled = false;
        }
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _objectMovement.SetSprint(true);
        }
        else if (context.canceled)
        {
            _objectMovement.SetSprint(false);
        }
    }
    private void FixedUpdate()
    {
        // Всегда движемся вперёд
        _objectMovement.MoveForward();
        if (_rotationInput != 0)
        {
            _objectMovement.Rotate(_rotationInput);
        }
        if (_gunEnabled)
        {
            _gunSystem.activateGun();
        }
    }

    private void OnDestroy()
    {
        _rotateAction.performed -= OnRotate;
        _rotateAction.canceled -= OnRotate;
        _accelerationAction.performed -= OnSprint;
        _accelerationAction.canceled -= OnSprint;
        _gunAction.performed -= OnSprint;
        _gunAction.canceled -= OnSprint;
    }
}
