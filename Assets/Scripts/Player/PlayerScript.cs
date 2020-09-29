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


        Vector3 move = (transform.right * z + transform.forward * x);

        Controller.Move(move*speed*Time.deltaTime);
        
        /*if (x <= 0.99f)
        {
            transform.localRotation = Quaternion.Euler(0,90,0);
            
            
        }else if (x >= -0.99f && x<= 0.1f)
        {
            transform.localRotation = Quaternion.Euler(0,-90,0);
        }

        if (z <= 0.99f)
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
            
        }else if (z >= -0.99f && z <= 0.1f)
        {
            transform.localRotation = Quaternion.Euler(0,180,0);
        }*/

        
    }
    
    private void OnTriggerEnter(Collider other)
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
