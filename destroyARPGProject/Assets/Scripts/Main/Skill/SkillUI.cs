using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillUI : MonoBehaviour {

	public static SkillUI _instance;
	UIButton basic;
	UIButton one;
	UIButton two;
	UIButton three;
	UIButton other1;
	UIButton other2;
	UILabel skillName;
	UILabel skillDes;
	UILabel skillDamage;
	UILabel expLabel;
	List<SkillItem> skillitem;
	UIButton close_btn;
	TweenPosition tween;

	void Awake()
	{
		_instance = this;
		SkillManager._instance.OnSkillChange += this.OnSkillChange;
		basic = transform.Find ("SkillContainer/Basic").GetComponent<UIButton> ();
		one = transform.Find ("SkillContainer/One").GetComponent<UIButton> ();
		two = transform.Find ("SkillContainer/Two").GetComponent<UIButton> ();
		three = transform.Find ("SkillContainer/Three").GetComponent<UIButton> ();
		other1 = transform.Find ("SkillContainer/Other1").GetComponent<UIButton> ();
		other2 = transform.Find ("SkillContainer/Other2").GetComponent<UIButton> ();
		skillName = transform.Find ("Sprite/SkillName").GetComponent<UILabel> ();
		skillDes = transform.Find ("Sprite/SkillDes").GetComponent<UILabel> ();
		skillDamage = transform.Find ("Sprite/SkillDamage").GetComponent<UILabel> ();
		expLabel = transform.Find ("ExpLabel").GetComponent<UILabel> ();
		close_btn = transform.Find ("close_btn").GetComponent<UIButton> ();
		tween = this.GetComponent<TweenPosition> ();
		EventDelegate ed = new EventDelegate (this,"OnbasicClick");
		basic.onClick.Add (ed);
		EventDelegate ed1 = new EventDelegate (this,"OnoneClick");
		one.onClick.Add (ed1);
		EventDelegate ed2 = new EventDelegate (this,"OntwoClick");
		two.onClick.Add (ed2);
		EventDelegate ed3 = new EventDelegate (this,"OnthreeClick");
		three.onClick.Add (ed3);
		EventDelegate ed4 = new EventDelegate (this,"Onother1Click");
		other1.onClick.Add (ed4);
		EventDelegate ed5 = new EventDelegate (this,"Onother2Click");
		other2.onClick.Add (ed5);
		EventDelegate ed6 = new EventDelegate(this,"OnClose");
		close_btn.onClick.Add (ed6);
	}
	void OnDestory()
	{
		SkillManager._instance.OnSkillChange -= this.OnSkillChange;
	}
	void OnSkillChange()
	{
		skillitem = SkillManager._instance.SkillItemList;
		foreach(SkillItem si in skillitem)
		{
			if(si._Skill._SkillType == SkillType.Basic)
			{
				skillName.text = "Lv."+si._Level+" "+ si._Skill._Name;
				skillDes.text = si._Skill._Des.ToString();
				skillDamage.text = "伤害值："+(PlayerInfo._instance.Attack*si._Level).ToString()+"  暴击率:" + (si._Crtical*100).ToString() +"%  冷却时间:"+(si._ColdTimeEx * si._Skill._ColdTime).ToString();
				switch(si._Exp)
				{
				case 1:expLabel.text = "初学乍练"; expLabel.color = Color.grey;break;
				case 2:expLabel.text = "似懂非懂"; expLabel.color = Color.white;break;
				case 3:expLabel.text = "渐入佳境"; expLabel.color = Color.yellow;break;
				case 4:expLabel.text = "炉火纯青"; expLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);break;
				case 5:expLabel.text = "个中翘楚"; expLabel.color = Color.red;break;
				}

			}
		}
	}
	void OnbasicClick()
	{
		skillitem = SkillManager._instance.SkillItemList;
		foreach(SkillItem si in skillitem)
		{
			if(si._Skill._SkillType == SkillType.Basic)
			{
				skillName.text = "Lv."+si._Level+" "+ si._Skill._Name;
				skillDes.text = si._Skill._Des;
				skillDamage.text = "伤害值："+(PlayerInfo._instance.Attack*si._Level).ToString()+"  暴击率:" + (si._Crtical*100).ToString() +"%  冷却时间:"+(si._ColdTimeEx * si._Skill._ColdTime).ToString();
				switch(si._Exp)
				{
				case 1:expLabel.text = "初学乍练"; expLabel.color = Color.grey;break;
				case 2:expLabel.text = "似懂非懂"; expLabel.color = Color.white;break;
				case 3:expLabel.text = "渐入佳境"; expLabel.color = Color.yellow;break;
				case 4:expLabel.text = "炉火纯青"; expLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);break;
				case 5:expLabel.text = "个中翘楚"; expLabel.color = Color.red;break;
				}
				
			}
		}
	}
	void OnoneClick()
	{
		skillitem = SkillManager._instance.SkillItemList;
		foreach(SkillItem si in skillitem)
		{
			if(si._Skill._Id == 2)
			{
				skillName.text = "Lv."+si._Level+" "+ si._Skill._Name;
				skillDes.text = si._Skill._Des;
				skillDamage.text = "伤害值："+(PlayerInfo._instance.Attack*si._Level).ToString()+"  暴击率:" + (si._Crtical*100).ToString() +"%  冷却时间:"+(si._ColdTimeEx * si._Skill._ColdTime).ToString();
				switch(si._Exp)
				{
				case 1:expLabel.text = "初学乍练"; expLabel.color = Color.grey;break;
				case 2:expLabel.text = "似懂非懂"; expLabel.color = Color.white;break;
				case 3:expLabel.text = "渐入佳境"; expLabel.color = Color.yellow;break;
				case 4:expLabel.text = "炉火纯青"; expLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);break;
				case 5:expLabel.text = "个中翘楚"; expLabel.color = Color.red;break;
				}
				
			}
		}
	}
	void OntwoClick()
	{
		skillitem = SkillManager._instance.SkillItemList;
		foreach(SkillItem si in skillitem)
		{
			if(si._Skill._Id == 3)
			{
				skillName.text = "Lv."+si._Level+" "+ si._Skill._Name;
				skillDes.text = si._Skill._Des;
				skillDamage.text = "伤害值："+(PlayerInfo._instance.Attack*si._Level).ToString()+"  暴击率:" + (si._Crtical*100).ToString() +"%  冷却时间:"+(si._ColdTimeEx * si._Skill._ColdTime).ToString();
				switch(si._Exp)
				{
				case 1:expLabel.text = "初学乍练"; expLabel.color = Color.grey;break;
				case 2:expLabel.text = "似懂非懂"; expLabel.color = Color.white;break;
				case 3:expLabel.text = "渐入佳境"; expLabel.color = Color.yellow;break;
				case 4:expLabel.text = "炉火纯青"; expLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);break;
				case 5:expLabel.text = "个中翘楚"; expLabel.color = Color.red;break;
				}
				
			}
		}
	}
	void OnthreeClick()
	{
		skillitem = SkillManager._instance.SkillItemList;
		foreach(SkillItem si in skillitem)
		{
			if(si._Skill._Id == 4)
			{
				skillName.text = "Lv."+si._Level+" "+ si._Skill._Name;
				skillDes.text = si._Skill._Des;
				skillDamage.text = "伤害值："+(PlayerInfo._instance.Attack*si._Level).ToString()+"  暴击率:" + (si._Crtical*100).ToString() +"%  冷却时间:"+(si._ColdTimeEx * si._Skill._ColdTime).ToString();
				switch(si._Exp)
				{
				case 1:expLabel.text = "初学乍练"; expLabel.color = Color.grey;break;
				case 2:expLabel.text = "似懂非懂"; expLabel.color = Color.white;break;
				case 3:expLabel.text = "渐入佳境"; expLabel.color = Color.yellow;break;
				case 4:expLabel.text = "炉火纯青"; expLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);break;
				case 5:expLabel.text = "个中翘楚"; expLabel.color = Color.red;break;
				}
				
			}
		}
	}
	void Onother1Click()
	{
		skillitem = SkillManager._instance.SkillItemList;
		foreach(SkillItem si in skillitem)
		{
			if(si._Skill._Id == 5)
			{
				skillName.text = "Lv."+si._Level+" "+ si._Skill._Name;
				skillDes.text = si._Skill._Des;
				skillDamage.text = "伤害值："+(PlayerInfo._instance.Attack*si._Level).ToString()+"  触发几率:" + (si._Crtical*100).ToString() +"% ";
				switch(si._Exp)
				{
				case 1:expLabel.text = "初学乍练"; expLabel.color = Color.grey;break;
				case 2:expLabel.text = "似懂非懂"; expLabel.color = Color.white;break;
				case 3:expLabel.text = "渐入佳境"; expLabel.color = Color.yellow;break;
				case 4:expLabel.text = "炉火纯青"; expLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);break;
				case 5:expLabel.text = "个中翘楚"; expLabel.color = Color.red;break;
				}
				
			}
		}
	}
	void Onother2Click()
	{
		skillitem = SkillManager._instance.SkillItemList;
		foreach(SkillItem si in skillitem)
		{
			if(si._Skill._Id == 6)
			{
				skillName.text = "Lv."+si._Level+" "+ si._Skill._Name;
				skillDes.text = si._Skill._Des;
				skillDamage.text = "伤害值："+(PlayerInfo._instance.Attack*si._Level).ToString()+"  触发几率:" + (si._Crtical*100).ToString() +"% ";
				switch(si._Exp)
				{
				case 1:expLabel.text = "初学乍练"; expLabel.color = Color.grey;break;
				case 2:expLabel.text = "似懂非懂"; expLabel.color = Color.white;break;
				case 3:expLabel.text = "渐入佳境"; expLabel.color = Color.yellow;break;
				case 4:expLabel.text = "炉火纯青"; expLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);break;
				case 5:expLabel.text = "个中翘楚"; expLabel.color = Color.red;break;
				}
				
			}
		}
	}
	public void Show()
	{
		tween.PlayForward ();
	}
	public void Hide()
	{
		tween.PlayReverse ();
	}
	void OnClose()
	{
		Hide ();
	}
}
