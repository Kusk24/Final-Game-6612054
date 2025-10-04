using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayMadDriver()
    {
        SceneManager.LoadScene("MadDriver");
    }

    public void PlayFlying()
    {
        SceneManager.LoadScene("Flying");
    }

    public void PlaySumo()
    {
        SceneManager.LoadScene("Sumo");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
