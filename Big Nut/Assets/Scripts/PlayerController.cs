using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float KeyAxisH;
    private float KeyAxisV;

    public string Horizontal = "Horizontal_P1";
    public string Vertical = "Vertical_P1";
    public string Shoot = "Shoot_P1";
    public string Stab = "Stab_P1";
    public string Jump = "Jump_P1";
    public string GodMode = "God_P1";

    private bool bDisabled = false;

    public int fLifetime;


    public BodyScript bBody;
    public GunScript gGun;
    public LegScript lLeg;
    public SwordScript sSword;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        InvokeRepeating("updateLifeTime", 0, 1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!bDisabled)
        {
            KeyAxisH = Input.GetAxis(Horizontal);
            KeyAxisV = Input.GetAxis(Vertical);

            if (KeyAxisH != 0)
            {
                rb.AddForce((transform.forward * lLeg.fMoveSpeed) * KeyAxisH);
            }

            if (Input.GetButtonDown(Jump))
            {
                inputManager(1);
            }
            if (Input.GetButtonDown(Shoot))
            {
                inputManager(2);
            }
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                inputManager(3);
            }
        }
    }

    private void inputManager(int iInput)
    {
        switch (iInput)
        {
            case 1:
                {
                    if(lLeg.bGrounded)
                    {
                        rb.AddForce(transform.up * lLeg.fJumpSpeed);
                    }
                    else if(!lLeg.bGrounded && lLeg.iJumps > 0)
                    {
                        StartCoroutine(Dash(lLeg.fDashTime));
                        rb.AddForce(new Vector3(KeyAxisH, KeyAxisV, 0) * lLeg.fJumpSpeed);
                        --lLeg.iJumps;
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
                    bBody.Explode();
                    bDisabled = true;
                    break;
                }  
        }
    }

    void updateLifeTime()
    {
        print(fLifetime);
        if (fLifetime > 0)
        {
            --fLifetime;
        }
        else if(fLifetime <= 0)
        {
            bBody.Explode();
            bDisabled = true;
            CancelInvoke();
        }
    }

    IEnumerator Dash(float dashTime)
    {
        rb.useGravity = false;
        yield return new WaitForSeconds(dashTime);
        rb.useGravity = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            updateLifeTime();
        }
    }
}
