using UnityEngine;
using System.Collections;

public class TeamManager : MonoBehaviour
{
    public PlayerController pOwner;
    public GameObject[] gTeam;
    public Spawnpoint[] sSpawnPoints;
    private Spawnpoint[] sSafeSpawns;
    public int iDeaths;
    private bool bRobotSpawned;
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
        if (sOwner_ == pOwner.tag)
        {
            sSafeSpawns = new Spawnpoint[sSpawnPoints.Length];

            for (int i = 0; i < sSpawnPoints.Length; i++)
            {
                if (sSpawnPoints[i].bIsSafe)
                {
                    sSafeSpawns[i] = sSpawnPoints[i];
                }
            }

            int randNum = Random.Range(0, sSafeSpawns.Length);
            GameObject gRobot = Instantiate(gTeam[iDeaths], sSafeSpawns[randNum].transform.position, gTeam[iDeaths].transform.rotation) as GameObject;
            pOwner.TagRobot(gRobot);
            ++iDeaths;
        }
    }
}
