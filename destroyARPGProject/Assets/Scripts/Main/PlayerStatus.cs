using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	UISprite head;
	UILabel name;
	UILabel level;
	UISlider health;
	UILabel healthLable;
	UISlider energy;
	UILabel energyLable;
	UIButton energyPlusBtn;

	void Awake()
	{
		head = transform.Find ("HeadBtn").GetComponent<UISprite> ();
		name = transform.Find ("NameLabel").GetComponent<UILabel> ();
		level = transform.Find ("LevelLabel").GetComponent<UILabel> ();
		health = transform.Find ("HealthPBar").GetComponent<UISlider> ();
		energy = transform.Find ("EnergyPBar").GetComponent<UISlider> ();
		energyPlusBtn = transform.Find ("EnergyBtn").GetComponent<UIButton> ();
		healthLable = transform.Find ("HealthPBar/healthLabel").GetComponent<UILabel> ();
		energyLable = transform.Find ("EnergyPBar/energyLabel").GetComponent<UILabel> ();
		PlayerInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
	}
	void OnDestroy()
	{
		PlayerInfo._instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
	}
	void OnPlayerInfoChanged(InfoType type)
	{
		if(type !=null)
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
		energy.value = info._NowEnergy/info._Energy;
		health.value = info._NowHealth/info._Health;
		healthLable.text = info._NowHealth + "/" + info._Health;
		energyLable.text = info._NowEnergy + "/" + info._Energy;
	}
}
