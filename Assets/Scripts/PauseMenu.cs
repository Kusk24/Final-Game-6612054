using UnityEngine;
using UnityEngine.SceneManagement;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    private CursorLockMode previousCursorLock;
    private bool previousCursorVisible;

    void Start()
    {
        if (pauseMenuUI) pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        
        // Debug which input system is active
        #if ENABLE_INPUT_SYSTEM
            Debug.Log("Using NEW Input System");
        #else
            Debug.Log("Using OLD Input System");
        #endif
    }

    void Update()
    {
        // Add constant debug to see if Update is even running
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("OLD Input System: P pressed!");
        }
        
        #if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null && Keyboard.current.pKey.wasPressedThisFrame)
        {
            Debug.Log("NEW Input System: P pressed!");
        }
        #endif

        // Toggle pause
        if (GetPauseInput())
        {
            Debug.Log("GetPauseInput returned TRUE");
            if (isPaused) Resume();
            else Pause();
        }
    }

    private bool GetPauseInput()
    {
        #if ENABLE_INPUT_SYSTEM
            if (Keyboard.current == null)
            {
                Debug.LogWarning("Keyboard.current is NULL! Falling back to old input.");
                return Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P);
            }
            return (Keyboard.current.escapeKey.wasPressedThisFrame) ||
                   (Keyboard.current.pKey.wasPressedThisFrame);
        #else
            return Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P);
        #endif
    }

    public void Resume()
    {
        Debug.Log("Resume called");
        if (pauseMenuUI) pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;  
        isPaused = false;
        
        // Restore previous cursor state
        Cursor.lockState = previousCursorLock;
        Cursor.visible = previousCursorVisible;
    }

    public void Pause()
    {
        Debug.Log("Pause called");
        
        // Save current cursor state
        previousCursorLock = Cursor.lockState;
        previousCursorVisible = Cursor.visible;
        
        // Unlock and show cursor for menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        if (pauseMenuUI) 
        {
            pauseMenuUI.SetActive(true);
            
            // Ensure Canvas uses unscaled time
            Canvas canvas = pauseMenuUI.GetComponent<Canvas>();
            if (canvas == null)
                canvas = pauseMenuUI.GetComponentInParent<Canvas>();
            
            if (canvas != null)
            {
                canvas.sortingOrder = 100;
                Debug.Log("Canvas found and set to top layer");
            }
            else
            {
                Debug.LogWarning("No Canvas component found!");
            }
        }
        
        Time.timeScale = 0f;  
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}