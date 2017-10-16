using UnityEngine;
using System.Collections;


public enum TaskProgress
{
	NoStart,
	Accept,
	Complete,
	Reward
}

public class TaskItem {
	int _id;
	Task _task;
	TaskProgress _taskProgress;
	TaskType _taskType;
	int _idTranscript;
	string _ownName;
	string _name;
	string _des;
	int _coin;
	int _diamond;
	int _mine;
	int _ruby;
	int _treasure;
	int _power;
	int _feats;

	public int _Id
	{
		get{return _id;}
		set{ _id = value;}
	}
	public Task _Task
	{
		get{return _task;}
		set{ _task = value;}
	}
	public TaskType _TaskType
	{
		get{return _taskType;}
		set{ _taskType = value;}
	}
	public TaskProgress _TaskProgress
	{
		get{return _taskProgress;}
		set{ _taskProgress = value;}
	}
	public int _IdTranscript
	{
		get{return _idTranscript;}
		set{ _idTranscript = value;}
	}
	public string _OwnName
	{
		get{return _ownName;}
		set{ _ownName = value;}
	}
	public string _Name
	{
		get{return _name;}
		set{ _name = value;}
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
	public int _Mine
	{
		get{return _mine;}
		set{ _mine = value;}
	}
	public int _Ruby
	{
		get{return _ruby;}
		set{ _ruby = value;}
	}
	public int _Treasure
	{
		get{return _treasure;}
		set{ _treasure = value;}
	}
	public int _Power
	{
		get{return _power;}
		set{ _power = value;}
	}
	public int _Feats
	{
		get{return _feats;}
		set{ _feats = value;}
	}
}
