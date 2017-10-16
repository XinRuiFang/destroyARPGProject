using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillButton : MonoBehaviour {

	public PosType posType = PosType.Basic;

	public float coldTime = 4;
	float coldTimer = 0;
	UISprite maskSprite;
	UIButton btn;
	float texiaolifetime = 2;

	PlayerAnimation playerAnim;

	//public List<SkillItem> skillItemList;
	
	void Start()
	{
		playerAnim = TranscriptManager._instance.player.GetComponent<PlayerAnimation> ();
		if(transform.Find("Mask"))
		{
			maskSprite = transform.Find ("Mask").GetComponent<UISprite> ();
		}
		btn = this.GetComponent<UIButton> ();
		/*
		this.skillItemList = SkillManager._instance.SkillItemList;
		switch(posType)
		{
		case PosType.One: 
			skillItemList.ForEach(u=>{if(u._Skill._PosType == PosType.One)
				{
					coldTime = u._ColdTimeEx * u._Skill._ColdTime;
				}
			});
			break;
		case PosType.Two: 
			skillItemList.ForEach(u=>{if(u._Skill._PosType == PosType.Two)
				{
					coldTime = u._ColdTimeEx * u._Skill._ColdTime;
				}
			});

			break;
		case PosType.Three: 
			skillItemList.ForEach(u=>{if(u._Skill._PosType == PosType.Three)
				{
					coldTime = u._ColdTimeEx * u._Skill._ColdTime;
				}
			});
			break;
		}
	*/
	}

	void Update()
	{

		if(maskSprite == null)
		{
			return ;
		}
		if(coldTimer>0)
		{
			coldTimer-=Time.deltaTime;
			maskSprite.fillAmount = coldTimer/coldTime;
			if(coldTimer <= 0)
			{
				Enable();
			}

		}
		else
		{
			maskSprite.fillAmount = 0;
		}
	}
	
	void OnPress(bool isPress)
	{
		playerAnim.OnAttackButtonClick (isPress, posType);
		if(isPress && maskSprite != null && PlayerMove._instance.anim.GetCurrentAnimatorStateInfo(1).IsName("Empty State"))
		{
			coldTimer = coldTime;
			Disable();
		}
	}

	void Enable()
	{
		this.GetComponent<Collider>().enabled = true;
	}
	void Disable()
	{
		this.GetComponent<Collider>().enabled = false;
		btn.SetState (UIButtonColor.State.Normal,true);
	}
}
