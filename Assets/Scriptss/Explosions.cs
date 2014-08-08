using UnityEngine;
using System.Collections;

public class Explosions : MonoBehaviour {
	void Start (){
		Invoke ("Detonate", 3);
	}


	void Detonate (){
		/*Collider [] colliders = Physics.OverlapSphere (Vector3.zero, 10);
		foreach (Collider col in colliders) {
						if (col.rigidbody == null) continue;*/
		/*GameObject[] flyAround = GameObject.FindGameObjectsWithTag("StuffToExplode");
	
		foreach (GameObject flyAroundObject in flyAround) {
			flyAroundObject.rigidbody.AddExplosionForce(10, Vector3.zero, 10, 0, ForceMode.Impulse);		
			Debug.Log ("EXPLODED");
			*/

		Collider[] colliders = Physics.OverlapSphere (Vector3.zero, 10);
	foreach (Collider col in colliders) {
							Debug.Log ("PRE EXPLODED");
			if (col.rigidbody == null) {	continue;}
						 
								Debug.Log ("walao");
								col.rigidbody.AddExplosionForce (10, Vector3.zero, 10, 0, ForceMode.Impulse);
								Debug.Log ("EXPLODED");
						
				}
		Debug.Log ("NIGGERS");
		

				}
}
