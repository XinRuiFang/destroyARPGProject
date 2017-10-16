using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	Animator anim;
	GameObject texiao;
	float lifeTime = 2f;
	

	void Update()
	{
		if(texiao.activeSelf== true)
		{
			lifeTime -= Time.deltaTime;
			if(lifeTime<=0)
			{
				texiao.SetActive(false);
			}
		}
	}
	void Start()
	{
		anim = this.GetComponent<Animator> ();
		texiao = transform.Find ("Bip01/Bip01 Prop1/weapon").gameObject;
	}

	public void OnAttackButtonClick(bool isPress,PosType posType)
	{
		if(posType == PosType.Basic)
		{
			if(isPress)
			{

				anim.SetTrigger("Attack");
			}

		}
		else
		{
			if(isPress)
			{
				anim.SetBool("Skill"+(int)posType,true);
				texiao.SetActive(true);
				if((int)posType ==3)
				{
					lifeTime = 3;
				}
				else
				{
					lifeTime = 2;
				}

			}
			else
			{
				anim.SetBool("Skill"+(int)posType,false);

			}
		}
	}


}
