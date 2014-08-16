using UnityEngine;
using System.Collections;

public class Explosions : MonoBehaviour {
	void Start (){


		Invoke ("Detonate", 3);
	}


	void Detonate (){

			Collider[] colliders = Physics.OverlapSphere (this.transform.position, 10);
	foreach (Collider col in colliders) {

			if (col.rigidbody == null) {	continue;}
						 

			col.rigidbody.AddExplosionForce (10, this.transform.position, 10, 0, ForceMode.Impulse);
					

				}

		

				}
}
