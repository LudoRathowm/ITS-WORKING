using UnityEngine;
using System.Collections;

public class Terrainmaker : MonoBehaviour {
	public Mesh mesh;
	public Material material;
	private int depth;
	public int maxDepth;


	private void Start () {

		Invoke ("Lineofcubes", 0.2f);

	}

	private void Initialize (Terrainmaker parent, Vector3 direction) {
		mesh = parent.mesh;
		material = parent.material;
		maxDepth = parent.maxDepth;
	
		depth = parent.depth + 1;

		transform.parent = parent.transform;
		transform.localPosition = direction * (0.5f + 0.5f * 1);
	
	}






private void Lineofcubes () {
	gameObject.AddComponent<MeshFilter>().mesh = mesh;
	gameObject.AddComponent<MeshRenderer>().material = material;
	
	if (depth < maxDepth) {
		new GameObject ("Terrain Copy").AddComponent<Terrainmaker> ().Initialize(this, Vector3.right);
		//	new GameObject ("Terrain Copy").AddComponent<Terrainmaker>().Initialize(this, Vector3.forward);
	}
	
}
}