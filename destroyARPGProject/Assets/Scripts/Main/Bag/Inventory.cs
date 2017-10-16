using UnityEngine;
using System.Collections;

public enum InventoryType
{
	Equip,
	Drug
}
public enum EquipType
{
	wuqi,
	shangyi,
	xiazhuang,
	jianjia,
	yaodai,
	xie,
	jiezhi,
	zengfushu  
}
public class Inventory {
	int _id;
	string _name;
	string _headpic;
	string _describe;
	string _protodescribe;
	InventoryType _inventoryType;
	EquipType _equipType;
	int _standardPrice;
	int _power;
	float _energy;
	int _attack;
	int _defence;
	int _health;
	int _resistance;
	float _healthCover;
	int _energyCover;
	int _bagCount;
	float _expAdd;
	InfoType _infoType;
	int _applyValue;

	public int _Id
	{
		get{ return _id; }
		set{ _id = value; }
	}
	public string _Name
	{
		get{ return _name; }
		set{ _name = value; }
	}
	public string _Headpic
	{
		get{ return _headpic; }
		set{ _headpic = value; }
	}
	public string _Describe
	{
		get{ return _describe; }
		set{ _describe = value; }
	}
	public string _Protodescribe
	{
		get{ return _protodescribe; }
		set{ _protodescribe = value; }
	}
	public InventoryType _InventoryType
	{
		get{ return _inventoryType; }
		set{ _inventoryType = value; }
	}
	public EquipType _EquipType
	{
		get{ return _equipType; }
		set{ _equipType = value; }
	}
	public int _StandardPrice
	{
		get{ return _standardPrice; }
		set{ _standardPrice = value; }
	}
	public int _Power
	{
		get{ return _power; }
		set{ _power = value; }
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
	public int _BagCount
	{
		get{ return _bagCount; }
		set{ _bagCount = value; }
	}
	public float _ExpAdd
	{
		get{ return _expAdd; }
		set{ _expAdd = value; }
	}
	public InfoType _InfoType
	{
		get{ return _infoType; }
		set{ _infoType = value; }
	}	
	public int _ApplyValue
	{
		get{ return _applyValue; }
		set{ _applyValue = value; }
	}
}
