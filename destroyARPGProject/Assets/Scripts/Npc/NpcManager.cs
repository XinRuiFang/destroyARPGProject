using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NpcManager : MonoBehaviour {

	public GameObject[] npcArray;

	Dictionary<int,GameObject> npcDic = new Dictionary<int, GameObject>();
	public static NpcManager _instance;

	void Awake()
	{
		_instance = this;
		Init ();
	}

	void Init()
	{
		foreach(GameObject go in npcArray)
		{
			int id = int.Parse(go.name.Substring(0,4));
			npcDic.Add(id,go);
		}
	}

	public GameObject GetNpcById(int id)
	{
		GameObject go = null;
		npcDic.TryGetValue (id, out go);
		return go;
	}
}
