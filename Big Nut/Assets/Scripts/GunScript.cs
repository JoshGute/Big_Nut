using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{
    public float fFireRate;
    public GameObject gBulletPattern;

    public void Shoot()
    {
        float fNextShot = 0.0f;
        if (Time.time > fNextShot)
        {
            fNextShot = Time.time + fFireRate;
            Instantiate(gBulletPattern, transform.position, transform.rotation);
        }
    }
}
