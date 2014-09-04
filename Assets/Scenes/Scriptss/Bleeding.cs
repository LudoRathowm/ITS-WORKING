using UnityEngine;
using System.Collections;

public class Bleeding : MonoBehaviour {
	public float bleedtime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (particleSystem.enableEmission == true) {
			Debug.Log ("IM BLEEDING");
			bleedtime += Time.deltaTime;
			if (bleedtime > 3){
				Debug.Log ("RIP CAPSULE 2014 KILLED BY BLOOD LOSS");
				Destroy(gameObject);
			}
		}
	}
}
