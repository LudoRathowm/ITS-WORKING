using UnityEngine;
	using System.Collections;

	public class Spearman : MonoBehaviour {
		public GameObject target;
		private Transform _myTransform;
	    public float dist;
		public float _pierceRange = 30f;
		public float _flailRange = 5.0f;
		public bool Piercedelay = true;
		public float pierceTimer;
	public float pierceTimerFull = 5f;
	//public float flailTimer;
	//public float flailTimerFull;
	//GameObject spear;

		void Start () {
			_myTransform = transform;
			target = GameObject.FindGameObjectWithTag ("Player");

				}
		
		// Update is called once per frame
		void Update () {

				
						dist = Vector3.Distance (target.transform.position, transform.position);
						
				
					if (pierceTimer > 0)
								pierceTimer -= Time.deltaTime;

						if (pierceTimer < 0)
								pierceTimer = 0;
			
			
						if (pierceTimer == 0) {
								Debug.Log ("PIERCE TIMER=0");
								Piercedelay = false;
								pierceTimer = pierceTimerFull;
			   
						}
			
						if (Piercedelay == false) {
								Debug.Log ("Pierce is not on delay");
								//	    if  (dist < _pierceRange) {
								transform.LookAt (target.transform);
								Debug.Log ("Close enought to pierce");
			
								//		SendMessage ("MoveMeForward", AdvancedMovement.Forward.none);
								SendMessage ("RotateMe", AdvancedMovement.Turn.none);

								transform.Translate (Vector3.forward *Time.deltaTime);
			transform.Translate(Vector3.up * (6*dist)*Time.deltaTime, Space.World);
								
				/*CharacterController controller = GetComponent<CharacterController> ();
				Vector3 dash = transform.TransformDirection (Vector3.forward);
				
				controller.SimpleMove (dash * 4500);
				new WaitForSeconds (3);*/
								Piercedelay = true;

								//	}
						}



						
				}
		

			

	}
