using UnityEngine;
using System.Collections;

public enum TaskType
{
	Main,
	Reward,
	Daily
}

public class Task {
	int _id;
	TaskType _taskType;
	string _name;
	string _icon;
	string _des;
	int _coin;
	int _diamond;
	string _talkNpc;
	int _idNpc;
	int _idTranscript;//fuben id
	//TaskProgress _taskProgress = TaskProgress.NoStart;
	int _ruby;
	int _mine;
	int _power;
	int _treasure;
	int _feats;
	public int _Id
	{
		get{return _id;}
		set{ _id = value;}
	}
	public TaskType _TaskType
	{
		get{return _taskType;}
		set{ _taskType = value;}
	}
	public string _Name
	{
		get{return _name;}
		set{ _name = value;}
	}
	public string _Icon
	{
		get{return _icon;}
		set{ _icon = value;}
	}
	public string _Des
	{
		get{return _des;}
		set{ _des = value;}
	}
	public int _Coin
	{
		get{return _coin;}
		set{ _coin = value;}
	}
	public int _Diamond
	{
		get{return _diamond;}
		set{ _diamond = value;}
	}
	public string _TalkNpc
	{
		get{return _talkNpc;}
		set{ _talkNpc = value;}
	}
	public int _IdNpc
	{
		get{return _idNpc;}
		set{ _idNpc = value;}
	}
	public int _IdTranscript
	{
		get{return _idTranscript;}
		set{ _idTranscript = value;}
	}
	//public TaskProgress _TaskProgress
	//{
	//	get{return _taskProgress;}
	//	set{ _taskProgress = value;}
	//}
	public int _Ruby
	{
		get{return _ruby;}
		set{ _ruby = value;}
	}
	public int _Mine
	{
		get{return _mine;}
		set{ _mine = value;}
	}
	public int _Power
	{
		get{return _power;}
		set{_power = value;}
	}
	public int _Treasure
	{
		get{return _treasure;}
		set{_treasure = value;}
	}
	public int _Feats
	{
		get{return _feats;}
		set{_feats=value;}
	}
}
