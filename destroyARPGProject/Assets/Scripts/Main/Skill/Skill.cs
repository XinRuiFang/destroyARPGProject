using UnityEngine;
using System.Collections;

public enum SkillType
{
	Basic,
	Skill
}
public enum PosType
{
	Basic,
	One = 1,
	Two = 2,
	Three = 3,
	Other
}
public class Skill  {
	int _id;
	string _name;
	string _icon;
	SkillType _skillType;
	PosType _posType;
	float _coldTime;
	string _des;
	public int _Id
	{
		get{ return _id;}
		set{ _id = value;}
	}
	public string _Name
	{
		get{ return _name;}
		set{ _name = value;}
	}
	public string _Icon
	{
		get{ return _icon;}
		set{ _icon = value;}
	}
	public SkillType _SkillType
	{
		get{ return _skillType;}
		set{ _skillType = value;}
	}
	public PosType _PosType
	{
		get{ return _posType;}
		set{ _posType = value;}
	}
	public float _ColdTime
	{
		get{ return _coldTime;}
		set{ _coldTime = value;}
	}
	public string _Des
	{
		get{ return _des;}
		set{ _des = value;}
	}

}
