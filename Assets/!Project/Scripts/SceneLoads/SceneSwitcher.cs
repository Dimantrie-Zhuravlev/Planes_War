using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private enum ScenesName
    {
        Scene01_Menu,
        Scene02_Game,
        Scene03_Fail,
        Scene04_Win,
    }
    public void LoanMainMenu()
    {
        SceneManager.LoadScene(ScenesName.Scene01_Menu.ToString());
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(ScenesName.Scene02_Game.ToString());
    }
    public void LoadFailedScene()
    {
        SceneManager.LoadScene(ScenesName.Scene03_Fail.ToString());
    }
    public void LoadWinScene()
    {
        SceneManager.LoadScene(ScenesName.Scene04_Win.ToString());
    }
}
