using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SetupWorldAddaptive : MonoBehaviour
{
    [SerializeField]
    string otherWorldSceneName;

    //Scene otherWorldScene;
    void Awake()
    {
        if (SceneManager.sceneCount < 2)
        {
            SceneManager.LoadScene(otherWorldSceneName, LoadSceneMode.Additive);
        }
    }

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(SetupQuantumLinks());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator SetupQuantumLinks()
    {
        yield return new WaitForEndOfFrame();

        QuantumLink[] linkedobjects = FindObjectsOfType<QuantumLink>();

        for (int i = 0; i < linkedobjects.Length; i++)
        {
            linkedobjects[i].linkedObject = new List<QuantumLink>();
            QuantumLink[] locallinks = linkedobjects.Where(o => o.linkID == linkedobjects[i].linkID && linkedobjects[i].linkedObject != o.linkedObject).ToArray();
            linkedobjects[i].linkedObject.AddRange(locallinks);
        }

        yield return null;
    }
}
