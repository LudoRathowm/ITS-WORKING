using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AdvancedMovement))]

public class Backsliding : MonoBehaviour {
	private Vector3 _moveDirection;
	private Transform _myTransform;
	private float walkSpeed = 1000;
	public GameObject Clone;
	GameObject parenthood;
	public float speed = 600000.0f;
	public float jumpSpeed = 80000000.0f;

	// Use this for initialization
	 void Start () {
		GameObject parenthood = GameObject.Find ("Player1");
		_myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
	//	if (controller.isGrounded) {
	//		_moveDirection = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	//		_moveDirection = transform.TransformDirection(_moveDirection);
	//		_moveDirection *=speed;
	//	}
		
		if (Input.GetButtonUp ("Backslide")) { 
		//	var newPos = controller.transform.position.x - 50;
		//	controller.transform.position.x = Mathf.Lerp(controller.transform.position.x, newPos, .5f);
		//	_moveDirection.x = jumpSpeed;

			GameObject backslideclone = (GameObject)Instantiate(Resources.Load("BackslideClone"),transform.position,Quaternion.identity ); 

	
			Vector3 backslide = transform.TransformDirection(Vector3.back);
			controller.transform.Translate(backslide * (350)*Time.deltaTime, Space.World);


	//		float speed = 150000f;
	//	float curSpeed = speed * Input.GetAxis("Backslide");
	//		controller.SimpleMove(backslide *curSpeed* Time.deltaTime);
	//		controller.SimpleMove(backslide * curSpeed);


			
	}
	//	controller.Move (_moveDirection * Time.deltaTime);
	}
}
