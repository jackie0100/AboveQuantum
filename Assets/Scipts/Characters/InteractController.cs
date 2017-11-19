using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class InteractController : MonoBehaviour
{
    List<KeyInteractable> collectedkeys;
	// Use this for initialization
	void Start ()
    {
        collectedkeys = new List<KeyInteractable>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //TODO: Raycast check interactability.
            RaycastHit[] hit;
            Debug.DrawRay(this.transform.position, Vector3.forward * 10, Color.red, 5);

            hit = Physics.RaycastAll(this.transform.position, transform.TransformDirection(Vector3.forward), 5);

            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].transform.GetComponent<KeyInteractable>() != null)
                {
                    collectedkeys.Add(hit[i].transform.GetComponent<KeyInteractable>());
                    hit[i].transform.GetComponent<Interactable>().Interact();
                    return;
                }
                if (hit[i].transform.GetComponent<KeyDoorInteractable>() != null)
                {
                    if (collectedkeys.Any(k => k.linkID == hit[i].transform.GetComponent<KeyDoorInteractable>().keyLinkID))
                    {
                        collectedkeys.Add(hit[i].transform.GetComponent<KeyInteractable>());
                        hit[i].transform.GetComponent<Interactable>().Interact();
                    }
                    else
                    {
                         
                    }
                    return;
                }
                if (hit[i].transform.GetComponent<Interactable>() != null)
                {
                    Debug.Log(hit[i].transform.name);
                    hit[i].transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }
}
