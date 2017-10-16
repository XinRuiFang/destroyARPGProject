using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NpcDialogUI : MonoBehaviour {

	public static NpcDialogUI _instance;

	TweenPosition tween;
	UILabel talkNpcLabel;
	UIButton acceptBtn;
	UIButton nextBtn;

	List<string> talkNpc;
	GameObject player;
	int sign;
	void Awake()
	{
		_instance = this;

	}
	void Start()
	{
		tween = this.GetComponent<TweenPosition> ();
		talkNpcLabel = transform.Find ("Npc_Dialog_btn/TalkNpc").GetComponent<UILabel> ();
		acceptBtn = transform.Find ("AcceptBtn").GetComponent<UIButton> ();
		nextBtn = transform.Find("Npc_Dialog_btn").GetComponent<UIButton> ();
		EventDelegate ed = new EventDelegate(this,"OnAccept");
		acceptBtn.onClick.Add (ed);
		EventDelegate ed1 = new EventDelegate(this,"OnTalk");
		nextBtn.onClick.Add (ed1);
		DisableBtn ();
	}
	public void Show(List<string> talkNpc,GameObject player)
	{
		this.player = player;
		this.talkNpc = talkNpc;

		if(talkNpc.Count == 1)
		{
			talkNpcLabel.text = this.talkNpc[0];
			tween.PlayForward ();
		}
		else
		{
			EnableBtn();
			acceptBtn.gameObject.SetActive(false);
			talkNpcLabel.text = this.talkNpc[0];
			sign = 1;
			tween.PlayForward ();
		}
	}
	void DisableBtn()
	{
		nextBtn.SetState (UIButtonColor.State.Disabled, true);
		nextBtn.GetComponent<Collider>().enabled = false;
	}
	void EnableBtn()
	{
		nextBtn.SetState (UIButtonColor.State.Normal, true);
		nextBtn.GetComponent<Collider>().enabled = true;
	}
	public void UpdateShow(string talkNpc)
	{
		talkNpcLabel.text = talkNpc;
	}
	public void Hide()
	{
		tween.PlayReverse ();
	}
	void OnAccept()
	{
		Hide ();
		player.GetComponent<PlayerVillageMove> ().enabled = true;
	}
	void OnTalk()
	{
		talkNpcLabel.text = this.talkNpc[sign];
		sign ++;
		if(this.talkNpc.Count <= sign)
		{
			acceptBtn.gameObject.SetActive(true);
			DisableBtn();
			sign = 0;
		}

	}
}
