using TMPro;
using UnityEngine;

public class InitializerLoadScenesElement : MonoBehaviour
{
    [SerializeField] private GameObject _backgroundMusicPrefab;

    private enum PrefabSceneElements
    {
        BackgroundMusic
    }

    private void Awake()
    {
        if (GameObject.Find(PrefabSceneElements.BackgroundMusic.ToString()) == null)
        {
            GameObject instance = Instantiate(_backgroundMusicPrefab);
            instance.name = PrefabSceneElements.BackgroundMusic.ToString();
            DontDestroyOnLoad(instance);
        }
    }
}
