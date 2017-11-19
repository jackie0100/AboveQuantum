using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Handler : MonoBehaviour {

    //public GameObject guiObject;
    public string levelToLoad;

	// Use this for initialization
	void Start ()
    {
        //guiObject.SetActive(false);
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetButtonDown("Use"))
        {
            Application.LoadLevel(levelToLoad);
        }

	}
    private void OnTriggerExit(Collider other)
    {
        //guiObject.SetActive(false);
    }

}
