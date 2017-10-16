using UnityEngine;
using System.Collections;
using System;

public enum InfoType
{
	_Name,
	_Head,
	_Level,
	_Power,
	_Exp,
	_Diamond,
	_Coin,
	_Energy,
	_Attack,
	_Defence,
	_Health,
	_Resistance,
	_HealthCover,
	_EnergyCover,
	_NowHealth,
	_NowEnergy,
	_BagCount,
	_feats,
	_transcript,
	_All
}

public class PlayerInfo : MonoBehaviour {

	public static PlayerInfo _instance;

	string _name;
	string _head;
	int _level = 1;
	int _power = 1;
	int _exp = 0;
	int _diamond = 0;
	int _coin = 0;
	int _ruby = 0;
	int _mine = 0;
	float _energy;
	int _attack;
	int _defence;
	int _health;
	int _resistance;
	float _healthCover;
	int _energyCover;
	float _nowHealth;
	int _nowEnergy;
	int _bagCount;
	int _feats;
	int _transcript;

	float energy;
	int attack;
	int defence;
	int health;
	int resistance;
	float healthCover;
	int energyCover;

	public InventoryItem wuqiInventory;
	public InventoryItem shangyiInventory;
	public InventoryItem xiazhuangInventory;
	public InventoryItem yaodaiInventory;
	public InventoryItem jianjiaInventory;
	public InventoryItem xieInventory;
	public InventoryItem jiezhiInventory;
	public InventoryItem zengfushuInventory;

	float energyTimer;
	float healthTimer;

	public delegate void OnPlayerInfoChangedEvent(InfoType type);
	public event OnPlayerInfoChangedEvent OnPlayerInfoChanged;

	void Awake()
	{
		_instance = this;
		Init ();
	}
	public int _BagCount
	{
		get{return _bagCount;}
		set{_bagCount = value;}
	}
	public int _Transcript
	{
		get{return _transcript;}
		set{_transcript = value;}
	}
	public int _Feats
	{
		get{return _feats;}
		set{_feats = value;}
	}
	public int _Ruby
	{
		get{ return _ruby;}
		set{_ruby = value;}
	}
	public int _Mine
	{
		get{return _mine;}
		set{_mine = value;}
	}
	public string _Name
	{
		get{ return _name; }
		set{ _name = value; }
	}
	public string _Head
	{
		get{ return _head; }
		set{ _head = value; }
	}
	public int _Level
	{
		get{ return _level; }
		set{ _level = value; }
	}
	public int _Power
	{
		get{ return _power; }
		set{ _power = value; }
	}
	public int _Exp
	{
		get{ return _exp; }
		set{ _exp = value; }
	}
	public int _Diamond
	{
		get{ return _diamond; }
		set{ _diamond = value; }
	}
	public int _Coin
	{
		get{ return _coin; }
		set{ _coin = value; }
	}
	public float _Energy
	{
		get{ return _energy; }
		set{ _energy = value; }
	}
	public int _Attack
	{
		get{ return _attack; }
		set{ _attack = value; }
	}
	public int _Defence
	{
		get{ return _defence; }
		set{ _defence = value; }
	}
	public int _Health
	{
		get{ return _health; }
		set{ _health = value; }
	}
	public int _Resistance
	{
		get{ return _resistance; }
		set{ _resistance = value; }
	}
	public float _HealthCover
	{
		get{ return _healthCover; }
		set{ _healthCover = value; } 
	}
	public int _EnergyCover
	{
		get{ return _energyCover; }
		set{ _energyCover = value; } 
	}
	public float _NowHealth
	{
		get{ return _nowHealth; }
		set{ _nowHealth = value; } 
	}
	public int _NowEnergy
	{
		get{ return _nowEnergy; }
		set{ _nowEnergy = value; } 
	}

	public float Energy
	{
		get{ return energy; }
		set{ energy = value; }
	}
	public int Attack
	{
		get{ return attack; }
		set{ attack = value; }
	}
	public int Defence
	{
		get{ return defence; }
		set{ defence = value; }
	}
	public int Health
	{
		get{ return health; }
		set{ health = value; }
	}
	public int Resistance
	{
		get{ return resistance; }
		set{ resistance = value; }
	}
	public float HealthCover
	{
		get{ return healthCover; }
		set{ healthCover = value; } 
	}
	public int EnergyCover
	{
		get{ return energyCover; }
		set{ energyCover = value; } 
	}


