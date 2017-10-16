using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour {
	public List<InventoryItemUI> itemUIList;
	public static InventoryUI _instance;
	UIButton clearUp_btn;
	UILabel inventoryLabel;

	int count = 0;

	void Awake()
	{
		_instance = this;
		InventoryManager._instance.OnInventoryChange += this.OnInventoryChange;
		clearUp_btn = transform.Find ("make_btn").GetComponent<UIButton> ();
		inventoryLabel = transform.Find ("bag_status").GetComponent<UILabel> ();
		//sale_btn = transform.Find ("sale_btn").GetComponent<UIButton> ();
		EventDelegate ed = new EventDelegate (this, "OnClearUp");
		clearUp_btn.onClick.Add (ed);
	}
	void OnDestory()
	{
		InventoryManager._instance.OnInventoryChange -= this.OnInventoryChange;
	}
	void OnInventoryChange()
	{
		UpdateShow ();
	}
	void UpdateShow()
	{
		int temp = 0;
		for (int i = 0; i < InventoryManager._instance.inventoryItemList.Count; i++) 
		{
			InventoryItem it = InventoryManager._instance.inventoryItemList[i];
			if(it._IsDressed == 0)
			{
				itemUIList[temp].SetInventoryItem(it);
				temp++;
			}
		}
		count = temp;
		for (int i = temp; i<itemUIList.Count; i++)
		{
			itemUIList[i].Clear();
		}
		inventoryLabel.text = count.ToString() + "/" + PlayerInfo._instance._BagCount.ToString ();
	}
	public void AddInventoryItem(InventoryItem it)
	{
		foreach(InventoryItemUI itUI in itemUIList)
		{
			if(itUI.it == null)
			{
				itUI.SetInventoryItem(it);
				count ++;
				break;
			}
		}
		inventoryLabel.text = count.ToString() + "/" + PlayerInfo._instance._BagCount.ToString ();
	}
	void OnClearUp()
	{
		UpdateShow ();
	}
	public void UpdateCount()
	{
		count = 0;
		foreach(InventoryItemUI itUI in itemUIList)
		{
			if(itUI.it != null)
			{
				count ++;
			}
		}
		inventoryLabel.text = count.ToString() + "/" + PlayerInfo._instance._BagCount.ToString ();
	}
}
