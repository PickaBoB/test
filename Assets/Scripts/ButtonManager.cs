using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
