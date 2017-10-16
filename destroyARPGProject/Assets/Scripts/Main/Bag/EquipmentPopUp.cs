using UnityEngine;
using System.Collections;

public class EquipmentPopUp : MonoBehaviour {
	InventoryItem it;
	InventoryItemUI itUI;
	BagRoleEquip bre;

	UISprite pic_equip;
	UILabel _name;
	UILabel describe;
	UILabel level;
	UILabel proto;
	UILabel powerLabel;
	UILabel feats;
	UIButton qianghua_btn;
	UIButton duanzao_btn;
	UIButton dress_btn;
	UIButton close_btn;
	UILabel btnLabel;

	bool isLeft = true; 

	void Awake()
	{
		pic_equip = transform.Find ("equip/pic_equip/Sprite").GetComponent<UISprite> ();
		_name = transform.Find ("equip/name").GetComponent<UILabel> ();
		describe = transform.Find ("equip/describe").GetComponent<UILabel> ();
		level = transform.Find ("equip/level").GetComponent<UILabel> ();
		proto = transform.Find ("equip/proto").GetComponent<UILabel> ();
		powerLabel = transform.Find ("equip/powerLabel").GetComponent<UILabel> ();
		feats = transform.Find ("equip/feats").GetComponent<UILabel> ();
		qianghua_btn = transform.Find ("equip/qianghua_btn").GetComponent<UIButton> ();
		duanzao_btn = transform.Find ("equip/duanzao_btn").GetComponent<UIButton> ();
		dress_btn = transform.Find ("equip/dress_btn").GetComponent<UIButton> ();
		close_btn = transform.Find ("equip/close_btn").GetComponent<UIButton> ();
		btnLabel = transform.Find ("equip/dress_btn/Label").GetComponent<UILabel> ();
		qianghua_btn = transform.Find ("equip/qianghua_btn").GetComponent<UIButton> ();
		duanzao_btn = transform.Find ("equip/duanzao_btn").GetComponent<UIButton> ();
	
		EventDelegate ed1 = new EventDelegate (this,"OnClose");
		close_btn.onClick.Add (ed1);
		EventDelegate ed2 = new EventDelegate (this,"OnDress");
		dress_btn.onClick.Add (ed2);
		EventDelegate ed3 = new EventDelegate (this,"OnQiangHua");
		qianghua_btn.onClick.Add (ed3);
		EventDelegate ed4 = new EventDelegate (this,"OnDuanZao");
		duanzao_btn.onClick.Add (ed4);
	}

