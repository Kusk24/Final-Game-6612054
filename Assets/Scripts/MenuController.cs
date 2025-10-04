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
        Debug.Log("Exit called - only from button!");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
