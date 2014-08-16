using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public GameObject playerCharacter;
	public Camera mainCamera;
	public float zOffset;
	public float yOffset;
	public float xRotOffset;

	public GameObject gameSettings;
	private GameObject _pc;
	private PlayerCharacter _pcScript;

	private Vector3 _playerSpawnPointPos;

	// Use this for initialization
	void Start (){
		_playerSpawnPointPos = new Vector3 (330, 20, 95); // WHERE YOU SPAWN

		GameObject go = GameObject.Find (GameSettings.PLAYER_SPAWN_POINT);

		if (go == null) {
			go = new GameObject(GameSettings.PLAYER_SPAWN_POINT);		
			go.transform.position = _playerSpawnPointPos;

		}


				_pc = Instantiate (playerCharacter, go.transform.position, Quaternion.identity) as GameObject;
		_pc.name = "pc";
				_pcScript = _pc.GetComponent<PlayerCharacter> ();

				zOffset = -2.5f;
				yOffset = 2.5f;
				xRotOffset = 22.5f;

				mainCamera.transform.position = new Vector3 (_pc.transform.position.x, _pc.transform.position.y + yOffset, _pc.transform.position.z + zOffset);
				mainCamera.transform.Rotate (xRotOffset, 0, 0); 

		LoadCharacter ();
	
		}
	public void LoadCharacter (){
		GameObject gs = GameObject.Find ("__Game Settings");
		if (gs == null) {
		GameObject gs1 = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
			gs1.name = "gameSettings";
		}

		GameSettings gsScript = GameObject.Find("gameSettings").GetComponent<GameSettings>();

	
		//Loading

		gsScript.LoadCharacterData();


	}
}
