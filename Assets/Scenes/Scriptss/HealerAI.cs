using UnityEngine;
using System.Collections;

public class HealerAI : MonoBehaviour {
	 float player2hp;
	float player3hp;
	GameObject player2;
	GameObject player3;
	public Transform target;
	float rotationSpeed = 33.0f;
	public bool ActiveHealer;
	public float direction;

	// Use this for initialization
	void Start () {
		GameObject player2 = GameObject.Find ("Player2");
		GameObject player3 = GameObject.Find ("Player3");
		float player2hp = player2.GetComponent<PlayerHealth> ().curHealth;
		float player3hp = player2.GetComponent<PlayerHealth> ().curHealth;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player2 = GameObject.Find ("Player2");
		GameObject player3 = GameObject.Find ("Player3");
	    player2hp = player2.GetComponent<PlayerHealth> ().curHealth;
		player3hp = player3.GetComponent<PlayerHealth> ().curHealth;
		if (player2hp < 100 && player2hp < player3hp) {
						target = player2.transform;
						transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.position - transform.position), rotationSpeed * Time.deltaTime);
			Vector3 dir = (target.position - transform.position).normalized;
			direction = Vector3.Dot (dir, transform.right);
			float dist = Vector3.Distance (target.position, transform.position);
			if (dist > 6) {
				GetComponent<AdvancedMovement>().enabled = true;
				SendMessage ("MoveMeForward", AdvancedMovement.Forward.forward);
			}
			if (dist < 6) {SendMessage ("MoveMeForward", AdvancedMovement.Forward.none);
				Debug.Log ("STOP");
				GetComponent<AdvancedMovement>().enabled = false;
			}					
		}
		if (player3hp < 100 && player2hp > player3hp) {
			target = player3.transform;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.position - transform.position), rotationSpeed * Time.deltaTime);
			Vector3 dir = (target.position - transform.position).normalized;
			direction = Vector3.Dot (dir, transform.right);
			float dist = Vector3.Distance (target.position, transform.position);
			if (dist > 6) {
				GetComponent<AdvancedMovement>().enabled = true;
				SendMessage ("MoveMeForward", AdvancedMovement.Forward.forward);
			}
			if (dist < 6) {SendMessage ("MoveMeForward", AdvancedMovement.Forward.none);
				Debug.Log ("STOP");
				GetComponent<AdvancedMovement>().enabled = false;
			}
		}
		if (player2hp == 100 && player3hp == 100)
						target = player3.transform;
	/*	Vector3 dir = (target.position - transform.position).normalized;
		 direction = Vector3.Dot (dir, transform.right);
		float dist = Vector3.Distance (target.position, transform.position);
	*/
		if (player2hp == 100 && player3hp == 100) {
			GetComponentInChildren<BulletHealAI>().enabled = false;
		}
		if (player2hp < 100 || player3hp < 100) {
			GetComponentInChildren<BulletHealAI>().enabled = true;
		}




	}
}


