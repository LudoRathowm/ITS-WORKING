using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobGenerator : MonoBehaviour {
	public enum State
		{
		Idle,
		Initialize,
		Setup,
		SpawnMob
		}
	public GameObject [] mobPrefabs; //all the mob prefabs
	public GameObject[] spawnPoints; //all the spawnpoints in the scene
	public State state; //this is our local variable that holds our current state

	void Awake(){
		state = MobGenerator.State.Initialize;

	}



	// Use this for initialization
	IEnumerator Start () {
		while (true) {
			switch(state){
			case State.Initialize:
				Inizialize();
				break;
			case State.Setup:
				Setup ();
				break;
			case State.SpawnMob:
				SpawnMob();
				break;
				}
			yield return 0;
		}
	}
	private void  Inizialize(){
		if (!CheckForMobPrefabs ())
						return;
		if (!CheckForSpawnPoints ())
						return;

	//	Debug.Log ("***INIZIALIZE FUNCTION NIGGA***");
			state = MobGenerator.State.Setup;
	}
	private void  Setup(){


	//	Debug.Log ("***SETUP FUNCTION NIGGA***");
			state = MobGenerator.State.SpawnMob;
	}
	private void SpawnMob(){
	//	Debug.Log ("***SPAWN FUNCTION NIGGA***");
			state = MobGenerator.State.Idle;

		GameObject[] gos = AvailableSpawnPoints ();
		for (int cnt = 0; cnt<gos.Length; cnt++) {
			GameObject go = Instantiate(mobPrefabs[Random.Range(0,mobPrefabs.Length)],
			                            gos [cnt].transform.position,
			                            Quaternion.Euler (0, 180,0)) as GameObject;
			go.transform.parent = gos[cnt].transform;
		}
	}

	//check if there's at least one mob prefab to spawn
	private bool CheckForMobPrefabs(){
		if (mobPrefabs.Length > 0)
						return true;
				else
						return false;
	}
	//check if there's at least one spawn point
	private bool CheckForSpawnPoints(){
		if (spawnPoints.Length > 0)
						return true;
				else
						return false;
			}
	//creates a list of spawnpoints that don't have mob childed to it
	private GameObject[] AvailableSpawnPoints(){
		List<GameObject> gos = new List<GameObject> ();
		for (int cnt =0;cnt<spawnPoints.Length ; cnt++){
			if(spawnPoints[cnt].transform.childCount == 0) {
				//Debug.Log ("*** THERE ARE SPAWN POINTS***");
				gos.Add(spawnPoints[cnt]);
			}
		}
		return gos.ToArray();
	}

}
