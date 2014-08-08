using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GameObject player1 = GameObject.Find ("Player1");
		GameObject player2 = GameObject.Find ("Player2");
		GameObject player3 = GameObject.Find ("Player3");
		GameObject camera = GameObject.Find ("Main Camera");

		if(Input.GetButton("Player Switch2")){ 
		
				player1.GetComponent<PlayerInput>().enabled=false;
				player2.GetComponent<PlayerInput>().enabled=true;
				player3.GetComponent<PlayerInput>().enabled=false;
			camera.GetComponent<HackAndSlashCamera>().target=player2.transform;
	}
		if(Input.GetButton("Player Switch3")){ 
			
			player1.GetComponent<PlayerInput>().enabled=false;
			player2.GetComponent<PlayerInput>().enabled=false;
			player3.GetComponent<PlayerInput>().enabled=true;
			camera.GetComponent<HackAndSlashCamera>().target=player3.transform;
		}

		if(Input.GetButton("Player Switch1")){ 
			
			player1.GetComponent<PlayerInput>().enabled=true;
			player2.GetComponent<PlayerInput>().enabled=false;
			player3.GetComponent<PlayerInput>().enabled=false;
			camera.GetComponent<HackAndSlashCamera>().target= player1.transform;
		}

	//}

	

}
}