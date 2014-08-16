using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AdvancedMovement))]
public class Bangbang : MonoBehaviour {
	private Transform _myTransform;

	void Awake (){
		_myTransform = transform;
	}

	private bool needinput=true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


				if (Input.GetButtonUp ("Bang")) {
				_myTransform.Rotate(0, 45, 0);}

					if (Input.GetButtonUp ("Bing")){	
					_myTransform.Rotate(0, -45, 0);
			}

	}
}

