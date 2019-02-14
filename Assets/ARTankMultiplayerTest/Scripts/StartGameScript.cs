using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour 
{
    public Button StarGameButon;
    public GameObject NetworkConnectionObject;

	// Use this for initialization
	void Start () 
    {
        StarGameButon.onClick.AddListener(StartGameFunc);
	}
	
	void StartGameFunc()
    {
        StarGameButon.gameObject.SetActive(false);
        NetworkConnectionObject.gameObject.SetActive(true);
    }
}
