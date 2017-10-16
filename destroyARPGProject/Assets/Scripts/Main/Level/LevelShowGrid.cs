using UnityEngine;
using System.Collections;

public class LevelShowGrid : MonoBehaviour {

	UIButton place1;
	UIButton place2;
	UIButton place3;
	UIButton place4;
	UISprite logoSprite;

	UIGrid levelListGrid1;
	UIGrid levelListGrid2;
	UIGrid levelListGrid3;
	UIGrid levelListGrid4;

	TweenPosition tween;

	UIButton close_btn;

	void Awake()
	{
		place1 = transform.Find ("tower1").GetComponent<UIButton> ();
		place2 = transform.Find ("tower2").GetComponent<UIButton> ();
		place3 = transform.Find ("tower3").GetComponent<UIButton> ();
		place4 = transform.Find ("tower4").GetComponent<UIButton> ();
		levelListGrid1 = transform.Find ("LevelUI/Scroll View/Grid1").GetComponent<UIGrid> ();
		levelListGrid2 = transform.Find ("LevelUI/Scroll View/Grid2").GetComponent<UIGrid> ();
		levelListGrid3 = transform.Find ("LevelUI/Scroll View/Grid3").GetComponent<UIGrid> ();
		levelListGrid4 = transform.Find ("LevelUI/Scroll View/Grid4").GetComponent<UIGrid> ();
		logoSprite = transform.Find ("logoSprite").GetComponent<UISprite> ();
		close_btn = transform.Find ("close_btn").GetComponent<UIButton> ();
		tween = this.GetComponent<TweenPosition> ();
		EventDelegate ed1 = new EventDelegate (this, "OnPlace1");
		place1.onClick.Add (ed1);
		EventDelegate ed2 = new EventDelegate (this, "OnPlace2");
		place2.onClick.Add (ed2);
		EventDelegate ed3 = new EventDelegate (this, "OnPlace3");
		place3.onClick.Add (ed3);
		EventDelegate ed4 = new EventDelegate (this, "OnPlace4");
		place4.onClick.Add (ed4);
		EventDelegate ed5 = new EventDelegate (this, "Onclose");
		close_btn.onClick.Add (ed5);
	}
	void Onclose()
	{
		Hide ();
	}
	public void Show()
	{
		tween.PlayForward ();
	}
	void Hide()
	{
		tween.PlayReverse ();
	}
	void OnPlace1()
	{
		levelListGrid1.gameObject.SetActive (true);
		levelListGrid2.gameObject.SetActive (false);
		levelListGrid3.gameObject.SetActive (false);
		levelListGrid4.gameObject.SetActive (false);
		logoSprite.spriteName = "地图-失落大陆";
	}
	void OnPlace2()
	{
		levelListGrid1.gameObject.SetActive (false);
		levelListGrid2.gameObject.SetActive (true);
		levelListGrid3.gameObject.SetActive (false);
		levelListGrid4.gameObject.SetActive (false);
		logoSprite.spriteName = "地图-繁花落尽";
	}
	void OnPlace3()
	{
		levelListGrid1.gameObject.SetActive (false);
		levelListGrid2.gameObject.SetActive (false);
		levelListGrid3.gameObject.SetActive (true);
		levelListGrid4.gameObject.SetActive (false);
		logoSprite.spriteName = "地图-地狱之门";
	}
	void OnPlace4()
	{
		levelListGrid1.gameObject.SetActive (false);
		levelListGrid2.gameObject.SetActive (false);
		levelListGrid3.gameObject.SetActive (false);
		levelListGrid4.gameObject.SetActive (true);
		logoSprite.spriteName = "地图-梦魇来袭";
	}

}