	public void Show(InventoryItem it,InventoryItemUI itUI,BagRoleEquip bre, bool isLeft = true)
	{
		gameObject.SetActive(true);
		this.it = it;
		this.itUI = itUI;
		this.bre = bre;
		Vector3 pos = transform.localPosition;
		this.isLeft = isLeft;
		if (isLeft) {
			transform.localPosition = new Vector3(-Mathf.Abs(pos.x),pos.y,pos.z);
			btnLabel.text = "装备";
		}
		else
		{
			transform.localPosition = new Vector3(Mathf.Abs(pos.x),pos.y,pos.z);
			btnLabel.text = "卸下";
		}
		pic_equip.spriteName = it._Item._Headpic.ToString();
		describe.text = it._Item._Describe.ToString();
		string _level;
		string _levelName = "";
		//float expEx = 1;
		if (0 < it._Exp && it._Exp < 300) 
		{
			_level = "F";
			_levelName = "损坏的";
			_name.color = Color.gray;
			//expEx += 0.0f;
		}
		else if(300 <= it._Exp && it._Exp <500)
		{
			_level = "E";
			_levelName = "破旧的";
			_name.color = Color.grey;
			//expEx += 0.1f;
		}
		else if(500<=it._Exp && it._Exp <700)
		{
			_level = "D";
			_levelName = "二手的";
			_name.color = Color.white;
			//expEx += 0.2f;
		}
		else if(700 <= it._Exp && it._Exp < 1000)
		{
			_level = "C";
			_levelName = "普通的";
			_name.color = Color.green;
			//expEx += 0.35f;
		}
		else if(1000 <= it._Exp && it._Exp<1600)
		{
			_level = "B";
			_levelName = "崭新的";
			_name.color = Color.cyan;
			//expEx += 0.5f;
		}
		else if(1600<= it._Exp && it._Exp<2200)
		{
			_level = "A";
			_levelName = "高级的";
			_name.color = Color.blue;
			//expEx += 0.7f;
		}
		else if(2200<= it._Exp && it._Exp < 3000)
		{
			_level = "S";
			_levelName = "极品的";
			_name.color = Color.yellow;
			//expEx += 0.9f;
		}
		else if(3000<= it._Exp && it._Exp < 4000)
		{
			_level = "SS";
			_levelName = "卓越的";
			_name.color = Color.magenta;
			//expEx += 1.2f;
		}
		else if(4000<=it._Exp && it._Exp< 6000)
		{
			_level = "SSS";
			_levelName = "史诗的";
			_name.color = Color.red;
			//expEx += 1.6f;
		}
		else if(6000<=it._Exp )
		{
			_level = "Z";
			_levelName = "泰斗的";
			_name.color = Color.Lerp(Color.yellow,Color.red,0.5f);
			//expEx += 2.0f;
		}
		else
		{
			_level = "F";
			if(it._Item._InventoryType != InventoryType.Equip)
			{
				_name.color = Color.white;
			}
			else
			{
				_levelName = "损坏的";
				_name.color = Color.gray;
			}
			//expEx += 0.0f;
		}
		level.text = _level.ToString();
		if(it._Item._InventoryType == InventoryType.Equip)
		{
			_name.text = "+"+ it._Strengthen.ToString() +  " " + _levelName + " " + it._Item._Name.ToString();
		}
		else
		{
			_name.text = it._Item._Name.ToString();
		}
		MakePrototypes.MakeEquipProto(it,InventoryManager._instance.inventoryDic);
		proto.text =  "\n攻击力:"+ it.Attack + "\n" + "\n防御力:" +  it.Defence + "\n"
			+ "\n生命值:" + it.Health + "\n" + "\n抗性:" + it.Resistance + "\n"
				+ "\n生命恢复:" + it.HealthCover + "\n";
		powerLabel.text = MakePrototypes.GetEquipPower(it).ToString();
		feats.text = it._Feats.ToString ();

	}
	public void OnClose()
	{
		Close ();
		transform.parent.SendMessage ("DisableBtn");
	}