	void Update()
	{
		if (this._NowHealth < this._Health) 
		{
			healthTimer +=Time.deltaTime;
			if(healthTimer >= 1)
			{
				this._NowHealth += this._HealthCover;
				healthTimer = 0;
				OnPlayerInfoChanged(InfoType._Health);
			}
		}
		else
		{
			healthTimer = 0;
		}

		if(this._NowEnergy < this._Energy)
		{
			energyTimer += Time.deltaTime;
			if(energyTimer > 60)
			{
				this._NowEnergy +=this._EnergyCover;
				energyTimer = 0;
				OnPlayerInfoChanged(InfoType._Energy);
			}
		}
		else
		{
			energyTimer = 0;
		}
	}
	void InitPlayerInfo(LitJson.JsonData jd)
	{
		this._Name = (string)jd[0]["_Name"];
		this._Head = (string)jd[0]["_Head"];
		this._Coin = int.Parse((string)jd[0]["_Coin"]);
		this._Diamond = int.Parse((string)jd[0]["_Diamond"]);
		this._Ruby = int.Parse((string)jd[0]["_Ruby"]);
		this._Mine = int.Parse((string)jd[0]["_Mine"]);
		this._Energy = float.Parse((string)jd[0]["_Energy"]);
		this._Health = int.Parse((string)jd[0]["_Health"]);
		this._Level = int.Parse((string)jd[0]["_Level"]);
		this._Exp = int.Parse((string)jd[0]["_Exp"]);
		this._Attack = int.Parse((string)jd[0]["_Attack"]);
		this._Defence = int.Parse((string)jd[0]["_Defence"]);
		this._Resistance = int.Parse((string)jd[0]["_Resistance"]);
		this._HealthCover = float.Parse((string)jd[0]["_HealthCover"]);
		this._EnergyCover = int.Parse((string)jd[0]["_EnergyCover"]);
		this._BagCount = int.Parse((string)jd[0]["_BagCount"]) + 60;
		this._Feats = int.Parse((string)jd[0]["_Feats"]) + this._Level * 4;
		this._Transcript = int.Parse((string)jd[0]["_Transcript"]);
		this._NowEnergy = 34;
		this._NowHealth = 1123;
	}
	void Init()
	{
		string sql = "select * from ARPG_playerInfo where _LoginName='admin'";
		StartCoroutine (Client._instance.InitWaitForRequest (sql, delegate(string cb) {
			InitPlayerInfo (Client._instance.SerializationJson (cb));
			OnPlayerInfoChanged (InfoType._All);
		}));

	}
	void PutonEquip(InventoryItem it)
	{
		this.Energy += it.Energy; 
		this.Health += it.Health; 
		this.Attack += it.Attack; 
		this.Defence += it.Defence; 
		this.Resistance += it.Resistance; 
		this.HealthCover += it.HealthCover; 
		this.EnergyCover += it.EnergyCover; 
		//this.BagCount += it.BagCount; 
		MakePrototypes.GetPlayerPower (this);
		OnPlayerInfoChanged (InfoType._All);
	}
	void PutoffEquip(InventoryItem it)
	{
		this.Energy -= it.Energy; 
		this.Health -= it.Health; 
		this.Attack -= it.Attack; 
		this.Defence -= it.Defence; 
		this.Resistance -= it.Resistance; 
		this.HealthCover -= it.HealthCover; 
		this.EnergyCover -= it.EnergyCover; 
		//this.BagCount += it.BagCount; 
		MakePrototypes.GetPlayerPower (this);
		OnPlayerInfoChanged (InfoType._All);;
	}

