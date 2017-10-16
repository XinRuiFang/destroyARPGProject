using UnityEngine;
using System.Collections;

public class ItemBar : MonoBehaviour {

	UIButton bag;
	UIButton shop;
	UIButton skill;
	UIButton fight;
	UIButton system;
	UIButton mession;
	void Awake()
	{
		bag = transform.Find ("bag").GetComponent<UIButton> ();
		shop = transform.Find ("shop").GetComponent<UIButton> ();
		skill = transform.Find ("skill").GetComponent<UIButton> ();
		fight = transform.Find ("fight").GetComponent<UIButton> ();
		system = transform.Find ("system").GetComponent<UIButton> ();
		mession = transform.Find ("mession").GetComponent<UIButton> ();

		EventDelegate ed1 = new EventDelegate (this, "OnBagClick");
		bag.onClick.Add (ed1);
		EventDelegate ed2 = new EventDelegate (this, "OnShopClick");
		shop.onClick.Add (ed2);
		EventDelegate ed3 = new EventDelegate (this, "OnSkillClick");
		skill.onClick.Add (ed3);
		EventDelegate ed4 = new EventDelegate (this, "OnFightClick");
		fight.onClick.Add (ed4);
		EventDelegate ed5 = new EventDelegate (this, "OnSystemClick");
		system.onClick.Add (ed5);
		EventDelegate ed6 = new EventDelegate (this, "OnMessionClick");
		mession.onClick.Add (ed6);
	}
	void OnBagClick()
	{
		Bag._instance.Show ();
	}
	void OnShopClick()
	{
		
	}
	void OnSkillClick()
	{
		SkillUI._instance.Show ();
	}
	void OnFightClick()
	{
		
	}
	void OnSystemClick()
	{
		
	}
	void OnMessionClick()
	{
		TaskUI._instance.Show ();
	}
}
