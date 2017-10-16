using UnityEngine;
using System.Collections;

public class SkillItem  {
	int _id;
	Skill _skill;

	int _level;
	float _coldTimeEx;
	float _crtical;//baoji
	float _damage;
	int _exp;

	public int _Id
	{
		get{ return _id;}
		set{ _id = value;}
	}
	public Skill _Skill
	{
		get{ return _skill;}
		set{ _skill = value;}
	}
	public int _Level
	{
		get{ return _level;}
		set{ _level = value;}
	}
	public float _ColdTimeEx
	{
		get{ return _coldTimeEx;}
		set{ _coldTimeEx = value;}
	}
	public float _Crtical
	{
		get{ return _crtical;}
		set{ _crtical = value;}
	}
	public float _Damage
	{
		get{ return _damage;}
		set{ _damage = value;}
	}
	public int _Exp
	{
		get{ return _exp;}
		set{ _exp = value;}
	}
}
