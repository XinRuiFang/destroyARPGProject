using UnityEngine;
using System.Collections;

public class InventoryPopup : MonoBehaviour {
	UILabel _name;
	UISprite pic_item;
	UILabel describe;
	InventoryItem it;

	UIButton close_btn;
	UIButton use_btn;

	InventoryItemUI itUI;
	void Awake()
	{
		_name = transform.Find ("alert/name_label").GetComponent<UILabel> ();
		pic_item = transform.Find ("alert/pic_item/Sprite").GetComponent<UISprite> ();
		describe = transform.Find ("alert/item_describe").GetComponent<UILabel> ();
		close_btn = transform.Find ("alert/close_btn").GetComponent<UIButton> ();
		use_btn = transform.Find ("alert/use_btn").GetComponent<UIButton> ();
		EventDelegate ed1 = new EventDelegate (this, "OnClose");
		close_btn.onClick.Add (ed1);
		EventDelegate ed2 = new EventDelegate (this, "OnUse");
		use_btn.onClick.Add (ed2);
	}
	public void Show(InventoryItem it,InventoryItemUI itUI)
	{
		this.gameObject.SetActive (true);
		this.it = it;
		this.itUI = itUI;
		_name.text = it._Item._Name;
		pic_item.spriteName = it._Item._Headpic;
		describe.text = it._Item._Describe;
	}
	public void OnClose()
	{
		Close ();
		transform.parent.SendMessage ("DisableBtn");
	}
	public void Close()
	{
		Clear ();
		gameObject.SetActive (false);
	}
	public void OnUse()
	{
		itUI.ChangeCount ();
		PlayerInfo._instance.InventoryUse (it);
		if(it._Count <= 0)
		{
			OnClose();
			InventoryUI._instance.SendMessage("UpdateCount");
		}
	}
	public void Clear()
	{
		this.it = null;
		this.itUI = null;
	}
}
