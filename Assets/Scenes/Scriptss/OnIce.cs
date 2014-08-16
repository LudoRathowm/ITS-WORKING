

using UnityEngine;
using System.Collections;


public class OnIce : MonoBehaviour {
	
	
	public Transform target;
	public int iceRange;
	private Transform _myTransform;
	private bool frosty;
	GameObject player;
	
	void Awake() {
		_myTransform = transform;
		player = GameObject.FindGameObjectWithTag("Player");

	}
	
	void Start (){
		
		
		
		target = player.transform;
	}
	
	
	void Update () {
		//Debug.DrawLine(target.position, _myTransform.position, Color.magenta);
		//Look at the target
		
		
		if (Vector3.Distance (target.position, _myTransform.position) < iceRange) {
			
			player.GetComponent<PlayerInput> ().enabled = false;
			player.GetComponent<AdvancedMovement>().walkSpeed = 30;
			frosty = true;
			
		}
		else if (Vector3.Distance (target.position, _myTransform.position) > iceRange && frosty == true) {
			player.GetComponent<PlayerInput> ().enabled = true;
			player.GetComponent<AdvancedMovement>().walkSpeed = 3;
			player.SendMessage("MoveMeForward", AdvancedMovement.Forward.none);
			frosty = false;
		}
		
	}
	
}

