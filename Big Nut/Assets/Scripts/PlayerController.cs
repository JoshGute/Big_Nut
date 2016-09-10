using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private float KeyAxisH;
    private float KeyAxisV;

    public string Horizontal = "Horizontal_P1";
    public string Vertical = "Vertical_P1";
    public string Shoot = "Shoot_P1";
    public string Stab = "Stab_P1";
    public string Jump = "Jump_P1";
    public string GodMode = "God_P1";

    public bool bDisabled = false;

    public BodyScript bBody;
    public GunScript gGun;
    public LegScript lLeg;
    public SwordScript sSword;
	
	// Update is called once per frame
	void Update ()
    {
        if (!bDisabled)
        {
            KeyAxisH = Input.GetAxis(Horizontal);
            KeyAxisV = Input.GetAxis(Vertical);

            if (KeyAxisH != 0)
            {
               bBody.rb.AddForce((bBody.transform.forward * bBody.fMoveSpeed) * KeyAxisH);
            }

            if (Input.GetButtonDown(Jump))
            {
                inputManager(1);
            }
            if (Input.GetButtonDown(Shoot))
            {
                inputManager(2);
            }
            if(Input.GetButtonDown(Stab))
            {
                inputManager(3);
            }
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                inputManager(4);
            }
        }
    }

    private void inputManager(int iInput)
    {
        switch (iInput)
        {
            case 1:
                {
                    if(bBody.bGrounded)
                    {
                        bBody.rb.AddForce(transform.up * bBody.fJumpSpeed);
                    }
                    else if(!bBody.bGrounded && bBody.iJumps > 0)
                    {
                        StartCoroutine(Dash(bBody.fDashTime));
                        bBody.rb.AddForce(new Vector3(KeyAxisH, KeyAxisV, 0) * bBody.fJumpSpeed);
                        --bBody.iJumps;
                    }
                    break;
                }
            case 2:
                {
                    gGun.Shoot();
                    break;
                }
            case 3:
                {
                    sSword.Stab();
                    break;
                }
            case 4:
                {
                    bBody.Explode();
                    bDisabled = true;
                    break;
                }  
        }
    }

    IEnumerator Dash(float dashTime)
    {
        bBody.rb.useGravity = false;
        yield return new WaitForSeconds(dashTime);
        bBody.rb.useGravity = true;
    }
}
