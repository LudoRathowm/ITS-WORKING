using UnityEngine;
using System.Collections;


[RequireComponent (typeof(AdvancedMovement))] 
[RequireComponent (typeof(SphereCollider))] //how to see if its close enought to rek him or detect range

public class AI : MonoBehaviour {

	private enum State
		{Idle,
		Init,
		Setup,
		Search,
		Attack,
		Retreat,
		Flee
		}

	public float preceptionRadius = 10;

	public float baseMeleeRange = 3.5f;
	public Transform target; //ie. the transform of the player

	private Transform _myTransform;

	private const float ROTATION_DAMP = .3f;
	private const float FORWARD_DAMP = .9f;

	private Transform _home;
	private State _state;
	private bool _alive = true;
	private SphereCollider _sphereCollider;
	private float MovSpeed;


	void Start (){
	;

		_state = AI.State.Init;
		StartCoroutine ("FSM");
/* 
		 SphereCollider sc = GetComponent<SphereCollider> ();
		CharacterController cc = GetComponent<CharacterController> ();

		if (sc == null)
						Debug.LogError ("no sphere collider");
				else {			
						sc.isTrigger = true;
				}
		if (cc == null) {
						Debug.LogError ("NO COLLIDER ON CHARWAWA");
				} else {
			sc.center = cc.center;
				sc.radius = 10;
		}
*/
//		_myTransform = transform;

	//	GameObject go = GameObject.FindGameObjectWithTag ("Player");
	//	if (go == null)
	//					Debug.LogError ("NO PLAYER");
	//	target = go.transform; //takes as target the transform of the player
	}
	private IEnumerator FSM(){
		while (_alive) {
			switch(_state) {
			case State.Init:
				//Debug.Log ("INIT");
				Init ();
				break;
			case State.Setup:
				//Debug.Log ("SETUP");
				Setup ();
				break;
			case State.Search:
				//Debug.Log ("SEARCH");
				Move();
				Search ();
				break;
			case State.Attack:
				//Debug.Log ("ATK");
				Move ();
				Attack ();
				break;
			case State.Retreat:
				Retreat();
				break;
			case State.Flee:
				Move();
				Flee ();
				break;
			}
			yield return null;
		}
	}

	private void Init(){
		_myTransform = transform;
		_home = transform.parent.transform;
		_sphereCollider = GetComponent<SphereCollider> ();

		if (_sphereCollider == null) {
						Debug.LogError ("SPHERE COLLIDER NOT PRESENT");
						return;
				}
		_state = AI.State.Setup;

	}
	private void Setup (){
		_sphereCollider.center = GetComponent<CharacterController> ().center;
		_sphereCollider.radius = preceptionRadius;
		_sphereCollider.isTrigger = true;

		_alive = false;
		_state = AI.State.Search;

	}
	private void Search (){
		_state = AI.State.Attack;
	}
	private void Attack () {
		_state = AI.State.Retreat;
	    }
	private void Flee (){
		Move ();
		_state = AI.State.Search;
		}
	private void Retreat (){
		_myTransform.LookAt (target);
		Move ();
		_state = AI.State.Search;
	}




	/*
	void Update (){
		if (target) {
						Vector3 dir = (target.position - _myTransform.position).normalized;
						float direction = Vector3.Dot (dir, transform.forward);

						float dist = Vector3.Distance (target.position, _myTransform.position);
					
				
						if (direction > FORWARD_DAMP && dist > baseMeleeRange) {
								SendMessage ("MoveMeForward", AdvancedMovement.Forward.forward);
						} else {
								SendMessage ("MoveMeForward", AdvancedMovement.Forward.none);
						}
				
						dir = (target.position - _myTransform.position).normalized;
						direction = Vector3.Dot (dir, transform.right);
				
						if (direction > ROTATION_DAMP) { //so he doenst keep switching from left to right like a nigger
								SendMessage ("RotateMe", AdvancedMovement.Turn.right);
						} else if (direction < -ROTATION_DAMP) {
								SendMessage ("RotateMe", AdvancedMovement.Turn.left);
						} else {
								SendMessage ("RotateMe", AdvancedMovement.Turn.none);
						}


				} else {
			SendMessage ("MoveMeForward", AdvancedMovement.Forward.none);
			SendMessage ("RotateMe", AdvancedMovement.Turn.none);	
		}
	}
	*/


	private void Move(){

				if (target) {
						Vector3 dir = (target.position - _myTransform.position).normalized;
						float direction = Vector3.Dot (dir, transform.forward);
			
						float dist = Vector3.Distance (target.position, _myTransform.position);
			
			
						if (direction > FORWARD_DAMP && dist > baseMeleeRange) {
								SendMessage ("MoveMeForward", AdvancedMovement.Forward.forward);
						} else {
								SendMessage ("MoveMeForward", AdvancedMovement.Forward.none);
						}
			
						dir = (target.position - _myTransform.position).normalized;
						direction = Vector3.Dot (dir, transform.right);
			
						if (direction > ROTATION_DAMP) { //so he doenst keep switching from left to right like a nigger
								SendMessage ("RotateMe", AdvancedMovement.Turn.right);
						} else if (direction < -ROTATION_DAMP) {
								SendMessage ("RotateMe", AdvancedMovement.Turn.left);
						} else {
								SendMessage ("RotateMe", AdvancedMovement.Turn.none);
						}

				}
		}
	public void OnTriggerEnter(Collider other){
	//	Debug.Log ("ENTER");
		if (other.CompareTag ("Player")) {
			target = other.transform;
			_alive = true;
			GameObject obama = GameObject.Find("Obama");
			obama.GetComponent<AdvancedMovement>().walkSpeed = 35;
			StartCoroutine("FSM");
		}


	}

	public void OnTriggerExit(Collider other){
	//Debug.Log ("EXIT");
		if (other.CompareTag ("Player")) {
			target = _home;
			GameObject obama = GameObject.Find("Obama");
			obama.GetComponent<AdvancedMovement>().walkSpeed = 0.7f;
			//			_alive = false;
		}



	}
	private void setSpeed(){

        GameObject obama = GameObject.Find("Obama");
		obama.GetComponent<AdvancedMovement>().walkSpeed = 2;


		Debug.Log ("maybe");
	}
}