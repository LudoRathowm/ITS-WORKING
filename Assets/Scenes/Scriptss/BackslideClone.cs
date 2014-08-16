using UnityEngine;
using System.Collections;

public class BackslideClone : MonoBehaviour {
	public float alivetimer = 2;

	// Use this for initialization
	void Start () {
		GameObject backslider = GameObject.Find ("Player1");
		transform.rotation = backslider.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (alivetimer > 0)
			alivetimer -= Time.deltaTime;
		
		if (alivetimer < 0)
			alivetimer = 0;
		
		
		if (alivetimer == 0) {
			Destroy(gameObject);
			
		}
	}
}
