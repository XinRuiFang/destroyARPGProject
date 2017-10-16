using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelUI : MonoBehaviour {

	public static LevelUI _instance;
	UIGrid levelListGrid1;
	UIGrid levelListGrid2;
	UIGrid levelListGrid3;
	UIGrid levelListGrid4;
	List<Level> levelList;

	public GameObject levelItemPrefab;
	void Awake()
	{
		_instance = this;
		levelListGrid1 = transform.Find ("Scroll View/Grid1").GetComponent<UIGrid> ();
		levelListGrid2 = transform.Find ("Scroll View/Grid2").GetComponent<UIGrid> ();
		levelListGrid3 = transform.Find ("Scroll View/Grid3").GetComponent<UIGrid> ();
		levelListGrid4 = transform.Find ("Scroll View/Grid4").GetComponent<UIGrid> ();
		LevelManager._instance.OnLevelChange += this.OnLevelChange;
	}
	void OnLevelChange()
	{
		levelList = LevelManager._instance.LevelList;
		foreach(Level ti in levelList)
		{
			switch(ti._Place)
			{
			case 1:
				GameObject go1 = NGUITools.AddChild(levelListGrid1.gameObject,levelItemPrefab);
				levelListGrid1.AddChild(go1.transform);
				LevelControllerUI t1 = go1.GetComponent<LevelControllerUI>();
				t1.SetLevel(ti);
				break;
			case 2:
				GameObject go2 = NGUITools.AddChild(levelListGrid2.gameObject,levelItemPrefab);
				levelListGrid2.AddChild(go2.transform);
				LevelControllerUI t2 = go2.GetComponent<LevelControllerUI>();
				t2.SetLevel(ti);
				break;
			case 3:
				GameObject go3 = NGUITools.AddChild(levelListGrid3.gameObject,levelItemPrefab);
				levelListGrid3.AddChild(go3.transform);
				LevelControllerUI t3 = go3.GetComponent<LevelControllerUI>();
				t3.SetLevel(ti);
				break;
			case 4:
				GameObject go4 = NGUITools.AddChild(levelListGrid4.gameObject,levelItemPrefab);
				levelListGrid4.AddChild(go4.transform);
				LevelControllerUI t4 = go4.GetComponent<LevelControllerUI>();
				t4.SetLevel(ti);
				break;

			}

		}
	}
	void OnDestory()
	{
		LevelManager._instance.OnLevelChange -= this.OnLevelChange;
	}
}
