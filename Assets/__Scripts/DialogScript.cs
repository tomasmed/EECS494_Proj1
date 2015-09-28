using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class DialogScript : MonoBehaviour {

    public static DialogScript S;
	private Text text_gameobj;
	private string temp_mess = "";
	private bool message_done = false;

    void Awake()
    {
        S = this;
    }

	// Use this for initialization
	void Start () {
        HideDialogBox();
	}
	
	// Update is called once per frame
	void Update () {

	    if ((MainScript.S.inDialog && Input.GetKeyDown(KeyCode.S)) || (message_done && Input.GetKeyDown(KeyCode.A)))
        {
			print ("exiting");
            HideDialogBox();
        }
	}


	private List<string> DistributeMessage(string speech)
	{
        bool ready_forcut = false;
		List <string> finalmess  = new List<string>{};
		string temp = "";
		for (int i  = 0; i< speech.Length; i++) 
		{
			temp += speech[i];

            if ((i % 30 == 0 && (i != 0)) || i == speech.Length - 1)
            {
                ready_forcut = true;
            }
            if (ready_forcut)
            {
                if (speech[i] == (' ') || i == speech.Length - 1)
                {
                    finalmess.Add(temp);
                    temp = "";
                    ready_forcut = false;
                }
            }
            
		}
		

        foreach(string message in finalmess)
        {
            Debug.Log(message);
        }

        return finalmess;
    }


    public void ShowMessage(string speech)
    {
		message_done = false;
        MainScript.S.inDialog = true;
		List<string> message = DistributeMessage (speech);
		GameObject dialogBox = transform.Find("Text").gameObject;
		text_gameobj = dialogBox.GetComponent<Text>();
		StartCoroutine(DialogS(message));
    }

	public IEnumerator DialogS(List<string> message)
	{
		for (int i = 0; i <message.Count ; i++)//string mess in message)
		{
			string mess = message[i];
			yield return new WaitForSeconds(0.025f);
			temp_mess = mess;
			text_gameobj.text = temp_mess;
			if(i == message.Count -1 ) message_done = true;
            yield return StartCoroutine(WaitForKeyDown(KeyCode.A));
            yield return new WaitForSeconds(0.025f);

        }
    }


	IEnumerator WaitForKeyDown(KeyCode keyCode)
	{
		while (!Input.GetKeyDown(keyCode))
			yield return null;
	}

    void HideDialogBox()
    {
        Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
        noAlpha.a = 0;
        GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
        gameObject.SetActive(false) ;
        MainScript.S.inDialog = false;
    }


}
