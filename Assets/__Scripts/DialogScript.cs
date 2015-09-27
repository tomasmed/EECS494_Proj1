using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour {

    public static DialogScript S;

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
	    if (MainScript.S.inDialog && Input.GetKeyDown(KeyCode.S))
        {
            HideDialogBox();
        }
	}


    public void ShowMessage(string message)
    {
        print("Printing: " + message);
        MainScript.S.inDialog = true;
        GameObject dialogBox = transform.Find("Text").gameObject;
        Text goText = dialogBox.GetComponent<Text>();
        goText.text = message;
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
