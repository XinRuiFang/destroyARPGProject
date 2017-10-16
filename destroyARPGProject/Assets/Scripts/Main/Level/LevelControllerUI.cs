using UnityEngine;
using System.Collections;

public class LevelControllerUI : MonoBehaviour {

	public static LevelControllerUI _instance;
	GameObject completeSign;
	UILabel numberLabel;
	UILabel powerLabel;
	UILabel difficultLabel;
	UIButton levelbtn;

	Level level;


	void Awake()
	{
		_instance = this;
		completeSign = transform.Find ("LevelUI/if_completeSprite").gameObject;
		numberLabel = transform.Find ("LevelUI/numberLabel").GetComponent<UILabel> ();
		powerLabel = transform.Find ("LevelUI/powerLabel").GetComponent<UILabel> ();
		difficultLabel = transform.Find ("LevelUI/difficultLabel").GetComponent<UILabel> ();
		levelbtn = transform.Find ("LevelUI").GetComponent<UIButton> ();
		//EventDelegate ed = new EventDelegate(this,"");
		//levelbtn.onClick.Add (ed);
	}
	public void SetLevel(Level level)
	{
		this.level = level;
		if(level._Id>PlayerInfo._instance._Transcript)
		{
			completeSign.SetActive(false);
			levelbtn.SetState (UIButtonColor.State.Disabled, true);
			levelbtn.GetComponent<Collider>().enabled = false;
		}
		else if(level._Id == PlayerInfo._instance._Transcript)
		{
			completeSign.SetActive(false);
		}
		else
		{
			completeSign.SetActive(true);
		}
		numberLabel.text = "第  " + level._Floor + "  层";
		powerLabel.text = "敌人战斗力：" +level._Power.ToString ();
		switch(MakePrototypes.GetDifficult(level._Power,MakePrototypes.GetPlayerPower(PlayerInfo._instance)))
		{
		case 0: difficultLabel.text = "error";break;
		case 1: difficultLabel.text = "难度：太简单了";difficultLabel.color = Color.grey;numberLabel.color = Color.grey;break;
		case 2: difficultLabel.text = "难度：相当容易";difficultLabel.color = Color.green;numberLabel.color = Color.green;break;
		case 3: difficultLabel.text = "难度：可以完成";difficultLabel.color = Color.white;numberLabel.color = Color.white;break;
		case 4: difficultLabel.text = "难度：有点吃力";difficultLabel.color = Color.yellow;numberLabel.color = Color.yellow;break;
		case 5: difficultLabel.text = "难度：极度危险";difficultLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);numberLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);break;
		case 6: difficultLabel.text = "难度：必死无疑";difficultLabel.color = Color.red;numberLabel.color = Color.red;break;
		}
	}

}
