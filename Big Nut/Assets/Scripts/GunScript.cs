using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{
    public string sOwner;

    public float fFireRate;
    public GameObject gBulletPattern;

    public void Shoot()
    {
        float fNextShot = 0.0f;
        if (Time.time > fNextShot)
        {

            fNextShot = Time.time + fFireRate;
            GameObject bulletPattern = Instantiate(gBulletPattern, transform.position, transform.rotation) as GameObject;
            bulletPattern.gameObject.GetComponent<BulletScript>().sOwner = sOwner;
        }
    }
}
