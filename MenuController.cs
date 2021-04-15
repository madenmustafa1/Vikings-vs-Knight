using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public bool clicked = false;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void InfoMenu()
    {
        clicked = !clicked; 

        if (clicked)
        {
            foreach (Transform item in this.transform)
            {
                item.gameObject.SetActive(true);
            }
        }else if (!clicked)
        {
            foreach (Transform item in this.transform)
            {
                item.gameObject.SetActive(false);
            }
        } 
    }
    public void MoodLink()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.moodGame.mood");
    }
    public void x96()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.MadenCompany.x96");
    }
}
