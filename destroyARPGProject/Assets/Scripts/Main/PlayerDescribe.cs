using UnityEngine;
using System.Collections;

public class PlayerDescribe : MonoBehaviour {
	UISprite head;
	UILabel level;
	UILabel name;
	UILabel val;
	UISlider expPBar;
	UILabel expPBarLabel;
	UILabel diamondCount;
	UILabel coinCount;
	UILabel rubyCount;
	UILabel mineCount;
	UILabel attack;
	UILabel healthCover;
	UILabel resistance;
	UILabel defence;
	UILabel energy;
	UILabel health;

	void Awake()
	{
		head = transform.Find ("Head").GetComponent<UISprite>();
		level = transform.Find ("Level").GetComponent<UILabel>();
		name = transform.Find ("NameLabel").GetComponent<UILabel>();
		val = transform.Find ("ValueLabel").GetComponent<UILabel>();
		expPBar = transform.Find ("ExpPBar").GetComponent<UISlider>();
		expPBarLabel = transform.Find ("ExpPBar/Label").GetComponent<UILabel>();
		diamondCount = transform.Find ("initContainer/DiamondCount").GetComponent<UILabel>();
		coinCount = transform.Find ("initContainer/CoinCount").GetComponent<UILabel>();
		rubyCount = transform.Find ("initContainer/RubyCount").GetComponent<UILabel>();
		mineCount = transform.Find ("initContainer/MineCount").GetComponent<UILabel>();
		attack = transform.Find ("ProtoContainer/attack").GetComponent<UILabel>();
		healthCover = transform.Find ("ProtoContainer/healthCover").GetComponent<UILabel>();
		resistance = transform.Find ("ProtoContainer/resistance").GetComponent<UILabel>();
		defence = transform.Find ("ProtoContainer/defence").GetComponent<UILabel>();
		energy = transform.Find ("ProtoContainer/energy").GetComponent<UILabel>();
		health = transform.Find ("ProtoContainer/health").GetComponent<UILabel>();
		PlayerInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
	}
	void OnDestroy()
	{
		PlayerInfo._instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
	}
	void OnPlayerInfoChanged(InfoType type)
	{
		if(type != null)
		{
			UpdateShow();
		}
	}
	void UpdateShow()
	{
		PlayerInfo info = PlayerInfo._instance;
		head.spriteName = info._Head;
		level.text = info._Level.ToString();
		name.text = info._Name.ToString ();
		val.text = info._Power.ToString ();
		diamondCount.text = info._Diamond.ToString ();
		coinCount.text = info._Coin.ToString ();
		rubyCount.text = info._Ruby.ToString ();
		mineCount.text = info._Mine.ToString ();
		attack.text = info._Attack.ToString ();
		healthCover.text = info._HealthCover.ToString ();
		resistance.text = info._Resistance.ToString ();
		defence.text = info._Defence.ToString ();
		energy.text = info._Energy.ToString ();
		health.text = info._Health.ToString ();

	}

}
