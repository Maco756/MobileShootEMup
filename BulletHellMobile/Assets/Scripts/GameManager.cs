using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //Enemy
    public GameObject asteroid;
    public Vector3 spawnValues;
	// Use this for initialization
	void Start ()
    {
        WaveSpawn(30);
	}
	

    void WaveSpawn(int count)
    {
      
        for (int i = 0; i < count; i++)
        {
            Vector3 spawn = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRot = Quaternion.identity;
            Instantiate(asteroid, spawn, spawnRot);
        }
        
    }
}
