using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour {
	GameObject player1;
	GameObject player2;
	GameObject player3;
	bool initialized = false;
	// Use this for initialization
	void Start () {
		GameObject player1 = GameObject.Find ("Player1");
		GameObject player2 = GameObject.Find ("Player2");
		GameObject player3 = GameObject.Find ("Player3");
		GameObject camera = GameObject.Find ("Main Camera");
		player3.GetComponent<LookAtMouse> ().enabled = false;
		player2.GetComponent<LookAtMouse> ().enabled = false;
		player1.GetComponent<LookAtMouse> ().enabled = false;
		player1.GetComponent<Backsliding> ().enabled = false;
		player3.GetComponentInChildren<Bullet>().enabled=false;
		player1.GetComponentInChildren<Bullet>().enabled=false;
		player2.GetComponentInChildren<Bullet>().enabled=false;
		player1.GetComponent<PlayerInput>().enabled=false;
		player2.GetComponent<PlayerInput>().enabled=false;
		player3.GetComponent<PlayerInput>().enabled=false;
		player1.GetComponent<Bangbang> ().enabled = false;
		player2.GetComponent<Bangbang> ().enabled = false;
		player3.GetComponent<Bangbang> ().enabled = false;
		initialized = true;

		camera.GetComponent<HackAndSlashCamera>().target=player1.transform;
	}
	
	// Update is called once per frame
	void Update () {

						GameObject player1 = GameObject.Find ("Player1");
						GameObject player2 = GameObject.Find ("Player2");
						GameObject player3 = GameObject.Find ("Player3");
						GameObject camera = GameObject.Find ("Main Camera");
			

		if(Input.GetButton("Player Switch2")){ 
			player1.GetComponent<HealerAI>().enabled = true;
			player1.GetComponent<PlayerHealth>().active = false;
			player2.GetComponent<PlayerHealth>().active = true;
			player3.GetComponent<PlayerHealth>().active = false;
			player3.GetComponent<LookAtMouse> ().enabled = false;
			player2.GetComponent<LookAtMouse> ().enabled = true;
			player1.GetComponent<LookAtMouse> ().enabled = false;
			player1.GetComponent<Bangbang> ().enabled = false;
			player3.GetComponent<Bangbang> ().enabled = false;
			player2.GetComponent<Bangbang> ().enabled = true;
			player1.GetComponentInChildren<Bullet>().enabled=false;
			player2.GetComponentInChildren<Bullet>().enabled=true;
			player3.GetComponentInChildren<Bullet>().enabled=false;
				player1.GetComponent<PlayerInput>().enabled=false;
				player2.GetComponent<PlayerInput>().enabled=true;
				player3.GetComponent<PlayerInput>().enabled=false;
			camera.GetComponent<HackAndSlashCamera>().target=player2.transform;
			player1.GetComponent<Backsliding> ().enabled = false;
	}
		if(Input.GetButton("Player Switch3")){ 
			player1.GetComponent<HealerAI>().enabled = true;
			player2.GetComponent<PlayerHealth>().active = false;
			player1.GetComponent<PlayerHealth>().active = false;
			player3.GetComponent<PlayerHealth>().active = true;
			player3.GetComponent<LookAtMouse> ().enabled = true;
			player2.GetComponent<LookAtMouse> ().enabled = false;
			player1.GetComponent<LookAtMouse> ().enabled = false;
			player1.GetComponent<Backsliding> ().enabled = false;
			player1.GetComponent<Bangbang> ().enabled = false;
			player2.GetComponent<Bangbang> ().enabled = false;
			player3.GetComponent<Bangbang> ().enabled = true;
			player1.GetComponentInChildren<Bullet>().enabled=false;
			player2.GetComponentInChildren<Bullet>().enabled=false;
			player3.GetComponentInChildren<Bullet>().enabled=true;
			player1.GetComponent<PlayerInput>().enabled=false;
			player2.GetComponent<PlayerInput>().enabled=false;
			player3.GetComponent<PlayerInput>().enabled=true;
			camera.GetComponent<HackAndSlashCamera>().target=player3.transform;
		}

		if(Input.GetButton("Player Switch1")){ 
			player1.GetComponent<HealerAI>().enabled = false;
			player3.GetComponent<PlayerHealth>().active = false;
			player1.GetComponent<PlayerHealth>().active = true;
			player2.GetComponent<PlayerHealth>().active = false;
			player3.GetComponent<LookAtMouse> ().enabled = false;
			player2.GetComponent<LookAtMouse> ().enabled = false;
			player1.GetComponent<LookAtMouse> ().enabled = true;

			player1.GetComponent<Bangbang> ().enabled = true;
			player2.GetComponent<Bangbang> ().enabled = false;
			player3.GetComponent<Bangbang> ().enabled = false;
			player1.GetComponentInChildren<Bullet>().enabled=true;
			player2.GetComponentInChildren<Bullet>().enabled=false;
			player3.GetComponentInChildren<Bullet>().enabled=false;
			player1.GetComponent<PlayerInput>().enabled=true;
			player2.GetComponent<PlayerInput>().enabled=false;
			player3.GetComponent<PlayerInput>().enabled=false;
			player1.GetComponent<Backsliding> ().enabled = true;
			camera.GetComponent<HackAndSlashCamera>().target= player1.transform;
		
		}

	//}

	

}
}