using UnityEngine;
using System.Collections;

public class BodyScript : MonoBehaviour
{
    private Rigidbody rb;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Explode()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Rigidbody>().useGravity = true;
            child.GetComponent<Rigidbody>().isKinematic = false;
            child.GetComponent<Rigidbody>().AddExplosionForce(50.0f, child.transform.position, 30.0f);
            child.transform.rotation = Random.rotation;
        }
        rb.freezeRotation = false;
        transform.rotation = Random.rotation;
        transform.DetachChildren();
        rb.AddExplosionForce(300.0f, transform.position, 30.0f);
    }
}
