using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
  
    public float maxSpeed = 5f;
    public float rotationSpeed = 180f;
    private float shipBoundaryRaduis = 0.8f;
    public float fireDelay = 0.25f;
    private float cooldownTimer = 0;
   

    // Update is called once per frame
    void Update()
    {
        //ROTATES THE SHIP
        //grab our rotation quaternion
        Quaternion rot = transform.rotation;

        //grab the Z euler angle 
        float z = rot.eulerAngles.z;

        // chnage Z angle based on player input 
        z -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        //recreate the quaternion 
        rot = Quaternion.Euler(0, 0, z);

        //feed the quaternion into our rotation
        transform.rotation = rot;

        //MOVES THE SHIP UP AND DOWN
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);


        pos += rot * velocity;



        // RESTICTING PLAYER TO CAMERA BOUNDRIES

        //vertical 
        if (pos.y + shipBoundaryRaduis > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRaduis;
        }
        if (pos.y - shipBoundaryRaduis < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRaduis;
        }


        //calculate the orthographic width based on the players screen ratio 
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        //horziontal bounds 
        if (pos.x + shipBoundaryRaduis > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRaduis;
        }
        if (pos.x - shipBoundaryRaduis < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryRaduis;
        }
        //update playership position
        transform.position = pos;


        cooldownTimer -= Time.deltaTime;









        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
           
            cooldownTimer = fireDelay;
        }
    }
}
