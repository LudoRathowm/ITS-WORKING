using UnityEngine;
using System.Collections;
using System;
public class GameSettings : MonoBehaviour {
	public const string PLAYER_SPAWN_POINT = "Player Spawn Point"; // Name of the game object the player spawns from


	void Awake (){
		DontDestroyOnLoad (this);
	
	}



	public void  SaveCharacterData ()
	{
				GameObject pc = GameObject.Find ("pc");
				PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter> ();
		PlayerPrefs.DeleteAll ();
				PlayerPrefs.SetString ("PlayerName", pcClass.Name);


				for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {

						PlayerPrefs.SetInt (((AttributeName)cnt).ToString () + "- Base Value", pcClass.GetPrimaryAttribute (cnt).BaseValue);
						PlayerPrefs.SetInt (((AttributeName)cnt).ToString () + " - Exp To Level", pcClass.GetPrimaryAttribute (cnt).ExpToLevel);
		
				}
				for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			
						PlayerPrefs.SetInt (((VitalName)cnt).ToString () + "- Base Value", pcClass.GetVital (cnt).BaseValue);
						PlayerPrefs.SetInt (((VitalName)cnt).ToString () + " - Exp To Level", pcClass.GetVital (cnt).ExpToLevel);
						PlayerPrefs.SetInt (((VitalName)cnt).ToString () + " - Cur Value", pcClass.GetVital (cnt).CurValue);
					//?????idk	pcClass.GetVital (cnt).GetModifyingAttributesString ();
			PlayerPrefs.SetString ( ((VitalName)cnt).ToString ()+" - Mods",			pcClass.GetVital (cnt).GetModifyingAttributesString () );

				}
				for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
						PlayerPrefs.SetInt (((SkillName)cnt).ToString () + "- Base Value", pcClass.GetSkill (cnt).BaseValue);
						PlayerPrefs.SetInt (((SkillName)cnt).ToString () + " - Exp To Level", pcClass.GetSkill (cnt).ExpToLevel);

			PlayerPrefs.SetString ( ((SkillName)cnt).ToString ()+" - Mods",			pcClass.GetSkill (cnt).GetModifyingAttributesString () );



				}
		}


	public void LoadCharacterData ()
	{
		GameObject pc = GameObject.Find ("pc");
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter> ();

		pcClass.Name = PlayerPrefs.GetString ("PlayerName", "Name Me");
	//	Debug.Log (pcClass.Name);

		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			
			pcClass.GetPrimaryAttribute (cnt).BaseValue = PlayerPrefs.GetInt (((AttributeName)cnt).ToString () + "- Base Value",0);
			pcClass.GetPrimaryAttribute (cnt).ExpToLevel = PlayerPrefs.GetInt (((AttributeName)cnt).ToString () + " - Exp To Level", 0);
			
		}

		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			
			pcClass.GetVital (cnt).BaseValue =	PlayerPrefs.GetInt (((VitalName)cnt).ToString () + "- Base Value",0 );
			pcClass.GetVital (cnt).ExpToLevel = PlayerPrefs.GetInt (((VitalName)cnt).ToString () + " - Exp To Level",0);


			//Adjustes the cur value to the adj base value
			pcClass.GetVital(cnt).Update();


			//get the stored value on curValue per each vital
			pcClass.GetVital (cnt).CurValue = PlayerPrefs.GetInt (((VitalName)cnt).ToString () + " - Cur Value", 1);
		}
		for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
						pcClass.GetSkill (cnt).BaseValue = PlayerPrefs.GetInt (((SkillName)cnt).ToString () + " - Base Value", 0);
						pcClass.GetSkill (cnt).ExpToLevel = PlayerPrefs.GetInt (((SkillName)cnt).ToString () + " - Base Value", 0);
				}

		//output the curValue for each of the vitals
	//	for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
	//		string myMods = PlayerPrefs.GetString(((VitalName)cnt).ToString()+ "- Mods", "");

	//		string[] mods = myMods.Split ('|');
	//		foreach (string s in mods){
	//			string[] modStats = s.Split('_');

	//			for (int x = 0; x < Enum.GetValues(typeof(VitalName)).Length; x++) {
	//				if (modStats[0] == ((AttributeName)x). ToString ())
	//					Debug.Log(modStats[0] + "-" + ((AttributeName)x).ToString());
	//			}

	//		pcClass.GetVital((int)VitalName.Health).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Constitution), modStats[1]));
	//		}
			//pcClass.GetVital (cnt).GetModifyingAttributesString ();
		

			//	PlayerPrefs.SetString ( ((VitalName)cnt).ToString ()+" - Mods",			pcClass.GetVital (cnt).GetModifyingAttributesString () );
			
		}



		
		}






