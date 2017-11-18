using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupWorldAddaptive : MonoBehaviour
{
    Scene otherWorldScene;

    void Awake()
    {
        SceneManager.LoadScene(otherWorldScene.buildIndex, LoadSceneMode.Additive);
        
        while (!otherWorldScene.isLoaded)
        {
        }

        QuantumLink[] linkedobjects = FindObjectsOfType<QuantumLink>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
