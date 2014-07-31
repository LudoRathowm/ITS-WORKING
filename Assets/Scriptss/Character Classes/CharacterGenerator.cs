using UnityEngine;
using System.Collections;
using System;  //ENUM NIGGA

public class CharacterGenerator : MonoBehaviour {
	
	private PlayerCharacter _faget;
	private const int STARTING_POINTS = 350;
	private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
	private const int STARTING_VALUE = 50;
	private int pointsLeft;

	private const int OFFSET = 5;
	private const int LINE_HEIGHT = 20;

	private const int STAT_LABEL_WIDTH = 100;
	private const int BASEVALUE_LABEL_WIDTH = 30;
	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;

	private int statStartingPos = 40 ;

	public GUISkin mySkin;


	public GameObject playerPrefab;


	// Use this for initialization
	void Start () {

		GameObject pc = Instantiate (playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

		pc.name = "pc";

  
		 //_faget = new PlayerCharacter ();
		// _faget.Awake ();
		_faget = pc.GetComponent <PlayerCharacter>();

		pointsLeft = STARTING_POINTS;


		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			_faget.GetPrimaryAttribute(cnt).BaseValue = STARTING_VALUE;
			pointsLeft -= (STARTING_VALUE - MIN_STARTING_ATTRIBUTE_VALUE);
		}
		_faget.StatUpdate ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI(){

		DisplayName ();
		DisplayPointsLeft ();
		DisplayAttributes ();
		DisplayVitals ();
		DisplaySkills ();
		if (_faget.Name == "" || pointsLeft > 70)
		DisplayCreateLabel ();
		else
		DisplayCreateButton ();

				}
		
		
		
		

		
	private void DisplayName () {
			GUI.Label (new Rect (10, 10, 50, 25), "Name:");
			_faget.Name = GUI.TextField (new Rect (65, 10, 100, 25), _faget.Name);
		}
	private void DisplayAttributes () {
	for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
		GUI.Label (new Rect (OFFSET, statStartingPos + (cnt * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((AttributeName)cnt).ToString ());
		GUI.Label (new Rect (STAT_LABEL_WIDTH + OFFSET, statStartingPos + (cnt * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), _faget.GetPrimaryAttribute (cnt).AdjustedBaseValue().ToString ());
			if (GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH,statStartingPos+(cnt*BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "-")) {
				if (_faget.GetPrimaryAttribute(cnt).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE) {
					_faget.GetPrimaryAttribute(cnt).BaseValue--;
					pointsLeft++;
					_faget.StatUpdate ();
				}
			}
			if (GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH, statStartingPos+(cnt*BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "+")) {
				if (pointsLeft > 0) {
					_faget.GetPrimaryAttribute(cnt).BaseValue++;
					pointsLeft--;
					_faget.StatUpdate ();
				}
			}
		}



		}
	private void DisplayVitals()	{
				for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			GUI.Label (new Rect (OFFSET*4 + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH +BUTTON_WIDTH *2 + OFFSET, statStartingPos + ((cnt + 7) * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((VitalName)cnt).ToString ());
			GUI.Label (new Rect (OFFSET*4 + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH +BUTTON_WIDTH *2 + OFFSET + STAT_LABEL_WIDTH, statStartingPos + ((cnt + 7) * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, 25), _faget.GetVital (cnt) .AdjustedBaseValue.ToString ());
				}

		}

	private void DisplaySkills(){	
		for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
			GUI.Label (new Rect (OFFSET*4 + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH +BUTTON_WIDTH *2 + OFFSET, statStartingPos + (cnt  * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((SkillName)cnt).ToString ());
			GUI.Label (new Rect (OFFSET*4 + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH +BUTTON_WIDTH *2 + OFFSET + STAT_LABEL_WIDTH, statStartingPos + (cnt * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), _faget.GetSkill (cnt) .AdjustedBaseValue.ToString ());
	}

	}
	private void DisplayPointsLeft() {
		GUI.Label (new Rect (250, 10, 100, 25), "Points Left: " + pointsLeft.ToString());

	}

	private void DisplayCreateLabel () {
		GUI.Label (new Rect (Screen.width/2 - 50, statStartingPos + ( + 10*LINE_HEIGHT ), 100, LINE_HEIGHT),"ur a faget","Button");
				}







	private void DisplayCreateButton () {
		if(	GUI.Button (new Rect (Screen.width/2 - 50, statStartingPos + ( + 10*LINE_HEIGHT ), 100, LINE_HEIGHT),"Create"))	
		   {
			GameObject gs = GameObject.Find("__Game Settings");
			GameSettings gsScript = GameObject.Find("__Game Settings").GetComponent<GameSettings>();
			//CHANGE THE VALUES TO THE MAX MODIFIED VALUES SO YOU DONT START WITH NO HP
			UpdateCurVitalValues();

			gsScript.SaveCharacterData();
			Application.LoadLevel(1);
		
		}
	}
	private void UpdateCurVitalValues(){
		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			_faget.GetVital(cnt).CurValue = _faget.GetVital(cnt).AdjustedBaseValue;		
		}
	}

}
