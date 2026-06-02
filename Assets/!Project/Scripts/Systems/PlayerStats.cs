using System;
using TMPro;
using UnityEngine;
using System.IO;

namespace DefaultNameSpace
{
    public class PlayerStatsData
    {
        public int bulletsCount;
    }
    public class PlayerStats : MonoBehaviour
    {
        private int _bullets = 0;
        public static PlayerStats Instance { get; private set; }
        [SerializeField] TMP_Text _bulletsView;
        private const string _saveFileName = "player_save.json";
        private void Start()
        {
            Instance = this;
            LoadDataBullets();
            DisplayBullets();

        }
        public void AddBullet(int countBullets)
        {
            _bullets += countBullets;
            DisplayBullets();
        }
        private void DisplayBullets()
        {
            _bulletsView.text = $"Bullets: {_bullets:D5}";
        }

        public void LoadDataBullets()
        {
            if (File.Exists(_saveFileName))
            {
                string json = File.ReadAllText(_saveFileName);
                PlayerStatsData data = JsonUtility.FromJson<PlayerStatsData>(json);
                _bullets = data.bulletsCount;
            }
            else
            {
                _bullets = 0;
            }
        }

        public void SaveBullets()
        {
            PlayerStatsData data = new PlayerStatsData { bulletsCount = _bullets };
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(_saveFileName, json);
        }
        private void OnDestroy()
        {
            SaveBullets();
        }
    }


}



