public class BaseStat {
	private int _baseValue; //The base value of the stat es. the points from RO
	private int _buffValue; //The amount of the buff to this stat
	private int _expToLevel; //Exp needed to raise stats again
	private float _levelModifier; //exp modifier for levels

	public BaseStat () {
		_baseValue = 0;
		_buffValue = 0;
		_levelModifier = 1.1f;
		_expToLevel = 100;
	}

		//Base setters and getters
	public int BaseValue 
	{
		get {return _baseValue;}
		set {_baseValue = value;}
	}
    public int BuffValue {
		get { return _buffValue;}
		set { _buffValue = value;}
	}
	public int ExpToLevel {
		get { return _expToLevel;}
		set { _expToLevel = value;}
	}
	public float LevelModifier {
		get { return _levelModifier;}
		set { _levelModifier = value;}

	}


	private int CalculateExpToLevel () {
		return (int)(_expToLevel * _levelModifier);
	}
	public void LevelUp(){
		_expToLevel = CalculateExpToLevel ();
		_baseValue++;
	}
	public int AdjustedBaseValue() {
		return _baseValue + _buffValue;
		
	}

}

