using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
        Instantiate(Bullet, shootPoint.position - new Vector3(0, 0.1f, 0), Quaternion.identity);
    }
}
