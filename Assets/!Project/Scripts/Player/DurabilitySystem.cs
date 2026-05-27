using TMPro;
using UnityEngine;

public class DurabilitySystem : MonoBehaviour, IDamage
{
    [SerializeField] TMP_Text _playerDurabilityText;
    [SerializeField] int _maxDurability = 100;
    [SerializeField] ObjectDestroy _objectDestroy;
    [SerializeField] AudioSource _audioDamage;

    private int health;

    private void Start()
    {
        health = _maxDurability;
        DisplayHealth(health);
    }
    public void TakeDamage(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, _maxDurability);
        DisplayHealth(health);
        if (health == 0)
        {
            _objectDestroy.ObjectDefeat();
        } else
        {
            _audioDamage.Play();
        }
    }

    private void DisplayHealth(int health)
    {
        _playerDurabilityText.text = $"Health: {health:D3}";
    }
}
