using UnityEngine;
using System.Collections;

public class BagRoleEquip : MonoBehaviour {

	UISprite sprite;
	InventoryItem it;
	UISprite Sprite
	{
		get
		{
			if(sprite == null)
			{
				sprite = this.GetComponent<UISprite>();
			}
			return sprite;
		}
	}
	public void SetId(int id)
	{
		Inventory inventory = null;
		bool isExist = InventoryManager._instance.inventoryDic.TryGetValue (id, out inventory);
		if (isExist) 
		{
			Sprite.spriteName = inventory._Headpic;
		}
	}
	public void SetInventoryItem(InventoryItem it)
	{
		if(it == null)
		{
			return;
		}
		this.it = it;
		Sprite.spriteName = it._Item._Headpic;
	}
	public void Clear()
	{
		it = null;
		Sprite.spriteName = "bg_道具";
	}
	public void OnPress(bool isPress)
	{
		if (isPress && it!= null)
		{
			object[] objArr = new object[3];
			objArr[0] = it;
			objArr[1] = false;
			objArr[2] = this;
			transform.parent.parent.SendMessage("OnInventoryClick",objArr);
		}
	}
}
