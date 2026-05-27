using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    [Header("Основные характеристики игрока")]
    [Space(10)]
    [Tooltip("Скорость поворота игрока")]
    [SerializeField] private float _initialRotationSpeed = 120f;
    [Tooltip("Скорость движения игрока")]
    [SerializeField] private float _initialMoveSpeed = 6f;
    [Tooltip("Урон одной пули")]
    [SerializeField] private int _intialBulletDamage = 10; // стрельба (LeftMouse)
    [Tooltip("Максимальный запас прочности")]
    [SerializeField] private int _inititalMaxCapacityEnergy = 50; // ускорение (W)
    [Tooltip("Количество восстанавливаемой энергии за интервал времени")]
    [SerializeField, Range(1, 5)] private  int _initialRestoreEnergyPerTime = 2;
    [Tooltip("Промежуток времени расхода энергии")]
    [SerializeField] private float _initiaLoseEnergyInterval = 0.2f;
    [Tooltip("Интервал восстановления энергии")]
    [SerializeField] private float _initialRestoreEnergyInterval = 0.5f;
    [Tooltip("Кол-во теряемой энергии за промежуток времени")]
    [SerializeField, Range(1, 5)] int _initialLoseEnergyPerTime = 1; //не меняется

    public static PlayerCharacteristics Instance { get; private set; }

    public float RotationSpeed => currentRotationSpeed;
    private float currentRotationSpeed;
    public float MoveSpeed => currentMoveSpeed;
    private float currentMoveSpeed;
    public float SprintSpeed => currentSprintSpeed; //Ускорение, считается как 2 скорости
    private float currentSprintSpeed;
    public int BulletDamage => currentBulletDamage;
    private int currentBulletDamage;
    public float BulletSpeed => currentBulletSpeed; //Скорость пули, считается как 2,5 текущей скорости
    private float currentBulletSpeed;
    public int MaxCapacityEnergy => currentMaxCapacity;
    private int currentMaxCapacity;
    public int RestoreEnergyPerTime => currentRestoreEnergyPerTime;
    private int currentRestoreEnergyPerTime;
    public float LoseEnergyInterval => currentLoseEnergyInterval;
    private float currentLoseEnergyInterval;
    public float RestoreEnergyInterval => currentRestoreEnergyInterval;
    private float currentRestoreEnergyInterval;

    public int LoseEnergyPerTime => currentLoseEnergyPerTime;
    private int currentLoseEnergyPerTime;

    //Все характеристики в теории можно прокачать
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        currentRotationSpeed = _initialRotationSpeed;
        currentMoveSpeed = _initialMoveSpeed;
        currentSprintSpeed = 2 * _initialMoveSpeed;
        currentBulletDamage = _intialBulletDamage;
        currentBulletSpeed = 2.5f * _initialMoveSpeed;
        currentMaxCapacity = _inititalMaxCapacityEnergy;
        currentRestoreEnergyPerTime = _initialRestoreEnergyPerTime;
        currentLoseEnergyInterval = _initiaLoseEnergyInterval;
        currentRestoreEnergyInterval = _initialRestoreEnergyInterval;
        currentLoseEnergyPerTime = _initialLoseEnergyPerTime;
    }
    /// <summary>
    /// Модификация скорости поворота игрока
    /// </summary>
    /// <param name="increase"></param>
    public void IncreaseRotationSpeed(int increaseRotationSpeed)
    {
        currentRotationSpeed += increaseRotationSpeed;
    }
    /// <summary>
    /// Модификация скорости движения и ускорения
    /// </summary>
    /// <param name="increase"></param>
    public void IncreaseMoveSpeed(int increaseMoveSpeed)
    {
        currentSprintSpeed = currentSprintSpeed * (increaseMoveSpeed / currentMoveSpeed + 1);
        currentMoveSpeed += increaseMoveSpeed;
        currentBulletSpeed = 2.5f * currentMoveSpeed;
    }
    /// <summary>
    /// Модификация наносимого урона одной пулей
    /// </summary>
    /// <param name="increase"></param>
    public void IncreaseDamage(int increaseBulletDamage)
    {
        currentBulletDamage += increaseBulletDamage;
    }
    /// <summary>
    /// Модификация максимального запаса энергии
    /// </summary>
    /// <param name="increase"></param>
    public void IncreaseMaxCapacityEnergy(int increaseMaxEnergy)
    {
        currentMaxCapacity += increaseMaxEnergy;
    }
    /// <summary>
    /// Модификация количества восстанавливаемой энергии
    /// </summary>
    /// <param name="increase"></param>
    public void IncreaseRestoreEnergyPerTimey(int increaseRestoreEnergy)
    {
        currentRestoreEnergyPerTime += increaseRestoreEnergy;
    }
    /// <summary>
    /// Повышение интервала трат энергии
    /// </summary>
    /// <param name="increase"></param>
    public void IncreaseRestoreEnergyPerTimey(float increaseLoseEnergyInterva)
    {
        currentLoseEnergyInterval += increaseLoseEnergyInterva;
    }
    /// <summary>
    /// Понижение интервала восстановления энергии
    /// </summary>
    /// <param name="increase"></param>
    public void DecreaseRestoreEnergyInterval(float descreaseLoseEnergyInterva)
    {
        currentRestoreEnergyInterval += descreaseLoseEnergyInterva;
    }
}
