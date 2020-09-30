using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    private Transform playerpos;
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
        var transformPositionx = playerpos.transform.position;
        transformPositionx.x = SavePosition.Instance.pos.x;
        
        var transformPositiony = playerpos.transform.position;
        transformPositiony.y = SavePosition.Instance.pos.y;
        
        var transformPositionz = playerpos.transform.position;
        transformPositionz.z = SavePosition.Instance.pos.z;
        Time.timeScale = 1.0f;
    } 
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void FigthButton()
    {
        KeepType.Instance.isMenu = 1;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("battle");
    }
    
    
}
