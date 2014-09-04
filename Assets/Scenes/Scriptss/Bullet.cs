using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public Rigidbody projectile;
	public float speed = 2;


	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Shoot")) {
			Rigidbody instantiateProjectile = Instantiate(projectile,transform.position,transform.rotation) as Rigidbody;

			instantiateProjectile.velocity = transform.TransformDirection(new Vector3(0,0,speed));
		
		
		}

	}
}
