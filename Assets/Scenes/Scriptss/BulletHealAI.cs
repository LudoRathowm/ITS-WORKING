using UnityEngine;
using System.Collections;

public class BulletHealAI : MonoBehaviour {

	public Rigidbody projectile;
	public float speed = 20;
	float shootdelay = 0f;
	float fulldelay = 0.3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				if (shootdelay > 0)
						shootdelay -= Time.deltaTime;
				if (shootdelay < 0)
						shootdelay = 0;
				if (shootdelay == 0) {
		
						Rigidbody instantiateProjectile = Instantiate (projectile, transform.position, transform.rotation) as Rigidbody;
						instantiateProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));
			shootdelay = fulldelay;
		}
		}
}
