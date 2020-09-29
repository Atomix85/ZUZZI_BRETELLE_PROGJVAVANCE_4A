using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private CharacterController Controller;
    [SerializeField]
    private float speed = 12f;
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right*z+transform.forward *x;

        Controller.Move(move*speed*Time.deltaTime);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grass"))
        {
            Debug.Log("Grass Col");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Bridge"))
        {
            Debug.Log("Col Bridge");
        }
    }
}
