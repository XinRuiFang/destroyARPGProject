using UnityEngine;
using System.Collections;

public class InventoryItemUI : MonoBehaviour {
	UISprite sprite;
	UILabel label;
	public InventoryItem it;

	UISprite Sprite
	{
		get
		{
			if(sprite == null)
			{
				sprite = transform.Find("Sprite").GetComponent<UISprite>();
			}
			return sprite;
		}
	}
	UILabel Label
	{
		get
		{
			if(label == null)
			{
				label = transform.Find("Label").GetComponent<UILabel>();
			}
			return label;
		}
	}

	public void SetInventoryItem(InventoryItem it)
	{
		this.it = it;
		Sprite.spriteName = it._Item._Headpic;
		if (it._Count <= 1) 
		{
			Label.text = "";
		}
		else
		{
			Label.text = it._Count.ToString();
		}
	}
	public void Clear()
	{
		it = null;
		Label.text = "";
		Sprite.spriteName = "bg_道具";
	}
	public void OnClick()
	{
		if (it != null)
		{
			object[] objArr = new object[3];
			objArr[0] = it;
			objArr[1] = true;
			objArr[2] = this;
			transform.parent.parent.parent.SendMessage("OnInventoryClick",objArr);
		}
	}
	public void ChangeCount()
	{
		if(it._Count - 1 <= 0)
		{
			Clear();
		}
		else if(it._Count == 1)
		{
			Label.text = null;
		}
		else
		{
			Label.text = (it._Count - 1).ToString();
		}

	}
}
