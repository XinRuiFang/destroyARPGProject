using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class SkillManager : MonoBehaviour {

	public static SkillManager _instance;

	
	public Dictionary<int,Skill> skillDic;
	public List<SkillItem> skillItemList;	
	
	public delegate void OnSkillChangeEvent();
	public event OnSkillChangeEvent OnSkillChange;

	
	public Dictionary<int,Skill> SkillDic
	{
		get{return skillDic;}
		set{ skillDic = value;}
	}
	public List<SkillItem> SkillItemList
	{
		get{return skillItemList;}
		set{ skillItemList = value;}
	}
	void Awake()
	{
		_instance = this;
		ReadSkillInfo ();
		
	}
	void ReadSkillInfo()
	{
		InitSkillQuery ();
	}
	void InitSkillQuery()
	{
		string sql = "select * from ARPG_skill";
		StartCoroutine(Client._instance.InitWaitForRequest (sql,delegate(string cb) {
			this.SkillDic = InitSkill(Client._instance.SerializationJson(cb));
			ReadSkillItemInfo ();
		}));
	}
	void ReadSkillItemInfo()
	{
		InitSkillItemQuery ();
	}
	void InitSkillItemQuery()
	{
		string sql = "select * from ARPG_skillItem where _ownName='"+PlayerInfo._instance._Name+"'";
		StartCoroutine (Client._instance.InitWaitForRequest (sql, delegate(string cb) {
			this.SkillItemList = InitSkillItem (Client._instance.SerializationJson (cb));
			OnSkillChange();
		}));
	}
	Dictionary<int,Skill> InitSkill(JsonData jd)
	{
		Dictionary<int,Skill> skillList = new Dictionary<int, Skill> ();
		for(int i= 0;i<jd.Count;i++)
		{
			Skill sk = new Skill();
			sk._Id = int.Parse((string)jd[i]["_id"]);
			sk._Name = (string)jd[i]["_name"];
			sk._Icon = (string)jd[i]["_icon"];
			switch((string)jd[i]["_skillType"])
			{
			case "Basic" : sk._SkillType = SkillType.Basic; break;
			case "Skill" : sk._SkillType = SkillType.Skill;break;
			}
			switch((string)jd[i]["_posType"])
			{
			case "Basic" : sk._PosType = PosType.Basic;break;
			case "One" : sk._PosType = PosType.One;break;
			case "Two" : sk._PosType = PosType.Two;break;
			case "Three" : sk._PosType = PosType.Three;break;
			case "Other": sk._PosType = PosType.Other;break;
			}
			sk._ColdTime = float.Parse((string)jd[i]["_coldTime"]);
			sk._Des = (string)jd[i]["_des"];
			skillList.Add(sk._Id,sk);
		}
		return skillList;
	}
	List<SkillItem> InitSkillItem(JsonData jd)
	{
		List<SkillItem> skillItem = new List<SkillItem> ();
		for(int i=0;i<jd.Count;i++)
		{
			SkillItem si = new SkillItem();
			si._Id = int.Parse((string)jd[i]["_id"]);
			Skill s = null;
			int id = int.Parse((string)jd[i]["_skill"]);
			this.SkillDic.TryGetValue(id,out s);
			si._Skill = MakeNewSkill(s);
			si._Level = int.Parse((string)jd[i]["_level"]);
			si._ColdTimeEx = float.Parse((string)jd[i]["_coldTimeEx"]);
			si._Crtical = float.Parse((string)jd[i]["_crtical"]);
			si._Exp = int.Parse((string)jd[i]["_exp"]);
			skillItem.Add(si);
		}
		return skillItem;
	}
	Skill MakeNewSkill(Skill s)
	{
		Skill s2 = new Skill ();
		s2._Id = s._Id;
		s2._ColdTime = s._ColdTime;
		s2._Icon = s._Icon;
		s2._Name = s._Name;
		s2._PosType = s._PosType;
		s2._SkillType = s._SkillType;
		s2._Des = s._Des;
		return s2;
	}
}
