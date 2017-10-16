using UnityEngine;
using System.Collections;

public class TaskItemUI : MonoBehaviour {
	UISprite taskTypeSprite;
	UILabel nameLabel;
	UILabel desLabel;
	UISprite reward1Sprite;
	UILabel reward1Label;
	UISprite reward2Sprite;
	UILabel reward2Label;
	UIButton getReward_btn;
	UILabel feats;
	UILabel difficultLabel;

	TaskItem taskitem;

	void Awake()
	{
		taskTypeSprite = transform.Find ("TaskTypeSprite").GetComponent<UISprite> ();
		nameLabel = transform.Find ("NameLabel").GetComponent<UILabel> ();
		desLabel = transform.Find ("DesLabel").GetComponent<UILabel> ();
		reward1Sprite = transform.Find ("Reward1Sprite").GetComponent<UISprite> ();
		reward1Label = transform.Find ("Reward1Label").GetComponent<UILabel> ();
		reward2Sprite = transform.Find ("Reward2Sprite").GetComponent<UISprite> ();
		reward2Label = transform.Find ("Reward2Label").GetComponent<UILabel> ();
		getReward_btn = transform.Find ("GetReward_btn").GetComponent<UIButton> ();
		feats = transform.Find ("Feats").GetComponent<UILabel> ();
		difficultLabel = transform.Find ("DifficultLabel").GetComponent<UILabel> ();
	}
	public void SetTask(TaskItem taskitem)
	{
		this.taskitem = taskitem;
		switch(taskitem._TaskType)
		{
		case TaskType.Main: taskTypeSprite.spriteName ="pic_主线"; break;
		case TaskType.Reward: taskTypeSprite.spriteName ="pic_奖赏";break;
		case TaskType.Daily: taskTypeSprite.spriteName ="pic_日常";break;
		}
		if(taskitem._TaskType == TaskType.Main)
		{
			nameLabel.text = taskitem._Task._Name;
			desLabel.text = taskitem._Task._Des;
			if(taskitem._Task._Coin>0 && taskitem._Task._Diamond>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Task._Coin.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Task._Diamond.ToString();
			}
			else if(taskitem._Task._Coin>0 && taskitem._Task._Mine>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Task._Coin.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Task._Mine.ToString();
			}
			else if(taskitem._Task._Coin>0 && taskitem._Task._Ruby>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Task._Coin.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Task._Ruby.ToString();
			}
			else if(taskitem._Task._Diamond>0 && taskitem._Task._Mine>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Task._Mine.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Task._Diamond.ToString();
			}
			else if(taskitem._Task._Diamond>0 && taskitem._Task._Ruby>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Task._Ruby.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Task._Diamond.ToString();
			}
			else if(taskitem._Task._Mine>0 && taskitem._Task._Ruby>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Task._Ruby.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Task._Mine.ToString();
			}
			else
			{
				reward1Sprite.spriteName = "商城";
				reward1Label.text = "×" +taskitem._Task._Treasure.ToString();
				reward2Sprite.gameObject.SetActive(false);
				reward2Label.gameObject.SetActive(false);
			}
			if(taskitem._TaskProgress == TaskProgress.Complete)
			{
				EnableBtn();
			}
			else
			{
				DisableBtn();
			}
			feats.text = taskitem._Task._Feats.ToString();
			switch(MakePrototypes.GetDifficult(taskitem._Task._Power,MakePrototypes.GetPlayerPower(PlayerInfo._instance)))
			{
			case 0: difficultLabel.text = "error";break;
			case 1: difficultLabel.text = "难度：太简单了";difficultLabel.color = Color.grey;nameLabel.color = Color.grey;break;
			case 2: difficultLabel.text = "难度：相当容易";difficultLabel.color = Color.green;nameLabel.color = Color.green;break;
			case 3: difficultLabel.text = "难度：可以完成";difficultLabel.color = Color.white;nameLabel.color = Color.white;break;
			case 4: difficultLabel.text = "难度：有点吃力";difficultLabel.color = Color.yellow;nameLabel.color = Color.yellow;break;
			case 5: difficultLabel.text = "难度：极度危险";difficultLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);nameLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);break;
			case 6: difficultLabel.text = "难度：必死无疑";difficultLabel.color = Color.red;nameLabel.color = Color.red;break;
			}
			//
		}
		else
		{
			nameLabel.text = taskitem._Name;
			desLabel.text = taskitem._Des;
			if(taskitem._Coin>0 && taskitem._Diamond>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Coin.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Diamond.ToString();
			}
			else if(taskitem._Coin>0 && taskitem._Mine>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Coin.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Mine.ToString();
			}
			else if(taskitem._Coin>0 && taskitem._Ruby>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Coin.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Ruby.ToString();
			}
			else if(taskitem._Diamond>0 && taskitem._Mine>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Mine.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Diamond.ToString();
			}
			else if(taskitem._Diamond>0 && taskitem._Ruby>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Ruby.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Diamond.ToString();
			}
			else if(taskitem._Mine>0 && taskitem._Ruby>0)
			{
				reward1Sprite.spriteName = "金币";
				reward1Label.text = "×" +taskitem._Ruby.ToString();
				reward2Sprite.spriteName = "钻石";
				reward2Label.text = "×" +taskitem._Mine.ToString();
			}
			else
			{
				reward1Sprite.spriteName = "商城";
				reward1Label.text = "×" +taskitem._Treasure.ToString();
				reward2Sprite.gameObject.SetActive(false);
				reward2Label.gameObject.SetActive(false);
			}
			if(taskitem._TaskProgress == TaskProgress.Complete)
			{
				EnableBtn();
			}
			else
			{
				DisableBtn();
			}
			feats.text = taskitem._Feats.ToString();
			switch(MakePrototypes.GetDifficult(taskitem._Power,MakePrototypes.GetPlayerPower(PlayerInfo._instance)))
			{
			case 0: difficultLabel.text = "error";break;
			case 1: difficultLabel.text = "难度：太简单了";difficultLabel.color = Color.grey;nameLabel.color = Color.grey;break;
			case 2: difficultLabel.text = "难度：相当容易";difficultLabel.color = Color.green;nameLabel.color = Color.green;break;
			case 3: difficultLabel.text = "难度：可以完成";difficultLabel.color = Color.white;nameLabel.color = Color.white;break;
			case 4: difficultLabel.text = "难度：有点吃力";difficultLabel.color = Color.yellow;nameLabel.color = Color.yellow;break;
			case 5: difficultLabel.text = "难度：极度危险";difficultLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);nameLabel.color = Color.Lerp(Color.yellow,Color.red,0.5f);break;
			case 6: difficultLabel.text = "难度：必死无疑";difficultLabel.color = Color.red;nameLabel.color = Color.red;break;
			}
		}

	}
	void DisableBtn()
	{
		getReward_btn.SetState (UIButtonColor.State.Disabled, true);
		getReward_btn.GetComponent<Collider>().enabled = false;
	}
	void EnableBtn()
	{
		getReward_btn.SetState (UIButtonColor.State.Normal, true);
		getReward_btn.GetComponent<Collider>().enabled = true;
	}

}
