using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AdvancedMovement))] 
[RequireComponent (typeof(SphereCollider))]
//how to see if its close enought to rek him or detect range

public class AISpearman : MonoBehaviour
{
	
		private enum State
		{
				Idle,
				Init,
				Setup,
				Search,
				Attack,
				Retreat,
				Flee,
				Thrust,
				Flail
		}
	
		public float preceptionRadius = 50;
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
		public float ThrustRange;
		public float Flailrange;
		private bool thrustflail;
		//private GameObject spearman;
	//	private bool dontmove = false;
		public int _spearLenght;
	public bool comingback = false;
//		private int PDelayCounter = 0;
	public float attackTimer = 0;
	public float coolDown = 2.0f;
//	private int PDelayMax = 3;
		public bool Piercedelay = false;
		void Start ()
		{
				;
				// spearman = GameObject.Find ("Spearman");
				_state = AISpearman.State.Init;
				StartCoroutine ("FSM");
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		}

		private IEnumerator FSM ()
		{
				while (_alive) {
						switch (_state) {
						case State.Init:
				Debug.Log ("INIT");
								Init ();
								break;
						case State.Setup:
				Debug.Log ("SETUP");
								Setup ();
								break;
						case State.Search:
				//Debug.Log ("SEARCH");
								Move ();
						//		Search ();
								break;
						case State.Attack:
				Debug.Log ("ATK");
								Move ();
								Attack ();
								break;
						case State.Thrust:
								SendMessage ("MoveMeForward", AdvancedMovement.Forward.none);
				
								SendMessage ("RotateMe", AdvancedMovement.Turn.none);
								Debug.Log ("STATE PIERCE");
								Pierce ();
								break;
						case State.Retreat:
								Retreat ();
								break;
						case State.Flee:
								Flee ();
								break;
						case State.Flail:
				yield return new WaitForSeconds(5);
								break;
						}
						yield return null;
				}
		}
	
		private void Init ()
		{
				_myTransform = transform;
				_sphereCollider = GetComponent<SphereCollider> ();
		_home = transform.parent.transform;
		
				if (_sphereCollider == null) {
						Debug.LogError ("SPHERE COLLIDER NOT PRESENT");
						return;
				}
				_state = AISpearman.State.Setup;
		
		}

		private void Setup ()
		{
				_sphereCollider.center = GetComponent<CharacterController> ().center;
				_sphereCollider.radius = preceptionRadius;
				_sphereCollider.isTrigger = true;
		
				_alive = false;
				_state = State.Search;
		
		}

		private void Search ()
		{
				_state = AISpearman.State.Attack;
		}

		private void Attack ()
		{
				_state = AISpearman.State.Retreat;
		}

		private void Flee ()
		{
				Move ();
				//	_state = AISpearman.State.Search;
		}

		private void Retreat ()
		{
				_myTransform.LookAt (target);
				Move ();
				_state = AISpearman.State.Search;
		}
	
		private void Move ()
		{
				//	if (dontmove != true) {
										GetComponent<AdvancedMovement> ().walkSpeed = 35;
					
							if (target) {
									Vector3 dir = (target.position - _myTransform.position).normalized;
									float direction = Vector3.Dot (dir, _myTransform.forward);
						
									float dist = Vector3.Distance (target.position, _myTransform.position);
						
						
									if (direction > FORWARD_DAMP && dist > ThrustRange) {
											SendMessage ("MoveMeForward", AdvancedMovement.Forward.forward);
									} else {

						                   if (comingback == false){

											if (dist < ThrustRange) {
													if (Piercedelay == false) {
															if (Vector3.Distance (target.position, _myTransform.position) > Flailrange) {
									dir = (target.position - _myTransform.position).normalized;
									direction = Vector3.Dot (dir, transform.right);
									if (direction < ROTATION_DAMP){
																	Debug.Log ("SPEAR RANGE");
																	Pierce ();						
									}	}		
															
													} else if (Vector3.Distance (target.position, _myTransform.position) < Flailrange) {
															
															Debug.Log ("FLAIL RANGE");								

															SendMessage ("MoveMeForward", AdvancedMovement.Forward.none);
															Flailaround ();
															
													}
											}
									}
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
				//}
		}

		public void OnTriggerEnter (Collider other)
		{
				//	Debug.Log ("ENTER");
				if (other.CompareTag ("Player")) {
						target = other.transform;
						_alive = true;
			comingback = false;
						
						GetComponent<AdvancedMovement> ().walkSpeed = 35;
						StartCoroutine ("FSM");
				}
		
		
		}
	
		public void OnTriggerExit (Collider other)
		{

				//Debug.Log ("EXIT");
				if (other.CompareTag ("Player")) {
			comingback = true;
						target = _home;

						GetComponent<AdvancedMovement> ().walkSpeed = 10f;
								_alive = false;
				}
		

		
		}

		private void Pierce ()
		{
		GetComponent<Pierce> ().enabled = true;
		}

		private void Flailaround ()
		{
		GetComponent<Flail> ().enabled = true;
				}

	
		

/*		private void setSpeed ()
		{
				//THIS IS NOT USED FOR NOW
				GameObject obama = GameObject.Find ("Obama");
				obama.GetComponent<AdvancedMovement> ().walkSpeed = 2;
		
	
		}
*/
	void Update (){
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		if (attackTimer < 0)
			attackTimer = 0;
		
		
		if (attackTimer == 0) {
				Piercedelay = false;
		}
	}


}