using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] TMP_Text _energyView;
    [SerializeField] private PlayerCharacteristics _playerCharacter;
        
    private int _currentEnergy;
    private Coroutine _energyLoseCoroutine;
    private Coroutine _energyRestoreCoroutine;

    public bool checkActivateAccelerate()
    {
        return _currentEnergy > 0;
    }

    private void Start()
    {
        setNewEnergy(_playerCharacter.MaxCapacityEnergy);
    }
    private IEnumerator EnableAccelerateCoroutine()
    {
        StopRestoreEnergy();
        while (true)
        {
            yield return new WaitForSeconds(_playerCharacter.LoseEnergyInterval);
            setNewEnergy(_currentEnergy - _playerCharacter.LoseEnergyPerTime);

            if (_currentEnergy <= 0)
            {
                StopAccelerate();
                yield break;
            }
        }
    }
    private IEnumerator DisableAccelerateCoroutine()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            yield return new WaitForSeconds(_playerCharacter.RestoreEnergyInterval);
            setNewEnergy(_currentEnergy + _playerCharacter.RestoreEnergyPerTime);

            if (_currentEnergy >= _playerCharacter.MaxCapacityEnergy)
            {
                StopRestoreEnergy();
                yield break;
            }
        }
    }

    public void EnableAccelerate()
    {
        if (_energyLoseCoroutine == null)
        {
            _energyLoseCoroutine = StartCoroutine(EnableAccelerateCoroutine());
        }
    }
    public void StopAccelerate()
    {
        if (_energyLoseCoroutine != null)
        {
            StopCoroutine(_energyLoseCoroutine);
            _energyLoseCoroutine = null;
            if (_energyRestoreCoroutine == null)
            {
                _energyRestoreCoroutine = StartCoroutine(DisableAccelerateCoroutine());
            }
        }
    }
    private void StopRestoreEnergy()
    {
        if (_energyRestoreCoroutine != null)
        {
            StopCoroutine(_energyRestoreCoroutine);
            _energyRestoreCoroutine = null;
        }
    }

    public void setNewEnergy(int energy)
    {
        _currentEnergy = Mathf.Clamp(energy, 0, _playerCharacter.MaxCapacityEnergy);
        DisplayEnergy(_currentEnergy);
    }


    private void DisplayEnergy(int energy)
    {
        _energyView.text = $"Energy: {energy:D3}";
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
