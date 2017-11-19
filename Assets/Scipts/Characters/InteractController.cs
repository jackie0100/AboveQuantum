using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //TODO: Raycast check interactability.
            RaycastHit hit;
            Debug.DrawRay(this.transform.position, Vector3.forward * 10, Color.red, 5);

            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.GetComponent<Interactable>() != null)
                {
                    hit.transform.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}
