using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour 
{
    
}




public class Bullet: MonoBehaviour, IWeapon
{
	public void Shoot()
    {
        Vector3 bulletoffset = new Vector3(0, 0.5f, 0);
        Vector3 offset = transform.rotation * bulletoffset;
        GameObject bullet = Instantiate(Resources.Load("BulletPrefab", typeof(GameObject))) as GameObject;
        Instantiate(bullet, transform.position + offset, transform.rotation);

    } 
}

public class Missile: MonoBehaviour, IWeapon
{
	public void Shoot()
    {
        Vector3 missleoffset = new Vector3(0, 0.5f, 0);
        Vector3 offset = transform.rotation * missleoffset;
        GameObject bullet = Instantiate(Resources.Load("MissilePrefab", typeof(GameObject))) as GameObject;
        Instantiate(bullet, transform.position + offset, transform.rotation);


    }
}
