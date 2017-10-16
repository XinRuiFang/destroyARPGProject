using UnityEngine;
using System.Collections;

public class PlayerVillageMove : MonoBehaviour {

	public float velocity = 10;// yidong speed
	public static PlayerVillageMove _instance;
	void Awake()
	{
		_instance = this;
	}
	void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector3 vel = GetComponent<Rigidbody>().velocity;


		if(Mathf.Abs(h)>0.05f || Mathf.Abs(v)>0.05f)
		{
			GetComponent<Rigidbody>().velocity = new Vector3 (-h * velocity, 0, -v* velocity);
			transform.rotation = Quaternion.LookRotation(new Vector3 (-h,0,-v));
		}
		else
		{
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}

	}
	public void Stop()
	{
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

}
