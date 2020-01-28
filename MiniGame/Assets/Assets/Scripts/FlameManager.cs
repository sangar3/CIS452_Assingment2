using UnityEngine;
using System.Collections;

public class FlameManager : MonoBehaviour 
{
	
}

public class BlueFlame:MonoBehaviour,IFlame
{
			
	private GameObject flame;
	public void ShowFlame()
    {
	
		GameObject blueFlame = Instantiate(Resources.Load("Flame-blue",typeof(GameObject))) as GameObject;
		flame = blueFlame;
		blueFlame.transform.parent=transform;		
	}
	
	public void DestroyFlame(){
		Destroy(flame);
	}
}

public class RedFlame:MonoBehaviour,IFlame
{
	
	private GameObject flame;
	public void ShowFlame()
    {	
		GameObject redFlame = Instantiate(Resources.Load("Flame-red",typeof(GameObject))) as GameObject;
		flame = redFlame;
		redFlame.transform.parent=transform;		
	}
	
	public void DestroyFlame()
    {
		Destroy(flame);
	}
}