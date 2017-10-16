using UnityEngine;
using System.Collections;

public class MainmenuController : MonoBehaviour {

	public TweenScale playerDescribe;
	public TweenScale playerProto;
	public TweenScale playerInit;

	public void OnPlayerHeadClick()
	{
		playerDescribe.gameObject.SetActive(true);
		playerDescribe.PlayForward ();
	}
	public void OnPlayerDescribeCloseClick()
	{
		playerDescribe.PlayReverse ();
		playerInit.gameObject.SetActive(true);
		playerProto.gameObject.SetActive (false);
	}
	public void OnProtoChangeClick()
	{
		playerProto.gameObject.SetActive(true);
		playerInit.gameObject.SetActive (false);
	}
	public void OnInitChangeClick()
	{
		playerInit.gameObject.SetActive(true);
		playerProto.gameObject.SetActive (false);
	}
}
