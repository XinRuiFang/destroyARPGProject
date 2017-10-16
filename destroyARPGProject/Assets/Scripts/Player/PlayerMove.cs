using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public static PlayerMove _instance;

	public float velocity = 1;

	public Animator anim;

	void Start()
	{

		anim = this.GetComponent<Animator> ();
		_instance = this;
	}

	void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector3 nowVelocity = GetComponent<Rigidbody>().velocity;
		if(Mathf.Abs(h)>0.05f || Mathf.Abs(v)>0.05f)
		{
			anim.SetBool("Move",true);
			if(anim.GetCurrentAnimatorStateInfo(1).IsName("Empty State"))
			{
				GetComponent<Rigidbody>().velocity = new Vector3(-velocity*h,nowVelocity.y,-v*velocity);
				transform.LookAt(new Vector3(-h,0,-v)+transform.position);
			}
			else
			{
				GetComponent<Rigidbody>().velocity = new Vector3(0,nowVelocity.y,0);
			}
		}
		else
		{
			anim.SetBool("Move",false);
			GetComponent<Rigidbody>().velocity = new Vector3(0,nowVelocity.y,0);
		}
	}
}
