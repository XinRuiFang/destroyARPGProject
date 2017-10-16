using UnityEngine;
using System.Collections;

public class BagRole : MonoBehaviour {
	BagRoleEquip wuqiSprite;
	BagRoleEquip shangyiSprite;
	BagRoleEquip xiazhuangSprite;
	BagRoleEquip jianjiaSprite;
	BagRoleEquip xieSprite;
	BagRoleEquip jiezhiSprite;
	BagRoleEquip yaodaiSprite;
	BagRoleEquip zengfushuSprite;

	UILabel healthLabel;
	UILabel attackLabel;
	UILabel defenceLabel;
	UILabel energyLabel;
	UILabel resistanceLabel;
	UILabel healthCoverLabel;
	UILabel powerLabel;
	UILabel featsLabel;

	void Awake()
	{
		wuqiSprite = transform.Find ("wuqiSprite").GetComponent<BagRoleEquip> ();
		shangyiSprite = transform.Find ("shangyiSprite").GetComponent<BagRoleEquip> ();
		xiazhuangSprite = transform.Find ("xiazhuangSprite").GetComponent<BagRoleEquip> ();
		jianjiaSprite = transform.Find ("jianjiaSprite").GetComponent<BagRoleEquip> ();
		xieSprite = transform.Find ("xieSprite").GetComponent<BagRoleEquip> ();
		jiezhiSprite = transform.Find ("jiezhiSprite").GetComponent<BagRoleEquip> ();
		yaodaiSprite = transform.Find ("yaodaiSprite").GetComponent<BagRoleEquip> ();
		zengfushuSprite = transform.Find ("zengfushuSprite").GetComponent<BagRoleEquip> ();

		healthLabel = transform.Find ("ProtoContainer/HealthLabel").GetComponent<UILabel> ();
		attackLabel = transform.Find ("ProtoContainer/AttackLabel").GetComponent<UILabel> ();
		defenceLabel = transform.Find ("ProtoContainer/DefenceLabel").GetComponent<UILabel> ();
		energyLabel = transform.Find ("ProtoContainer/EnergyLabel").GetComponent<UILabel> ();
		resistanceLabel = transform.Find ("ProtoContainer/ResistanceLabel").GetComponent<UILabel> ();
		healthCoverLabel = transform.Find ("ProtoContainer/HealthCoverLabel").GetComponent<UILabel> ();
		powerLabel = transform.Find ("ProtoContainer/PowerLabel").GetComponent<UILabel> ();
		featsLabel = transform.Find ("ProtoContainer/FeatsLabel").GetComponent<UILabel> ();

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

		wuqiSprite.SetInventoryItem (info.wuqiInventory);
		shangyiSprite.SetInventoryItem (info.shangyiInventory);
		xiazhuangSprite.SetInventoryItem (info.xiazhuangInventory);
		yaodaiSprite.SetInventoryItem (info.yaodaiInventory);
		xieSprite.SetInventoryItem (info.xieInventory);
		jianjiaSprite.SetInventoryItem (info.jianjiaInventory);
		jiezhiSprite.SetInventoryItem (info.jiezhiInventory);
		zengfushuSprite.SetInventoryItem (info.zengfushuInventory);

		healthLabel.text = info.Health.ToString();
		attackLabel.text = info.Attack.ToString ();
		defenceLabel.text = info.Defence.ToString ();
		energyLabel.text = info.Energy.ToString ();
		resistanceLabel.text = info.Resistance.ToString ();
		healthCoverLabel.text = info.HealthCover.ToString ();
		powerLabel.text =  System.Convert.ToInt32((info.Attack * 1.0 + info.Defence * 0.5 + info.Health * 0.3 +  info.Resistance * 30.0 + info.HealthCover * 10.0) * (1 + info._Level / 100.0)).ToString();
		featsLabel.text = info._Feats.ToString ();
	}
}
















