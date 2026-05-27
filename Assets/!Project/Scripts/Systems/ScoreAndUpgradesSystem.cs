using TMPro;
using UnityEngine;

public class ScoreAndUpgradesSystem : MonoBehaviour
{
    private int upgadeLevel = 0;
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] private HintAchivement _hint;
    [SerializeField] private PlayerCharacteristics _playerCharacter;

    public static ScoreAndUpgradesSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        GameResults.Scores = 0;
        DisplayScores();
    }
    /// <summary>
    /// Меняет количество очков на указанное значение (слева вверху)
    /// </summary>
    /// <param name="addScores"></param>
    public void ChangeScoresOnCount(int addScores) {
        GameResults.Scores += addScores;
        if (upgadeLevel == 0 && GameResults.Scores >= 100)
        {
            upgadeLevel = 1;
            _playerCharacter.IncreaseDamage(10);
            _playerCharacter.IncreaseRotationSpeed(60);
            _hint.DisplayHint("Урон повышен с 10 до 20 и скорость поворот с 120 до 180 за достижение 100очков");
        }
        if (upgadeLevel == 1 && GameResults.Scores >= 300)
        {
            upgadeLevel = 2;
            _playerCharacter.IncreaseDamage(10);
            _playerCharacter.IncreaseRotationSpeed(60);
            _hint.DisplayHint("Урон повышен с 20 до 30 и скорость поворота с 180 до 240 за достижение 300 очков. Победа");
        }
        DisplayScores();
    }
    private void DisplayScores()
    {
         _scoreText.text = $"Score: {GameResults.Scores:D4}";
    }
}
