using UnityEngine;
using System.Collections;

public class MsgManager : MonoBehaviour {

	//MsgManager._instance.ShowMsg("msg",time);
	public static MsgManager _instance;
	UILabel msgLabel;
	TweenAlpha tween;
	bool isSetActive = true;

	void Awake()
	{
		_instance = this;
		msgLabel = transform.Find ("Label").GetComponent<UILabel> ();
		tween = this.GetComponent<TweenAlpha> ();

		EventDelegate ed = new EventDelegate(this,"OnTweenFinished");
		tween.onFinished.Add (ed);

		gameObject.SetActive (false);
	}
	public void ShowMsg(string msg,float time = 1)
	{
		gameObject.SetActive (true);
		StartCoroutine (Show (msg, time));
	}
	IEnumerator Show(string msg, float time)
	{

		isSetActive = true;
		tween.PlayForward ();
		msgLabel.text = msg;

		yield return new WaitForSeconds (time);
		isSetActive = false;
		tween.PlayReverse ();
	}
	public void OnTweenFinished()
	{
		if(isSetActive == false)
		{
			gameObject.SetActive(false);
		}
	}
}
