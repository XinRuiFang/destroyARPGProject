using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskUI : MonoBehaviour {

	public static TaskUI _instance;
	UIGrid taskListGrid;
	List<TaskItem> taskList;
	TweenPosition tween;
	UIButton close_btn;

	public GameObject taskItemPrefab;
	void Awake()
	{
		_instance = this;
		taskListGrid = transform.Find ("Scroll View/Grid").GetComponent<UIGrid> ();
		TaskManager._instance.OnTaskChange += this.OnTaskChange;
		tween = this.GetComponent<TweenPosition> ();
		close_btn = transform.Find ("close_btn").GetComponent<UIButton> ();

		EventDelegate ed = new EventDelegate(this,"OnClose");
		close_btn.onClick.Add (ed);
	}
	void OnTaskChange()
	{
		taskList = TaskManager._instance.TaskItemList;
		foreach(TaskItem ti in taskList)
		{
			GameObject go = NGUITools.AddChild(taskListGrid.gameObject,taskItemPrefab);
			taskListGrid.AddChild(go.transform);
			TaskItemUI t = go.GetComponent<TaskItemUI>();
			t.SetTask(ti);
		}
	}
	void OnDestory()
	{
		TaskManager._instance.OnTaskChange -= this.OnTaskChange;
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
