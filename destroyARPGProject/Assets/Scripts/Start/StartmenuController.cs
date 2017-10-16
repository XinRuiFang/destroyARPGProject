using UnityEngine;
using System.Collections;

public class StartmenuController : MonoBehaviour {

	public static StartmenuController _instance;

	public TweenScale startmenuPanelTween;
	public TweenScale signPanelTween;
	public TweenScale loadPanelTween;
	public TweenPosition loadCharacterPosTween;
	public TweenPosition signCharacterPosTween;

	public UIInput userNameInputSign;
	public UIInput passwordInputSign;
	public UIInput userNameInputLoad;
	public UIInput passwordInputLoad;

	public static string userNameSign;
	public static string passwordSign;

	public static string userNameLoad;
	public static string passwordLoad;

	public UILabel characterName;
	public UILabel characterLevel;

	public GameObject[] charaterArr;

	private GameObject charaterSel;

	void Awake()
	{
		_instance = this;
	}
	/// <summary>
	///start menu
	/// </summary>
	public void OnStartNewGameClick()
	{
		startmenuPanelTween.PlayForward ();
		StartCoroutine (HidePanel (startmenuPanelTween.gameObject));
		signPanelTween.gameObject.SetActive(true);
		signPanelTween.PlayForward ();
	}
	public void OnLoadClick()
	{
		startmenuPanelTween.PlayForward ();
		StartCoroutine (HidePanel (startmenuPanelTween.gameObject));
		loadPanelTween.gameObject.SetActive(true);
		loadPanelTween.PlayForward ();
	}
	public void OnQuitClick()
	{
		
	}
	/// <summary>
	/// register menu
	/// </summary>
	public void OnSubmitClick()
	{
		userNameSign = userNameInputSign.value;
		passwordSign = passwordInputSign.value;
		signPanelTween.PlayReverse ();
		StartCoroutine (HidePanel (signPanelTween.gameObject));
		signCharacterPosTween.gameObject.SetActive (true);
		signCharacterPosTween.PlayForward ();

	}
	public void OnbackClick()
	{
		signPanelTween.PlayReverse ();
		StartCoroutine (HidePanel (signPanelTween.gameObject));
		startmenuPanelTween.gameObject.SetActive (true);
		startmenuPanelTween.PlayReverse ();
	}
	/// <summary>
	/// load
	/// </summary>
	public void OnLoadbackClick()
	{
		loadPanelTween.PlayReverse ();
		StartCoroutine (HidePanel (loadPanelTween.gameObject));
		startmenuPanelTween.gameObject.SetActive (true);
		startmenuPanelTween.PlayReverse ();
	}
	public void OnLoadSubmit()
	{
		userNameLoad = userNameInputLoad.value;
		passwordLoad = passwordInputLoad.value;
		if (userNameLoad == "admin" && passwordLoad == "admin") 
		{
			characterName.text = "admin";
			characterLevel.text = "Lv.100";
			loadPanelTween.PlayReverse ();
			StartCoroutine (HidePanel (loadPanelTween.gameObject));
			loadCharacterPosTween.gameObject.SetActive (true);
			loadCharacterPosTween.PlayForward ();
		} 
		else 
		{
			Debug.Log("false");
		}
	}
	/// <summary>
	/// signcharacter
	/// </summary>
	public void OnsigncharacterBackClick()
	{
		signCharacterPosTween.PlayReverse ();
		StartCoroutine (HidePanel (signCharacterPosTween.gameObject));
		signPanelTween.gameObject.SetActive (true);
		signPanelTween.PlayForward ();
	}
	/// <summary>
	/// public common
	/// </summary>
	IEnumerator HidePanel(GameObject go)
	{
		yield return new WaitForSeconds (0.4f);
		go.SetActive (false);
	}
	public void OnCharacterClick(GameObject go)
	{
		if(go != charaterSel)
		{
			iTween.ScaleTo (go,new Vector3(1.1f,1.1f,1.1f),0.5f);
			if (charaterSel != null) 
			{
				iTween.ScaleTo (charaterSel,new Vector3(0.75f,0.75f,0.75f),0.5f);	
			}
			charaterSel = go;
		}

	}
}




















