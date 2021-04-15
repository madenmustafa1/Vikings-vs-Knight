using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    private Canvas canvas;
    bool pause;
    private void Awake()
    {

        canvas = GetComponent<Canvas>();
        canvas.gameObject.SetActive(false);
    }
    public void CanvasOnOff()
    {
        
        pause = !pause;
        if (pause)
        {
            canvas.gameObject.SetActive(true);
        }
        if (!pause)
        {
            canvas.gameObject.SetActive(false);
        }
    }
    public void Restart()
    {
        HealthBar.kontrol = true;
        HealthBar.can = 100;
        PlayerMove.kontrol = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
