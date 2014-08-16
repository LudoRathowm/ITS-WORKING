using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SphereCollider))]
public class Bullethit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

		public void OnTriggerEnter(Collider other){
			//	Debug.Log ("ENTER");
			if (other.CompareTag ("EditorOnly")) {
				} else {
			Debug.Log ("HIT");
			Destroy(other.gameObject);
			Destroy(gameObject);		
		}
			
			
		}
		


	
}
