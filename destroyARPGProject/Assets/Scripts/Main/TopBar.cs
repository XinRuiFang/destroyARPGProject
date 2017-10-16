using UnityEngine;
using System.Collections;

public class TopBar : MonoBehaviour {
	UILabel coin;
	UILabel diamond;
	UIButton coinPlusBtn;
	UIButton diamondPlusBtn;
	void Awake()
	{
		coin = transform.Find ("coin/Label").GetComponent<UILabel> ();
		diamond = transform.Find ("diamond/Label").GetComponent<UILabel> ();
		coinPlusBtn = transform.Find ("coin/addBtn").GetComponent<UIButton> ();
		diamondPlusBtn = transform.Find ("diamond/addBtn").GetComponent<UIButton> ();
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
		coin.text = info._Coin.ToString ();
		diamond.text = info._Diamond.ToString ();
	}
}
