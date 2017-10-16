using UnityEngine;
using System.Collections;

public class SalePopUp : MonoBehaviour {

	UIButton sale;
	UILabel item_sale;
	UIButton closeContainer_btn;
	InventoryItem it;
	UILabel alert_label;

	void Awake()
	{
		item_sale = transform.Find ("alert/item_sale").GetComponent<UILabel> ();
		sale = transform.Find ("alert/sale_btn").GetComponent<UIButton> ();
		closeContainer_btn = transform.Find ("alert/close_btn").GetComponent<UIButton> ();
		alert_label = transform.Find ("alert/alert_Label").GetComponent<UILabel> ();
		EventDelegate ed1 = new EventDelegate(this,"OnSale");
		sale.onClick.Add (ed1);
		EventDelegate ed3 = new EventDelegate(this,"OnCloseSale");
		closeContainer_btn.onClick.Add (ed3);
	}
	void OnCloseSale()
	{
		Clear ();
		this.gameObject.SetActive(false);
	}
	public void Show(InventoryItem it)
	{
		this.gameObject.SetActive (true);
		this.it = it;
		if(it._Exp > 1600 || it._Strengthen >10)
		{
			alert_label.gameObject.SetActive(true);
			item_sale.text =  "此物品的售价为：" + (this.it._Item._StandardPrice * this.it._Count).ToString();
		}
		else
		{
			alert_label.gameObject.SetActive(false);
			item_sale.text =  "此物品的售价为：" + (this.it._Item._StandardPrice * this.it._Count).ToString();
		}
	}
	void OnSale()
	{
		int price = this.it._Item._StandardPrice * this.it._Count;
		PlayerInfo._instance.GetCoin (price);
		InventoryManager._instance.RemoveInventoryItem (it);
		OnCloseSale ();
		transform.parent.parent.SendMessage ("ClosePopup");
	}
	public void Clear()
	{
		this.it = null;
	}
}
