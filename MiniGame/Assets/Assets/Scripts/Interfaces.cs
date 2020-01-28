using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Shoot();
}


public interface IFlame
{

    void ShowFlame();
    void DestroyFlame();
}

public interface PlayerDie
{
    void Die();
}