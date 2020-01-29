/*
     * (Santiago Garcia II)
     * (PlayerShipController.cs)
     * (Assignment 2)
     * (This scripts uses design pattern to give the player input and switch weapon types)
*/

using UnityEngine;
using System.Collections;

public enum WeaponType
{
	Missile,
	Bullet
}

public enum Flame
{
	Blue,
	Red
}

public class PlayerShipController : MonoBehaviour 
{
    //private float flameplacement= -1.15f;
    
    public WeaponType weaponType; 
	public Flame flameColor;
    public float maxSpeed = 5f;
    public float rotationSpeed = 180f;
    private float shipBoundaryRaduis = 0.8f;
    public float fireDelay = 0.25f;
    private float cooldownTimer = 0;
    private IWeapon iWeapon;
	private IFlame iFlame;	
		
	
	private void HandleWeaponType()
    {
	 
		//To prevent Unity from creating multiple copies of the same component in inspector at runtime when spawning the missle 
		Component c = gameObject.GetComponent<IWeapon>() as Component;
       
		if(c!=null)
        {
				Destroy(c);
		}
	
		
		switch(weaponType)
        {
		
			case WeaponType.Missile:
				iWeapon = gameObject.AddComponent<Missile> ();
               
                break;
				
			case WeaponType.Bullet:
				iWeapon = gameObject.AddComponent<Bullet> ();
               
                break;
				
			default:
				iWeapon = gameObject.AddComponent<Bullet> ();
                
                break;

		}
		
	}
	
	public void HandleFlameColor()
    {
	
		Component c = gameObject.GetComponent<IFlame>() as Component;
		
		if(c!=null){
			Destroy(c);
			iFlame.DestroyFlame(); // so that number of flame objects remains one
		}
		
		#region Strategy
		switch(flameColor){
			
		case Flame.Blue:
			iFlame = gameObject.AddComponent<BlueFlame> ();
			break;
			
		case Flame.Red:
			iFlame = gameObject.AddComponent<RedFlame> ();
			break;
			
		default:
			iFlame = gameObject.AddComponent<BlueFlame> ();
			break;
		}
		#endregion
		
	}
	
	public void Fire()
    {
       
        iWeapon.Shoot();// calling Iweapon interface
        
	}
	
	void Start(){
		
		HandleWeaponType(); //to check the value of weaponType in the inspector initially
		HandleFlameColor();	
		iFlame.ShowFlame();		
	}
		
	void Update () 
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
        if(pos.y + shipBoundaryRaduis > Camera.main.orthographicSize)
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
        if (pos.x+shipBoundaryRaduis > widthOrtho)
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









        if (Input.GetButton("Fire1") && cooldownTimer <=0)
        {
			Fire();
            cooldownTimer = fireDelay;
		}
		
		//to check the value of weaponType in the inspector while in play mode
		if(Input.GetKeyDown(KeyCode.C))
        {
			HandleWeaponType();			
		}
        //to check the value of the flame  in the inspector while in play mode
        if (Input.GetKeyDown(KeyCode.F))
        {			
			HandleFlameColor();							
			iFlame.ShowFlame();
		}
	}
}
