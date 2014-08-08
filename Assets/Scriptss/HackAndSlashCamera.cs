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
			CameraSetUp ();
		}
	
	}

	void Update (){
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
				}
		}
	void LateUpdate(){
		if (target != null) {
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

			}
			else{
	//		_myTransform.position = new Vector3 (target.position.x, target.position.y + height, target.position.z - walkDistance);
	//		_myTransform.LookAt (target.position);

	
				// Calculate the current rotation angles
				float wantedRotationAngle = target.eulerAngles.y;
				float wantedHeight = target.position.y + height;
				
				float currentRotationAngle = _myTransform.eulerAngles.y;
				float currentHeight = _myTransform.position.y;
				
				// Damp the rotation around the y-axis
				currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
				
				// Damp the height
				currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
				
				// Convert the angle into a rotation
				Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
				
				// Set the position of the camera on the x-z plane to:
				// distance meters behind the target
				_myTransform.position = target.position;
				_myTransform.position -= currentRotation * Vector3.forward * walkDistance;
				
				// Set the height of the camera
				_myTransform.position = new Vector3(_myTransform.position.x, currentHeight, _myTransform.position.z);
				
				// Always look at the target
				_myTransform.LookAt (target);


			
			}
			
			
		}
			
				}
	private void RotateCamera(){
		Quaternion rotation = Quaternion.Euler(_y,_x,0);
		Vector3 position = rotation * new Vector3(0.0f, 0.0f, -walkDistance) + target.position;
		
		_myTransform.rotation = rotation;
		_myTransform.position = position;
	}
	
	public void CameraSetUp(){
	
		transform.position = new Vector3 (target.position.x, target.position.y + height, target.position.z - walkDistance);
		transform.LookAt (target.position);
	}
}
