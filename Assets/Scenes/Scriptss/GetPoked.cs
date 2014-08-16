using UnityEngine;
using System.Collections;

public class GetPoked : MonoBehaviour {
	public float force;
 void OnMouseDown()
	{ Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, 100))
			rigidbody.AddForceAtPosition (new Vector3 (0, 0, force), hit.point,
			                              ForceMode.Impulse);

	}




}
