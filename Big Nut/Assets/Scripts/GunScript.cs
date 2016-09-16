using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{
    public string sOwner;

    public float fFireRate;
    private float fTimerForNext = 0;
    private bool bShot = true;

    public GameObject gBulletPattern;

    void Update()
    {
        if (bShot == true && fTimerForNext < fFireRate)
        {
            fTimerForNext += Time.deltaTime;
        }
    }

    public void Shoot()
    {

        if (fTimerForNext >= fFireRate)
        {
            GameObject bulletPattern = Instantiate(gBulletPattern, transform.position, transform.rotation) as GameObject;
            bulletPattern.gameObject.GetComponent<BulletScript>().sOwner = sOwner;
            bShot = true;
            fTimerForNext = 0;
        }
    }
}
