using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
        if (KeepType.Instance.isMenu == 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void PlayParty()
    {
        Time.timeScale = 1.0f;
    } 
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void FigthButton()
    {
        KeepType.Instance.isMenu = 1;

        if (KeepType.Instance.Type == "null" || KeepType.Instance.Pokeplayer == "null")
        {
            Debug.Log("Choisi un Pokemon enemie et un allie");
        }
        else
        {

            SceneManager.LoadScene("battle");
        }
    }
    
    
}
