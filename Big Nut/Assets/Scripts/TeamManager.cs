using UnityEngine;
using System.Collections;

public class TeamManager : MonoBehaviour
{
    public PlayerController pOwner;
    public GameObject[] gTeam;
    public Spawnpoint[] sSpawnPoints;
    private int iDeaths;
	// Use this for initialization

    void OnEnable()
    {
        BodyScript.Die += Spawn;
    }

    void OnDisable()
    {
        BodyScript.Die -= Spawn;
    }
	void Start ()
    {
        Spawn(pOwner.tag);
	}
	
    private void Spawn(string sOwner_)
    {
        int randNum = Random.Range(0, sSpawnPoints.Length);

        for (int i = 0; i < sSpawnPoints.Length; i++)
        {
            if (sSpawnPoints[randNum].bIsSafe == true && sOwner_ == pOwner.tag)
            {
                GameObject gRobot = Instantiate(gTeam[iDeaths], sSpawnPoints[randNum].transform.position, gTeam[iDeaths].transform.rotation) as GameObject;
                pOwner.TagRobot(gRobot);
                ++iDeaths;
                break;
            }

            else
            {
                randNum = Random.Range(0, sSpawnPoints.Length);
            }
            print(randNum);
        }
    }
}
