using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform Target;
    
    [SerializeField]
    private float distance = -10f;
    void Update()
    {
        var transformPositionx = transform.position;
        transformPositionx.x = Target.position.x-distance;

        var transformPositiony = transform.position;
        transformPositiony.y = Target.position.y+4;

        var transformPositionz = transform.position;
        transformPositionz.z = Target.position.z;
        
        transform.position = new Vector3(transformPositionx.x, transformPositiony.y, transformPositionz.z);

    }
}
