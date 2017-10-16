using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Npc_girl : MonoBehaviour {

	int taskId = 0;
	TaskProgress progress;

	List<string> GetTaskStatus()
	{
		List<TaskItem> taskItemList = TaskManager._instance.TaskItemList;

		List<string> talk =new List<string>();
		foreach(TaskItem ti in taskItemList)
		{
			if(ti._TaskType == TaskType.Main)
			{
				this.taskId = ti._Task._Id;
				this.progress = ti._TaskProgress;
			}
		}
		if(taskId == 0)
		{
			talk[0] = "欢迎你，新手!";
		}
		else
		{
			switch(this.progress)
			{
			//case TaskProgress.NoStart:  break;
			case TaskProgress.Accept:talk[0]="你不去做任务，看我干什么!" ;break;
			case TaskProgress.Complete:talk[0]="干什么呢，快领取奖励!"; break;
			case TaskProgress.Reward:talk= GetTaskTalk(this.taskId); break;
			}
		}
		return talk;
	}

	List<string> GetTaskTalk(int taskId)
	{
		taskId++;
		List<string> talk = new List<string>();
		switch(taskId)
		{
		case 1: talk.Add ("mession 1");  talk.Add ("nisidii");  break;
		case 2: talk.Add ( "mession 2");  talk.Add ("nisidii");talk.Add ("hhisidii2"); break;
		case 3: talk.Add ( "mession 3");  talk.Add ("nisidii");break;
		case 4: talk.Add ( "mession 4");  talk.Add ("nisidii");break;
		case 5: talk.Add ( "mession 5");  talk.Add ("nisidii");break;
		case 6: talk.Add ( "mession 6"); talk.Add ("nisidii");break;
		}
		return talk;
	}

	void OnCollisionEnter( Collision collisionInfo )  
	{
		Vector3 v3 = collisionInfo.transform.forward;
		if(v3.x>0)
		{
			v3.x = v3.x-180;
		}
		else
		{
			v3.x = v3.x + 180;
		}
		this.transform.LookAt (v3);
		ShowTalk (GetTaskStatus(),collisionInfo.gameObject);
		PlayerVillageMove._instance.Stop ();
		collisionInfo.gameObject.GetComponent<PlayerVillageMove> ().enabled = false;

	}
	void ShowTalk(List<string> strArray,GameObject player)
	{
		NpcDialogUI._instance.Show (strArray,player);
	}
}
