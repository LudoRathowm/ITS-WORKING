using UnityEngine;
using System.Collections;

public class Pierce : MonoBehaviour {
	public int SpearRange;
	public int PierceRange;
	private GameObject _spearman;
	private Transform _myTransform;
	private GameObject target;
	public bool delay;
	// Use this for initialization
	void Start () {
		_myTransform = transform;
		target = GameObject.FindGameObjectWithTag ("Player");
		bool delay = GetComponent<Spearman> ().Piercedelay;
	}
	
	// Update is called once per frame
	void Update () {

		if (delay == false) {
						//	GetComponent<AISpearman> ().enabled = false;
						Debug.Log ("PIERCING");
						SendMessage ("MoveMeForward", AdvancedMovement.Forward.none);
						SendMessage ("RotateMe", AdvancedMovement.Turn.none);

						CharacterController controller = GetComponent<CharacterController> ();
						Vector3 dash = transform.TransformDirection (Vector3.forward);
	
						controller.SimpleMove (dash * 500);
						new WaitForSeconds (3);
						GetComponent<Pierce> ().enabled = false;
						//	GetComponent<AISpearman> ().enabled = true;
						//GetComponent<Spearman> ().Piercedelay = true;
		

				}

	}
}
