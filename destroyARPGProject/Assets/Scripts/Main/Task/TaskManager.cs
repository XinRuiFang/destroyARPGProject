using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour {

	public static TaskManager _instance;
	Dictionary<int,Task> taskList;
	List<TaskItem> taskItemList;

	public delegate void OnTaskChangeEvent();
	public event OnTaskChangeEvent OnTaskChange;

	public Dictionary<int,Task> TaskList
	{
		get{return taskList;}
		set{ taskList = value;}
	}
	public List<TaskItem> TaskItemList
	{
		get{return taskItemList;}
		set{ taskItemList = value;}
	}
	void Awake()
	{
		_instance = this;
		ReadTaskInfo ();

	}
	void ReadTaskInfo()
	{
		InitTaskQuery ();
	}
	void InitTaskQuery()
	{
		string sql = "select * from ARPG_task";
		StartCoroutine(Client._instance.InitWaitForRequest (sql,delegate(string cb) {
			this.TaskList = InitTask(Client._instance.SerializationJson(cb));
			ReadTaskItemInfo ();
		}));
	}
	void ReadTaskItemInfo()
	{
		InitTaskItemQuery ();
	}
	void InitTaskItemQuery()
	{
		string sql = "select * from ARPG_taskItem where _ownName='"+PlayerInfo._instance._Name+"'";
		StartCoroutine (Client._instance.InitWaitForRequest (sql, delegate(string cb) {
			this.TaskItemList = InitTaskItem (Client._instance.SerializationJson (cb));
			OnTaskChange();
		}));
	}
	List<TaskItem> InitTaskItem(JsonData jd)
	{
		List<TaskItem> taskitem = new List<TaskItem> ();
		for(int i=0;i<jd.Count;i++)
		{
			TaskItem ti = new TaskItem();
			ti._Id = int.Parse((string)jd[i]["_id"]);
			int id;
			if(jd[i]["_task"]==null)
			{
				id = 0;
			}
			else
			{
				id = int.Parse((string)jd[i]["_task"]);
			} 
			Task t = null;
			if(taskList.TryGetValue(id,out t))
			{
				ti._Task = MakeNewTask(t);
			}
			switch((string)jd[i]["_taskProgress"])
			{
			case "Accept":
				ti._TaskProgress = TaskProgress.Accept;
				break;
			case "Complete":
				ti._TaskProgress = TaskProgress.Complete;
				break;
			case "NoStart":
				ti._TaskProgress = TaskProgress.NoStart;
				break;
			case "Reward":
				ti._TaskProgress = TaskProgress.Reward;
				break;
			}
			switch((string)jd[i]["_taskType"])
			{
			case "Main":
				ti._TaskType = TaskType.Main;
				break;
			case "Reward":
				ti._TaskType = TaskType.Reward;
				break;
			case "Daily":
				ti._TaskType = TaskType.Daily;
				break;
			}
			ti._IdTranscript = int.Parse((string)jd[i]["_idTranscript"]);
			ti._OwnName = (string)jd[i]["_ownName"];
			if(id == 0)
			{
				ti._Name = (string)jd[i]["_name"];
				ti._Des = (string)jd[i]["_des"];
				ti._Coin = int.Parse((string)jd[i]["_coin"]);
				ti._Diamond = int.Parse((string)jd[i]["_diamond"]);
				ti._Mine = int.Parse((string)jd[i]["_mine"]);
				ti._Ruby = int.Parse((string)jd[i]["_ruby"]);
				ti._Treasure = int.Parse((string)jd[i]["_treasure"]);
				ti._Power = int.Parse((string)jd[i]["_power"]);
				ti._Feats = int.Parse((string)jd[i]["_feats"]);
			}
			taskitem.Add(ti);
		}
		return taskitem;
	}
	Dictionary<int,Task> InitTask(JsonData jd)
	{
		Dictionary<int,Task> taskDic = new Dictionary<int, Task> ();
		for(int i= 0;i<jd.Count;i++)
		{
			Task task = new Task();
			task._Id = int.Parse((string)jd[i]["_id"]);
			switch((string)jd[i]["_taskType"])
			{
			case "Main":
				task._TaskType = TaskType.Main;
				break;
			case "Reward":
				task._TaskType = TaskType.Reward;
				break;
			case "Daily":
				task._TaskType = TaskType.Daily;
				break;
			}
			task._Name = (string)jd[i]["_name"];
			task._Des = (string)jd[i]["_des"];
			task._Coin = int.Parse((string)jd[i]["_coin"]);
			task._Diamond = int.Parse((string)jd[i]["_diamond"]);
			task._TalkNpc = (string)jd[i]["_talkNpc"];
			task._IdNpc = int.Parse((string)jd[i]["_idNpc"]);
			task._IdTranscript = int.Parse((string)jd[i]["_idTranscript"]);
			task._Ruby = int.Parse((string)jd[i]["_ruby"]);
			task._Mine = int.Parse((string)jd[i]["_mine"]);
			task._Power = int.Parse((string)jd[i]["_power"]);
			task._Treasure = int.Parse((string)jd[i]["_treasure"]);
			task._Feats = int.Parse((string)jd[i]["_feats"]);
			taskDic.Add(task._Id,task);
		}
		return taskDic;
	}
	Task MakeNewTask(Task t)
	{
		Task t2 = new Task ();
		t2._Id = t._Id;
		t2._Coin = t._Coin;
		t2._Des = t._Des;
		t2._Diamond = t._Diamond;
		t2._Feats = t._Feats;
		t2._Icon = t._Icon;
		t2._IdNpc = t._IdNpc;
		t2._IdTranscript = t._IdTranscript;
		t2._Mine = t._Mine;
		t2._Name = t._Name;
		t2._Power = t._Power;
		t2._Ruby = t._Ruby;
		t2._TalkNpc = t._TalkNpc;
		t2._TaskType = t._TaskType;
		t2._Treasure = t._Treasure;
		return t2;
	}
}
