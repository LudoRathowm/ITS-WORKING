using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AdvancedMovement))]

public class Backsliding : MonoBehaviour {
	private Vector3 _moveDirection;
	private Transform _myTransform;
	private float walkSpeed = 1000;
	public GameObject Clone;
	GameObject parenthood;

	// Use this for initialization
	 void Start () {
		GameObject parenthood = GameObject.Find ("Player1");
		_myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetButtonUp("Backslide")){ 


			GameObject backslideclone = (GameObject)Instantiate(Resources.Load("BackslideClone"),transform.position,Quaternion.identity ); 

			CharacterController controller = GetComponent<CharacterController>();
			Vector3 backslide = transform.TransformDirection(Vector3.back);
		//	transform.Translate (Vector3.back *Time.deltaTime);
			transform.Translate(backslide * (350)*Time.deltaTime, Space.World);

		/*	controller.SimpleMove(backslide * 50);
			float speed = 5000f;
		float curSpeed = speed * Input.GetAxis("Backslide");
			controller.SimpleMove(backslide * curSpeed);
*/


		
		
			
		}
	}
}
