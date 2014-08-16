using UnityEngine;
using System.Collections;
[RequireComponent (typeof(AdvancedMovement))] 
[RequireComponent (typeof(SphereCollider))]
public class Flail : MonoBehaviour {
	GameObject target;
	private Transform _myTransform;
	public int ROTATION_DAMP = 45;
	public float attackTimer = 0;
	public float coolDown = 1.5f;
	// Use this for initialization
	void Start () {


//		GetComponent<AISpearman> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimer > 0)
			transform.Rotate (0, 80, 0);
			attackTimer -= Time.deltaTime;
		if (attackTimer < 0)
			attackTimer = 0;
		
		
		if (attackTimer == 0) {

			attackTimer = coolDown;
		}





	
		/*spearman.GetComponent<AISpearman>().enabled = false;

		Vector3 dir = (target.transform.position - _myTransform.position).normalized;
		float direction = Vector3.Dot (dir, transform.forward);
        
		dir = (target.transform.position - _myTransform.position).normalized;
		direction = Vector3.Dot (dir, transform.right);
		
		if (direction > ROTATION_DAMP) { //so he doenst keep switching from left to right like a nigger
			SendMessage ("RotateMe", AdvancedMovement.Turn.right);
		} else if (direction < -ROTATION_DAMP) {
			SendMessage ("RotateMe", AdvancedMovement.Turn.left);
		} else {
			Debug.Log ("SHIDDY");
			transform.Rotate (0, 60, 0);
		//	SendMessage ("RotateMe", AdvancedMovement.Turn.right);
			new WaitForSeconds(3);
			transform.Rotate (0, -60, 0);
		//	SendMessage ("RotateMe", AdvancedMovement.Turn.left);


		}
var newRotation = Quat
*/

	}
}
