using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class Client :MonoBehaviour{

	private string url = "http://115.29.76.1/ARPG_server/Portal.php";
	public static Client _instance;


	void Awake()
	{
		_instance = this;
	}

	public JsonData SerializationJson(string json)
	{
		JsonData jd = JsonMapper.ToObject (json);
		JsonData jdItem = jd["dataList"];

		return jdItem;
	}

	public IEnumerator InitWaitForRequest(string sql,System.Action<string> cb)
	{
		
		WWWForm form = new WWWForm ();
		form.AddField ("QUERY", sql);
		
		WWW www = new WWW (url, form);
		yield return www;
		if (www.error != null)  
		{   
			Debug.Log( "error :" + www.error);  
		}  
		else
		{
			try{
				//Debug.Log(www.text);

				//cb.Invoke(InitInventory(SerializationJson(www.text)));
				cb.Invoke(www.text);
			}
			catch(JsonException e){
				Debug.Log(e.Message.ToString());
			}
			
		}
		
	}



}
