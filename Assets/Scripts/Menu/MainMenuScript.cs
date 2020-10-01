using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    private Transform playerpos;

    [SerializeField] private GameObject playercam;
    [SerializeField] private GameObject menucam;
    [SerializeField] private GameObject player;
    void Start()
    {
        Time.timeScale = 0f;
        if (KeepType.Instance.isMenu == 0)
        {
            player.SetActive(true);
            menucam.SetActive(false);
            playercam.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 1.0f;
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
