using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class EnablePauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject playercam;
    [SerializeField]
    private GameObject menucam;
    [SerializeField]
    private GameObject PanelPause ;
    
    
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Escape pressed");
            menucam.SetActive(true);
            playercam.SetActive(false);
            PanelPause.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