	public void OnDress()
	{
		if(isLeft)
		{
			itUI.Clear ();
			PlayerInfo._instance.DressOn (it);
		}
		else
		{
			bre.Clear();
			PlayerInfo._instance.DressOff (it);
		}

		InventoryUI._instance.SendMessage("UpdateCount");
		OnClose ();
	}
	void ClearObj()
	{
		it = null;
		itUI = null;
	}
	public void Close()
	{
		ClearObj ();
		gameObject.SetActive (false);
	}
	public void OnQiangHua()
	{
		//memcache?
		if(PlayerInfo._instance._Ruby>=it._Strengthen)
		{
			int f = Random.Range (0,100);
			float strength;
			if(it._Strengthen!=0)
			{
				strength = 100/it._Strengthen;
			}
			else
			{
				strength = 100;
			}


			if(f < System.Convert.ToInt32(strength))
			{
				PlayerInfo._instance._Ruby -= it._Strengthen;
				MsgManager._instance.ShowMsg("强化成功!消耗晶石:"+it._Strengthen.ToString ()+"个 剩余:"+PlayerInfo._instance._Ruby.ToString(),2f);
				it._Strengthen++;

				//it = EquipStatus.MakeEquipStatu(it);
				string sqlquery = "update ARPG_inventoryItem set _strengthen="+it._Strengthen+" where _Id='"+it._Id+"'";
				StartCoroutine (Client._instance.InitWaitForRequest (sqlquery, delegate(string cb) {
					
				}));
				Show(this.it,this.itUI,this.bre,this.isLeft);
				
			}
			else
			{
				PlayerInfo._instance._Ruby -= it._Strengthen;
				int f2 = Random.Range(0,100);
				if((it._Strengthen<=10 && f2 < 1)||(it._Strengthen > 10 && f2 < 5))
				{
					MsgManager._instance.ShowMsg("强化失败,强化等级-1!消耗晶石:"+it._Strengthen.ToString ()+"个 剩余:"+PlayerInfo._instance._Ruby.ToString(),2f);
					//MsgManager._instance.ShowMsg("强化失败的装备破损了,强化等级-1",2f);
					it._Strengthen--;
					//it = EquipStatus.MakeEquipStatu(it);
					string sqlquery = "update ARPG_inventoryItem set _strengthen="+it._Strengthen+" where _Id='"+it._Id+"'";
					StartCoroutine (Client._instance.InitWaitForRequest (sqlquery, delegate(string cb) {
						
					}));
					Show(this.it,this.itUI,this.bre,this.isLeft);
				}
				else
				{
					MsgManager._instance.ShowMsg("强化失败!消耗晶石:"+it._Strengthen.ToString ()+"个 剩余:"+PlayerInfo._instance._Ruby.ToString(),2f);
				}
			}
			string sql = "update ARPG_playerInfo set _Ruby="+PlayerInfo._instance._Ruby+" where _Name='"+PlayerInfo._instance._Name+"'";
			StartCoroutine (Client._instance.InitWaitForRequest (sql, delegate(string cb) {
				
			}));
		}
		else
		{
			MsgManager._instance.ShowMsg ("此次强化需要晶石" + it._Strengthen.ToString () + "个", 3f);
		}
	}
	public void OnDuanZao()
	{
		string _level;
		if (0 < it._Exp && it._Exp < 300) 
		{
			_level = "F";
		}
		else if(300 <= it._Exp && it._Exp <500)
		{
			_level = "E";
		}
		else if(500<=it._Exp && it._Exp <700)
		{
			_level = "D";
		}
		else if(700 <= it._Exp && it._Exp < 1000)
		{
			_level = "C";
		}
		else if(1000 <= it._Exp && it._Exp<1600)
		{
			_level = "B";
		}
		else if(1600<= it._Exp && it._Exp<2200)
		{
			_level = "A";
		}
		else if(2200<= it._Exp && it._Exp < 3000)
		{
			_level = "S";
		}
		else if(3000<= it._Exp && it._Exp < 4000)
		{
			_level = "SS";
		}
		else if(4000<=it._Exp && it._Exp< 6000)
		{
			_level = "SSS";
		}
		else if(6000<=it._Exp )
		{
			_level = "Z";
		}
		else
		{
			_level = "F";
		}
		switch(_level)
		{
		case "F": MsgManager._instance.ShowMsg("需要等级为E的装备锻造劵!",2f); break;
		case "E": MsgManager._instance.ShowMsg("需要等级为D的装备锻造劵!",2f); break;
		case "D": MsgManager._instance.ShowMsg("需要等级为C的装备锻造劵!",2f); break;
		case "C": MsgManager._instance.ShowMsg("需要等级为B的装备锻造劵!",2f); break;
		case "B": MsgManager._instance.ShowMsg("需要等级为A的装备锻造劵!",2f); break;
		case "A": MsgManager._instance.ShowMsg("需要等级为S的装备锻造劵!",2f); break;
		case "S": MsgManager._instance.ShowMsg("锻造等级已满！",2f); break;//
		case "SS": MsgManager._instance.ShowMsg("你的装备已经通灵了，无法锻造",2f); break;
		case "SSS": MsgManager._instance.ShowMsg("你的装备已经通灵了，无法锻造",2f); break;
		case "Z": MsgManager._instance.ShowMsg("需要等级为F的装备锻造劵!可是你想降到最低级吗?",2f); break;
		}
	}
}
















