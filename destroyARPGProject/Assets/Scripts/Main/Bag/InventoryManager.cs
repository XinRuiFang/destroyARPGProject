using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager _instance;

	//public TextAsset listinfo;

	public Dictionary<int,Inventory> inventoryDic = new Dictionary<int, Inventory>();
	public List<InventoryItem> inventoryItemList = new List<InventoryItem>();	

	public delegate void OnInventoryChangeEvent();
	public event OnInventoryChangeEvent OnInventoryChange;

	void Awake()
	{
		_instance = this;
		ReadInventoryInfo ();

	}
	void Start()
	{


	}
	public void ReadInventoryInfo()
	{
		this.inventoryDic = InitInventoryQuery ();

	}
	void ReadInventoryItemInfo()
	{
		this.inventoryItemList = InitInventoryItemQuery ();

	}
	public Dictionary<int,Inventory> InitInventoryQuery()
	{
		string sql = "select * from ARPG_inventory";
		StartCoroutine(Client._instance.InitWaitForRequest (sql,delegate(string cb) {
			this.inventoryDic = InitInventory(Client._instance.SerializationJson(cb));
			ReadInventoryItemInfo ();
		}));
		return this.inventoryDic;
	}
	public List<InventoryItem> InitInventoryItemQuery()
	{
		string sql = "select * from ARPG_inventoryItem where _OwnName='"+PlayerInfo._instance._Name+"'";
		StartCoroutine (Client._instance.InitWaitForRequest (sql, delegate(string cb) {
						this.inventoryItemList = InitInventoryItem (Client._instance.SerializationJson (cb));
						PlayerInfo info = PlayerInfo._instance;
						MakePrototypes.MakePlayerStatus(info,inventoryItemList);
						info._Power = MakePrototypes.GetPlayerPower(info);
		}));
		return this.inventoryItemList;
	}

	List<InventoryItem> InitInventoryItem(JsonData jd)
	{
		for(int j = 0;j<jd.Count;j++)
		{
			int id = int.Parse((string)jd[j]["_item"]);
			Inventory i = null;
			inventoryDic.TryGetValue(id,out i);
			if(i._InventoryType != InventoryType.Equip)
			{
				InventoryItem it = new InventoryItem(); 
				it._Id = int.Parse((string)jd[j]["_Id"]);
				it._Item = MakeNewInventory(i);
				it._Count = int.Parse((string)jd[j]["_count"]);
				inventoryItemList.Add(it);

			}
			else
			{
				InventoryItem it = new InventoryItem();
				it._Id = int.Parse((string)jd[j]["_Id"]);
				it._Item = MakeNewInventory(i);
				it._Count = 1;
				it._Feats = int.Parse((string)jd[j]["_feats"]);
				it._Exp = int.Parse((string)jd[j]["_exp"]);
				it._Strengthen = int.Parse((string)jd[j]["_strengthen"]);
				it._IsDressed = int.Parse((string)jd[j]["_isDressed"]);
				PlayerInfo info = PlayerInfo._instance;
				if(it._IsDressed == 1)
				{
					switch(it._Item._EquipType)
					{
					case EquipType.jianjia:
						info.jianjiaInventory = it;
						break;
					case EquipType.jiezhi:
						info.jiezhiInventory = it;
						break;
					case EquipType.shangyi:
						info.shangyiInventory = it;
						break;
					case EquipType.wuqi:
						info.wuqiInventory = it;
						break;
					case EquipType.xiazhuang:
						info.xiazhuangInventory = it;
						break;
					case EquipType.xie:
						info.xieInventory = it;
						break;
					case EquipType.yaodai:
						info.yaodaiInventory = it;
						break;
					case EquipType.zengfushu:
						info.zengfushuInventory = it;
						break;
					}
				}
				MakePrototypes.MakeEquipProto(it,inventoryDic);
				inventoryItemList.Add(it);
			}
		}
		OnInventoryChange();
		return inventoryItemList;
	}
	Inventory MakeNewInventory(Inventory i)
	{
		Inventory i2 = new Inventory ();
		i2._Id = i._Id;
		i2._ApplyValue = i._ApplyValue;
		i2._Attack = i._Attack;
		i2._BagCount = i._BagCount;
		i2._Defence = i._Defence;
		i2._Describe = i._Describe;
		i2._Energy = i._Energy;
		i2._EnergyCover = i._EnergyCover;
		i2._EquipType = i._EquipType;
		i2._ExpAdd = i._ExpAdd;
		i2._Headpic = i._Headpic;
		i2._Health = i._Health;
		i2._HealthCover = i._HealthCover;
		i2._InfoType = i._InfoType;
		i2._InventoryType = i._InventoryType;
		i2._Name = i._Name;
		i2._Power = i._Power;
		i2._Protodescribe = i._Protodescribe;
		i2._Resistance = i._Resistance;
		i2._StandardPrice = i._StandardPrice;
		return i2;
	}
	Dictionary<int,Inventory>  InitInventory(JsonData jd)
	{
		Dictionary<int,Inventory>  it = new Dictionary<int,Inventory>  ();
		for(int i= 0;i<jd.Count;i++)
		{
			Inventory iy = new Inventory();
			iy._Id = int.Parse((string)jd[i]["_id"]);
			iy._Name = (string)jd[i]["_name"];
			iy._Headpic = (string)jd[i]["_headpic"];
			iy._Describe = (string)jd[i]["_describe"];
			iy._Protodescribe = (string)jd[i]["_protodescribe"];
			switch((string)jd[i]["_inventoryType"])
			{
			case "Equip":
				iy._InventoryType = InventoryType.Equip;
				break;
			case "Drug":
				iy._InventoryType = InventoryType.Drug;
				break;
			}
			if(iy._InventoryType  == InventoryType.Equip)
			{
				switch((string)jd[i]["_equipType"])
				{
				case "wuqi":
					iy._EquipType = EquipType.wuqi;
					break;
				case "shangyi":
					iy._EquipType = EquipType.shangyi;
					break;
				case "xiazhuang":
					iy._EquipType = EquipType.xiazhuang;
					break;
				case "yaodai":
					iy._EquipType = EquipType.yaodai;
					break;
				case "jianjia":
					iy._EquipType = EquipType.jianjia;
					break;
				case "xie":
					iy._EquipType = EquipType.xie;
					break;
				case "jiezhi":
					iy._EquipType = EquipType.jiezhi;
					break;
				case "zengfushu":
					iy._EquipType = EquipType.zengfushu;
					break;
				}
			}
			iy._StandardPrice = int.Parse((string)jd[i]["_standardPrice"]);
			if(iy._InventoryType  == InventoryType.Equip)
			{	
				//iy._Power = int.Parse((string)jd[i]["_power"]);
				iy._Energy = int.Parse((string)jd[i]["_energy"]);
				iy._Attack = int.Parse((string)jd[i]["_attack"]);
				iy._Defence = int.Parse((string)jd[i]["_defence"]);
				iy._Health = int.Parse((string)jd[i]["_health"]);
				iy._Resistance = int.Parse((string)jd[i]["_resistance"]);
				iy._HealthCover = float.Parse((string)jd[i]["_healthCover"]);
				iy._EnergyCover = int.Parse((string)jd[i]["_energyCover"]);
				iy._BagCount = int.Parse((string)jd[i]["_bagCount"]);
				iy._ExpAdd = float.Parse((string)jd[i]["_expAdd"]);
				//iy._Power =Convert.ToInt32((iy._Attack * 1.0 + this._Defence * 0.5 + this._Health * 0.3 +  this._Resistance * 30.0 + this._HealthCover * 10.0) * (1 + this._Level / 100.0));
			}
			
			
			
			
			if(iy._InventoryType == InventoryType.Drug)
			{
				switch((string)jd[i]["_infoType"])
				{
				case "_Level":
					iy._InfoType = InfoType._Level;
					break;
				case "_Exp":
					iy._InfoType = InfoType._Exp;
					break;
				case "_Diamond":
					iy._InfoType = InfoType._Diamond;
					break;
				case "_Coin":
					iy._InfoType = InfoType._Coin;
					break;
				case "_Energy":
					iy._InfoType = InfoType._Energy;
					break;
				case "_Attack":
					iy._InfoType = InfoType._Attack;
					break;
				case "_Defence":
					iy._InfoType = InfoType._Defence;
					break;
				case "_Health":
					iy._InfoType = InfoType._Health;
					break;
				case "_Resistance":
					iy._InfoType = InfoType._Resistance;
					break;
				case "_HealthCover":
					iy._InfoType = InfoType._HealthCover;
					break;
				case "_EnergyCover":
					iy._InfoType = InfoType._EnergyCover;
					break;
				case "_NowHealth":
					iy._InfoType = InfoType._NowHealth;
					break;
				case "_NowEnergy":
					iy._InfoType = InfoType._NowEnergy;
					break;
				case "_BagCount":
					iy._InfoType = InfoType._BagCount;
					break;
				}
				iy._ApplyValue = int.Parse((string)jd[i]["_applyValue"]);
			}
			it.Add(iy._Id,iy);
		}
		return it;
	}
	public void RemoveInventoryItem(InventoryItem it)
	{
		this.inventoryItemList.Remove (it);
		OnInventoryChange();
		string sqlquery = "delete from ARPG_inventoryItem where _Id='"+ it._Id +"'";
		StartCoroutine (Client._instance.InitWaitForRequest (sqlquery, delegate(string cb) {
			
		}));
	}
}
