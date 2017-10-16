using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour {

	EquipmentPopUp equipPopup;
	InventoryPopup inventoryPopup;
	SalePopUp salePopup;
	public static Bag _instance;
	TweenPosition tween;
	UIButton close_btn;
	UIButton sale_btn;

	InventoryItem it;
	InventoryItemUI itUI;



	void Awake()
	{
		_instance = this;
		equipPopup = transform.Find ("equipContainer").GetComponent<EquipmentPopUp> ();
		inventoryPopup = transform.Find ("alertContainer").GetComponent<InventoryPopup> ();
		salePopup = transform.Find ("Inventory/saleContainer").GetComponent<SalePopUp> ();
		tween = this.GetComponent<TweenPosition> ();
		close_btn = transform.Find ("close_btn").GetComponent<UIButton> ();
		sale_btn = transform.Find ("Inventory/sale_btn").GetComponent<UIButton> ();


		EventDelegate ed = new EventDelegate(this,"OnBagClose");
		close_btn.onClick.Add (ed);
		DisableBtn ();

		EventDelegate ed2 = new EventDelegate(this,"OnEnableSale");
		sale_btn.onClick.Add (ed2);

	}
	public void OnInventoryClick(object[] objArr)
	{
		InventoryItem it = objArr [0] as InventoryItem;
		bool isLeft = (bool)objArr [1];
		if(it._Item._InventoryType == InventoryType.Equip)
		{
			InventoryItemUI itUI = null;
			BagRoleEquip bre = null;
			if(isLeft == true)
			{
				itUI = objArr [2] as InventoryItemUI;
			}
			else
			{
				bre = objArr[2] as BagRoleEquip;
			}
			inventoryPopup.Close();
			equipPopup.Show (it, itUI, bre,isLeft);
		}
		else
		{
			InventoryItemUI itUI = objArr[2] as InventoryItemUI;
			equipPopup.Close();
			inventoryPopup.Show(it,itUI);
		}
		if((it._Item._InventoryType == InventoryType.Equip && isLeft ==true)||it._Item._InventoryType != InventoryType.Equip)
		{
			this.it =  it;
			EnableBtn();
		}

	}
	public void Show()
	{
		tween.PlayForward ();
	}
	public void Hide()
	{
		tween.PlayReverse ();
	}
	void OnBagClose()
	{
		Hide ();
	}
	void DisableBtn()
	{
		sale_btn.SetState (UIButtonColor.State.Disabled, true);
		sale_btn.GetComponent<Collider>().enabled = false;
	}
	void EnableBtn()
	{
		sale_btn.SetState (UIButtonColor.State.Normal, true);
		sale_btn.GetComponent<Collider>().enabled = true;
	}

	void OnEnableSale()
	{
		if(it._Item._InventoryType == InventoryType.Drug)
		{
			inventoryPopup.OnClose ();
		}
		salePopup.Show (it);
	}
	void ClosePopup()
	{
		equipPopup.Close ();
		inventoryPopup.Close ();
	}

}
