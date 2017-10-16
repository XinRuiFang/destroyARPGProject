using UnityEngine;
using System.Collections;

public class LoadProgressBar : MonoBehaviour {

	public static LoadProgressBar _instance;

	GameObject bg;

	UISlider progressBar;

	bool isAsync = false;
	AsyncOperation ao = null;

	void Awake()
	{
		_instance = this;

		bg = transform.Find ("bg").gameObject;
		progressBar = transform.Find ("bg/ProgressBar").GetComponent<UISlider> ();
		gameObject.SetActive (false);

		//Application.LoadLevelAsync (2);
	}

	void Update()
	{
		if(isAsync)
		{
			progressBar.value =	ao.progress;
		}
	}
	public void Show(AsyncOperation ao)
	{
		gameObject.SetActive (true);
		bg.SetActive (true);
		isAsync = true;
		this.ao = ao;
	}
}
