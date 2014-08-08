using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class AdvancedMovement : MonoBehaviour {
	public enum State {
		Idle, 
		Init,
		Setup,
		Run
	}

	public enum Turn
		{
		left = -1,
		none = 0,
		right = 1
		}
	public enum Forward {
	    back = -1,
		none = 0,
		forward = 1
	}
	public float rotateSpeed = 250;
	public float walkSpeed = 5;
	public float strafeSpeed = 2.5f;
	public float runMultiplier = 2;
	public float gravity = 20;
	public float airTime = 0; //how long have we been in the air
	public float fallTime = .5f; //the lenght of time we can fall before the system notices it
	public float jumpHeight = 200; 
	public float jumpTime = 1.5f; 

	public CollisionFlags _collisionFlags;
	private Vector3 _moveDirection; //direction the char is moving to
	private Transform _myTransform;
	private CharacterController _controller;


	private Turn _turn;
	private Forward _forward;
	private Turn _strafe;
	private bool _run;
	private bool _jump;

	private State _state;

	public void Awake(){
		_myTransform = transform;
		_controller = GetComponent<CharacterController> ();

		_state = AdvancedMovement.State.Init;
	}
	// Use this for initialization
	IEnumerator Start () {
				while (true) {
						switch (_state) {
						case State.Init:
						Init();
								break;
								case State.Setup:
				            SetUp();
								break;
			            case State.Run:
				             ActionPicker();
				                break;
			
						}
						yield return null;		
		
				}
		Init ();
		}
		



	
private void Init (){
	if(!GetComponent<CharacterController>())return;
	//if (!GetComponent<Animation> ())return; <=== uncomment once you get some animations. if this is enabled no animation = doesn't run
	
		_state = AdvancedMovement.State.Setup;
}


	private void SetUp(){
		//animation.Stop (); // it won't play any animation if you fucked something up
		//animation.wrapMode = WrapMode.Loop; //how you want the animation to act
		//animation ["jump"].layer = 1; <==== gives higher layer to jump animation so you jump instead of idling if you are doing both when you press the key to jump
		// animation ["jump"].wrapMode = wrapMode.Once; <===so you don't loop your jumping animation
		//animation.Play("the animation we wanna start with);
	_moveDirection = Vector3.zero;

		_turn = AdvancedMovement.Turn.none;
		_forward = AdvancedMovement.Forward.none;
		_run = true; //ie. you run except when you toggle it off aka walking
		_jump = false;
		_strafe = AdvancedMovement.Turn.none;


	_state = AdvancedMovement.State.Run;
}

	private void ActionPicker () {
		

			//					Debug.Log ("ROTATE:" + Input.GetAxis ("Rotate Player"));
			_myTransform.Rotate(0, (int)_turn*Time.deltaTime*rotateSpeed, 0);

		
		if (_controller.isGrounded) {
			airTime = 0;
			_moveDirection = new Vector3((int)_strafe,0,(int)_forward);
			_moveDirection = _myTransform.TransformDirection(_moveDirection).normalized;
			_moveDirection *= walkSpeed;
			
			if(_forward != Forward.none){
				if(_run){
					_moveDirection *= runMultiplier;
					Run ();}
				else {Walk ();}
			}
			else if (_strafe!=AdvancedMovement.Turn.none){
				Strafe ();
			}
			else {Idle();}
			
			if (_jump){
				if(airTime<jumpTime) {
					_moveDirection.y += jumpHeight;
					Jump ();
					_jump = false;
				}
			}
			
		} else {
			
			
			if((_collisionFlags & CollisionFlags.CollidedBelow) == 0){
				airTime += Time.deltaTime;
				if(airTime > fallTime) {
					Fall();
				}
			}
		}
		_moveDirection.y -= gravity * Time.deltaTime;
		_collisionFlags = _controller.Move (_moveDirection*Time.deltaTime);

	}
	public void ToggleRun(){
		_run = !_run; //it changes from true to false to toggle run on/off
	}


	public void RotateMe(Turn y){
		_turn = y;
	}

    public void Strafe (Turn x) {
				_strafe = x;
		}
	public void JumpUp () {
		_jump = true;
	}

	public void MoveMeForward(Forward z) {
		_forward = z;
	}
	public void Idle(){
		//animation.crossFade ("idle");
	}
	public void Walk(){
		//animation.crossFade ("run");
	}
	public void Run (){
		//animation["run"].speed = 1.5f;
		//animation.crossFade ("run");
	}
	public void Jump (){
		//animation.crossFade ("jump");
	}
	public void Fall(){
		//animation.crossFade("Fall");
	}
	public void Strafe (){}
	//animation.crossFade ("Sidestep or whatever");

}
