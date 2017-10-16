using UnityEngine;
using System.Collections;

public class Character_show : MonoBehaviour {
	public void OnPress(bool isPress)
	{
		if (isPress == false) 
		{
			StartmenuController._instance.OnCharacterClick (transform.parent.gameObject);
		}
	}

}
