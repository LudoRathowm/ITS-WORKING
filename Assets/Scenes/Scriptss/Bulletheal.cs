using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SphereCollider))]
public class Bulletheal : MonoBehaviour {
	Collider other;
	// Use this for initialization
	void Start () {
		
	}
	
	
	public void OnTriggerEnter(Collider other){
		GameObject target = other.gameObject;
		if (!other.gameObject.GetComponent<SphereCollider> ().isTrigger) {
			if (target.particleSystem) {
				target.particleSystem.enableEmission = true;
			}
			
			
			if (other.CompareTag ("EditorOnly")) {
			} else {
				
				if (other.gameObject.GetComponent<PlayerHealth> () != null) {
					other.gameObject.GetComponent<PlayerHealth> ().curHealth += 10;
				}
				if (other.gameObject.GetComponent<EnemyHealth> () != null) {
					other.gameObject.GetComponent<EnemyHealth> ().curHealth += 10;
				}
				Debug.Log ("other is " + other);
				Destroy (gameObject);
				//Destroy(other.gameObject);
			}
		}
	}
	
}





