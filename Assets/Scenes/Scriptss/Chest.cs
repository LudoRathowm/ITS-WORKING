using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class Chest : MonoBehaviour {
	public enum State
	{open,
		close,
		inbetween

	}

	public AudioClip openSound;
	public AudioClip closeSound;

	public GameObject qtChest;




	public State state;

	public float maxDistance =2f; //from the player


	// Use this for initialization
	void Start () {
		state = Chest.State.close;

	}
	

	public void OnMouseEnter()
	{Highlight (true);

				}
	public void OnMouseExit(){
		Highlight (false);
	}
	public void OnMouseUp(){
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		if (null == go)
						return;
		if (Vector3.Distance (transform.position, go.transform.position) > maxDistance)
						return;

		switch (state) {
		case State.open: 
			state = Chest.State.inbetween;
			StartCoroutine("Close");
			break;
		case State.close:
			state = Chest.State.inbetween;
			StartCoroutine("Open");
			break;
		
		}
	/*	if (state == Chest.State.close) 
						Open ();
				else
						Close ();
	*/			
	}


	private IEnumerator Open()
	{
		//animation.Play("open"); <==tfw no chests
		// yield return WaitForSeconds (animation ["open"].length); <= if we had an animation we'd set it to wait till the animation stops playing

		audio.PlayOneShot (openSound);
		yield return new WaitForSeconds (1.5f);
		state = Chest.State.open;
		Debug.Log ("CHEST OPEN");

	}

	private IEnumerator Close ()
	{
		//animation.Play("close"); <==tfw no chests

		yield return new WaitForSeconds (1.5f);
		state = Chest.State.close;
		Debug.Log ("CHEST CLOSED");
		}

	private void Highlight(bool glow){
		if (glow) {
			qtChest.GetComponent<MeshRenderer> ().enabled = true;

				} else {
			qtChest.GetComponent<MeshRenderer> ().enabled = false;
				}
	}














}
