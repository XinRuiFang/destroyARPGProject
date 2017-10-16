using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class LevelManager : MonoBehaviour {

	public static LevelManager _instance;

	List<Level> levelList;

	public delegate void OnLevelChangeEvent();
	public event OnLevelChangeEvent OnLevelChange;

	public List<Level> LevelList
	{
		get{return levelList;}
		set{ levelList = value;}
	}

	void Awake()
	{
		_instance = this;
		InitLevelQuery ();
	}
	void InitLevelQuery()
	{
		string sql = "select * from ARPG_level";
		StartCoroutine(Client._instance.InitWaitForRequest (sql,delegate(string cb) {
			this.LevelList = InitLevel(Client._instance.SerializationJson(cb));
			OnLevelChange();
		}));
	}
	List<Level> InitLevel(JsonData jd)
	{
		List<Level> levelitem = new List<Level> ();
		for(int i=0;i<jd.Count;i++)
		{
			Level l = new Level();
			l._Id = int.Parse((string)jd[i]["_id"]);
			l._Place = int.Parse((string)jd[i]["_place"]);
			l._Floor = int.Parse((string)jd[i]["_floor"]);
			l._Power = int.Parse((string)jd[i]["_power"]);
			levelitem.Add(l);
		}
		return levelitem;
	}
}
