using UnityEngine;
using System.Collections;

public class HackAndSlashCamera : MonoBehaviour {
	public Transform target;
	public float walkDistance;
	public float runDistance;
	public float height = 20f;
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;
	public float currentHeight = 24;

	private Transform _myTransform;
	private float _x;
	private float _y;
	private bool _camButtonDown = false;
	private bool _rotateCameraKeyPressed = false;


	void Awake (){
		_myTransform = transform;
	}
	// Use this for initialization
	void Start () {
		if (target == null)
						Debug.LogWarning ("NO TARGET");
				else {

			//CameraSetUp ();
		}
	
	}

	public float transitionDuration = 2.5f;
	IEnumerator Transition()
	{
		float t = 0.0f;
		Vector3 startingPos = transform.position;
		while (t < 1.0f)
		{
			t += Time.deltaTime * (Time.timeScale/transitionDuration);
			
			transform.position = Vector3.Lerp(transform.position, target.position, t);
			yield return 0;
	}	}

	
	void Update (){
		

		
		
		/*
		if (Input.GetButtonDown ("Rotate Camera Button")) { //Import manager to change this to the user selected
						_camButtonDown = true;
				}
				if (Input.GetButtonUp ("Rotate Camera Button")) {
						_x = 0;
						_y = 0;

						_camButtonDown = false;
				}

		if (Input.GetButtonDown ("Rotate Camera Horizontal Buttons") || Input.GetButtonDown ("Rotate Camera Vertical Buttons"))
		    _rotateCameraKeyPressed = true;
		 if (Input.GetButtonUp ("Rotate Camera Horizontal Buttons") || Input.GetButtonUp ("Rotate Camera Vertical Buttons")) {
						_x = 0;
						_y = 0;
						_rotateCameraKeyPressed = false;
				}*/
		}
	void LateUpdate(){
	if (target == null) {/*
			if(_rotateCameraKeyPressed) {
				_x += Input.GetAxis("Rotate Camera Horizontal Buttons") * xSpeed * 0.02f; // its a float you need to add f
					_y -= Input.GetAxis("Rotate Camera Vertical Buttons") * ySpeed * 0.02f; // ^
				
				//		y = ClampAngle(y, yMinLimit, yMaxLimit);
				RotateCamera();

			}
			//mouse button: 0 = right 1 = left
			if (_camButtonDown) { //Import manager to change this to the user selected
				
				
				_x += Input.GetAxis("Mouse X") * xSpeed * 0.02f; // its a float you need to add f
				_y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f; // ^
				
				//		y = ClampAngle(y, yMinLimit, yMaxLimit);
				RotateCamera();

			*/}
			else{
	//		_myTransform.position = new Vector3 (target.position.x, target.position.y + height, target.position.z - walkDistance);
	//		_myTransform.LookAt (target.position);
			/*	if (Input.GetAxisRaw("Camera Zoom") < 0){
					height += 3;
				}
				if (Input.GetAxisRaw("Camera Zoom") > 0){
					height -= 3;
				}
				if (height < 4){
					height = 4;
				}
				if (height > 29){
					height = 29;
				}*/
				// Calculate the current rotation angles
				float wantedRotationAngle = target.eulerAngles.y;
				float wantedHeight = target.position.y + height;
				
				float currentRotationAngle = _myTransform.eulerAngles.y;
	
			
				// Damp the rotation around the y-axis
				currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
				
				// Damp the height
				currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
				
				// Convert the angle into a rotation
				Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
				
				// Set the position of the camera on the x-z plane to:
				// distance meters behind the target

			//gotoposition = new Vector3 (target.position.x, target.position.y + height, target.position.z - walkDistance);
			//transform.position = Vector3.Lerp (transform.position, gotoposition.position,300000 );
		
			_myTransform.position = new Vector3(_myTransform.position.x, currentHeight, _myTransform.position.z);
				
			Vector3 position1 = target.position;
				Vector3 position2 = _myTransform.position;
				transform.position = Vector3.Lerp (position2, position1, 8*Time.deltaTime);
				//_myTransform.position = Vector3.Lerp (_myTransform.position, target.position, Time.deltaTime);
				//_myTransform.position -= currentRotation * Vector3.forward * walkDistance;
				
				// Set the height of the camera

				
				// Always look at the target
				//_myTransform.LookAt (target);


			

			
			
		}
			
				}
	/*private void RotateCamera(){
		Quaternion rotation = Quaternion.Euler(_y,_x,0);
		Vector3 position = rotation * new Vector3(0.0f, 0.0f, -walkDistance) + target.position;
		
		_myTransform.rotation = rotation;
		_myTransform.position = position;
	}
	*/
	public void CameraSetUp(){

		Vector3 gotoposition;
		gotoposition = new Vector3 (target.position.x, target.position.y + height, target.position.z - walkDistance);
		transform.position = Vector3.Lerp (transform.position, target.position,300000 );
		transform.LookAt (target.position);
	}
}
