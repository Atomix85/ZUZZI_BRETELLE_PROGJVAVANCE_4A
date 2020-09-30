using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private CharacterController Controller;
    [SerializeField]
    private float speed = 12f;

    [SerializeField] private Scene testscene;

    private void Start()
    {
        transform.position = SavePosition.Instance.pos;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = (transform.right * z + transform.forward * x);

        Controller.Move(move*speed*Time.deltaTime);
        
        

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grass"))
        {
            
            var truc = Random.Range(0, 11);
            Debug.Log(truc);
            if ( truc == 10)
            {
                Savepos();
                TypeEnemy("Grass");
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Bridge"))
        {
            var truc = Random.Range(0, 11);
            Debug.Log(truc);
            if (truc == 10)
            {
                Savepos();
                Debug.Log("Combat herbe");
            }
        }
    }

    public void Savepos()
    {
        SavePosition.Instance.pos = transform.position;
    }

    public void TypeEnemy(string Type)
    {
        KeepType.Instance.Type = Type;
        KeepType.Instance.isMenu = 0;
        SceneManager.LoadScene("battle");
    }
}
