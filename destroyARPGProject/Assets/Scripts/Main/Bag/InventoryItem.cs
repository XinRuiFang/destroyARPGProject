using UnityEngine;
using System.Collections;

public class InventoryItem {

	Inventory _item;
	int _count;
	int _feats;//this equip need how much feats to use 
	int _exp;//F0 E300 D500 C700 B1000 A1600 S2200 SS3000 SSS4000 Z6000
	int _strengthen;//qianghua 
	int _isDressed = 0;
	int _id;

	float energy;
	int attack;
	int defence;
	int health;
	int resistance;
	float healthCover;
	int energyCover;

	public int _Id
	{
		get{return _id;}
		set{_id = value;}
	}

	public int _IsDressed
	{
		get{ return _isDressed; }
		set{ _isDressed = value; }
	}
	public Inventory _Item
	{
		get{ return _item; }
		set{ _item = value; }
	}
	public int _Count
	{
		get{ return _count; }
		set{ _count = value; }
	}
	public int _Feats
	{
		get{ return _feats; }
		set{ _feats = value; }
	}
	public int _Exp
	{
		get{ return _exp; }
		set{ _exp = value; }
	}
	public int _Strengthen
	{
		get{ return _strengthen; }
		set{ _strengthen = value; }
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

}
