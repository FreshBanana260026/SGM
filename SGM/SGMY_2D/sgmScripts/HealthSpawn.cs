using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour {

    [SerializeField]
    private Vector3 position1;
    [SerializeField]
    private Vector3 position2;
    [SerializeField]
    private Vector3 position3;
    [SerializeField]
    private GameObject healthCross;

    private Vector3[] positions;
    private float timeForSpawn;
    private float time;

    void Start () {
        timeForSpawn = 30;
        positions = new Vector3[] { position1, position2, position3 };
	}
	
	void Update () {
		if(time >= timeForSpawn)
        {
            SpawnHealthCross();
            timeForSpawn += 40;
        }
        time += Time.deltaTime;
	}

    private void SpawnHealthCross()
    {
        Instantiate(healthCross, positions[Random.Range(0,3)], Quaternion.identity);
    }
}