	public void DressOn(InventoryItem it)
	{
		it._IsDressed = 1;
		int isDressed = 0;
		InventoryItem inventoryItemDressed = null;
		switch(it._Item._EquipType)
		{
		case EquipType.jianjia:
			if(jianjiaInventory != null)
			{
				isDressed = 1;
				inventoryItemDressed = jianjiaInventory;
			}
			jianjiaInventory = it;
			break;
		case EquipType.jiezhi:
			if(jiezhiInventory != null)
			{
				isDressed = 1;
				inventoryItemDressed = jiezhiInventory;
			}
			jiezhiInventory = it;
			break;
		case EquipType.shangyi:
			if(shangyiInventory != null)
			{
				isDressed = 1;
				inventoryItemDressed = shangyiInventory;
			}
			shangyiInventory = it;
			break;
		case EquipType.wuqi:
			if(wuqiInventory != null)
			{
				isDressed = 1;
				inventoryItemDressed = wuqiInventory;
			}
			wuqiInventory = it;
			break;
		case EquipType.xiazhuang:
			if(xiazhuangInventory != null)
			{
				isDressed = 1;
				inventoryItemDressed = xiazhuangInventory;
			}
			xiazhuangInventory = it;
			break;
		case EquipType.xie:
			if(xieInventory != null)
			{
				isDressed = 1;
				inventoryItemDressed = xieInventory;
			}
			xieInventory = it;
			break;
		case EquipType.yaodai:
			if(yaodaiInventory != null)
			{
				isDressed = 1;
				inventoryItemDressed = yaodaiInventory;
			}
			yaodaiInventory = it;
			break;
		case EquipType.zengfushu:
			if(zengfushuInventory != null)
			{
				isDressed = 1;
				inventoryItemDressed = zengfushuInventory;
			}
			zengfushuInventory = it;
			break;
		}
		if(isDressed == 1)
		{
			inventoryItemDressed._IsDressed = 0;
			InventoryUI._instance.AddInventoryItem(inventoryItemDressed);
			string sql = "update ARPG_inventoryItem set _isDressed=0 where _Id='"+inventoryItemDressed._Id+"'";
			StartCoroutine (Client._instance.InitWaitForRequest (sql, delegate(string cb) {
			}));
		}
		PutonEquip(it);
		string sql2 = "update ARPG_inventoryItem set _isDressed=1 where _Id='"+it._Id+"'";
		StartCoroutine (Client._instance.InitWaitForRequest (sql2, delegate(string cb) {
		}));
		//.
		OnPlayerInfoChanged (InfoType._All);
	}
	public void DressOff(InventoryItem it)
	{
		it._IsDressed = 0;
		switch(it._Item._EquipType)
		{
		case EquipType.jianjia:
			if(jianjiaInventory != null)
			{
				jianjiaInventory = null;
			}
			break;
		case EquipType.jiezhi:
			if(jiezhiInventory != null)
			{
				jiezhiInventory = null;
			}
			break;
		case EquipType.shangyi:
			if(shangyiInventory != null)
			{
				shangyiInventory = null;
			}
			break;
		case EquipType.wuqi:
			if(wuqiInventory != null)
			{
				wuqiInventory = null;
			}
			break;
		case EquipType.xiazhuang:
			if(xiazhuangInventory != null)
			{
				xiazhuangInventory = null;
			}
			break;
		case EquipType.xie:
			if(xieInventory != null)
			{
				xieInventory = null;
			}
			break;
		case EquipType.yaodai:
			if(yaodaiInventory != null)
			{
				yaodaiInventory = null;
			}
			break;
		case EquipType.zengfushu:
			if(zengfushuInventory != null)
			{
				zengfushuInventory = null;
			}
			break;
		}
		PutoffEquip (it);
		string sql = "update ARPG_inventoryItem set _isDressed=0 where _Id='"+it._Id+"'";
		StartCoroutine (Client._instance.InitWaitForRequest (sql, delegate(string cb) {
		}));
		InventoryUI._instance.AddInventoryItem(it);
		OnPlayerInfoChanged (InfoType._All);
	}
	public void InventoryUse(InventoryItem it)
	{
		it._Count -= 1;
		if(it._Count <= 0)
		{
			InventoryManager._instance.inventoryItemList.Remove(it);
		}
		//..??
		this._NowHealth += 100;
		OnPlayerInfoChanged (InfoType._All);
	}
	public void GetCoin(int coin)
	{
		this._Coin += coin;
		OnPlayerInfoChanged (InfoType._All);
		string sqlquery = "update ARPG_playerInfo set _Coin="+this._Coin+" where _Name='"+this._Name+"'";
		StartCoroutine (Client._instance.InitWaitForRequest (sqlquery, delegate(string cb) {
			
		}));
	}
}
















