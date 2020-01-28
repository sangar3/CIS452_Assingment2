/*
     * (Santiago Garcia II)
     * (CameraFollow.cs)
     * (Assignment 2)
     * (This scripts )
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform MyTarget;

   
    void Update()
    {
        if(MyTarget!= null)
        {
            Vector3 targPos = MyTarget.position;
            targPos.z = transform.position.z;
            transform.position = targPos;
        }
    }
}
