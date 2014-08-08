/// <summary>
/// Vital bar.cs 
/// 31/07/14
/// Marco(?)
/// This shows the vitals of a player and the mob.
/// </summary>
using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	public bool _isPlayerHealthBar; //this tells if its the player HP bar or the mob HP bar

	private int _maxBarLenght; //how long the bar is if it's 100% 
	private int _curBarlenght; //how long the bar is right now 
	private GUITexture _display; 

	void Awake(){
		_display = gameObject.GetComponent<GUITexture> ();
	}
	// Use this for initialization
	void Start () {
		// _isPlayerHealthBar = true;


		_maxBarLenght = (int)_display.pixelInset.width;
		_curBarlenght = _maxBarLenght;
		_display = gameObject.GetComponent<GUITexture> ();

		OnEnable ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//When you want to see the bars
	public void OnEnable (){
		if (_isPlayerHealthBar)
						Messenger<int, int>.AddListener ("player health update", OnChangeHealthBarSize);
				else {
						ToggleDisplay (false);
						Messenger<int, int>.AddListener ("mob health update", OnChangeHealthBarSize);
						Messenger<bool>.AddListener ("show mob vitalbars", ToggleDisplay);
				}
	}
	//When you dont want to anymore
	public void OnDisable (){
		if (_isPlayerHealthBar)
		Messenger<int, int>.RemoveListener ("player health update", OnChangeHealthBarSize);
		else
		Messenger<int, int>.RemoveListener ("mob health update", OnChangeHealthBarSize);
		Messenger<bool>.RemoveListener ("show mob vitalbars", ToggleDisplay);

	}

	//calcs the size of the bar in relation of curhp/maxhp
	public void OnChangeHealthBarSize (int curHealth, int maxHealth) {
	//	Debug.Log ("we heard an event NIGGA current:  " + curHealth+ " max:  "+ maxHealth);
		_curBarlenght = (int) ((curHealth /(float) maxHealth) * _maxBarLenght); //this calcs the current bar lenght based on the hp%
	//	_display.pixelInset = new Rect(_display.pixelInset.x, _display.pixelInset.y, _curBarlenght, _display.pixelInset.height);
		_display.pixelInset = CalculatePosition ();
	}

	//setting the healthbar to the player or mob
	public void SetPlayerHealth(bool b){
		_isPlayerHealthBar = b;
	}
	private Rect CalculatePosition(){
		float yPos = _display.pixelInset.y / 2 - 10;


		if (!_isPlayerHealthBar) {
			float xPos=(_maxBarLenght-_curBarlenght)-(_maxBarLenght/4+10);
			return new Rect(xPos, yPos, _curBarlenght, _display.pixelInset.height);
		}
		return new  Rect(_display.pixelInset.x, _display.pixelInset.y, _curBarlenght, _display.pixelInset.height);
	}
	private void ToggleDisplay(bool show){
		_display.enabled = show;
	}
}
