using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Swordmaster : MonoBehaviour {
	public enum State
	{
		Idle,
		Initialize,
		Setup,
		SpawnSword
	}
	public GameObject target;
	public float dist;
	public float spawndist;
	public GameObject [] SwordPrefabs; //all the mob prefabs
	public GameObject[] spawnPoints; //all the spawnpoints in the scene
	public State state; //this is our local variable that holds our current state
	
	void Awake(){
		//target = GameObject.FindGameObjectWithTag ("Player");
		//dist = Vector3.Distance (target.transform.position, transform.position);
		//if (dist > spawndist) {
						state = Swordmaster.State.Initialize; // this for initialization
		//		}
	}
	IEnumerator Start () {
		while (true) {
			switch(state){
			case State.Initialize:
				Inizialize();
				break;
			case State.Setup:
				Setup ();
				break;
			case State.SpawnSword:
				SpawnSword();
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
		
			//Debug.Log ("***INIZIALIZE FUNCTION NIGGA***");
		state = Swordmaster.State.Setup;
	}
	private void  Setup(){
		
		
			//Debug.Log ("***SETUP FUNCTION NIGGA***");
		state = Swordmaster.State.SpawnSword;
	}
	private void SpawnSword(){
			//Debug.Log ("***SPAWN FUNCTION NIGGA***");
		state = Swordmaster.State.Idle;
		
		GameObject[] gos = AvailableSpawnPoints ();
		for (int cnt = 0; cnt<gos.Length; cnt++) {
			GameObject go = Instantiate(SwordPrefabs[Random.Range(0,SwordPrefabs.Length)],
			                            gos [cnt].transform.position,
			                          Quaternion.Euler (0, 180,0)) as GameObject;
			                            go.transform.parent = gos[cnt].transform;
		}
	}
	
	//check if there's at least one mob prefab to spawn
	private bool CheckForMobPrefabs(){
		if (SwordPrefabs.Length > 0)
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
