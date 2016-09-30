using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public PlayerController PlayerOne;
    public PlayerController PlayerTwo;

    public GameObject P1robs;
    public GameObject P2robs;

    public GameObject P1hp;
    public GameObject P2hp;


    // Use this for initialization
    void Start ()
    {


	
	}
	
	// Update is called once per frame
	void Update ()
    {
        P1hp.GetComponent<Text>().text = PlayerOne.bBody.fLifetime.ToString();
        P2hp.GetComponent<Text>().text = PlayerTwo.bBody.fLifetime.ToString();
    }

    void UpdateBotsLeft()
    {


    }
}
