using UnityEngine;
using System.Collections;

public class ReadyColour : MonoBehaviour {
	bool delay;

	
	// Update is called once per frame
	void Update () {
		delay = gameObject.GetComponentInParent<Spearman> ().Piercedelay;
		if (delay == false) {
						renderer.material.color = Color.red;
				}
		if (delay == true) {
			renderer.material.color = Color.white;
	}
}
}