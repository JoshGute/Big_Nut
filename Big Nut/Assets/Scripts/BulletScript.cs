using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    public float fSpeed = 10.0f;
    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.AddForce(transform.forward * fSpeed);

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
}
