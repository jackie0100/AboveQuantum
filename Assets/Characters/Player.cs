using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Camera playercamera;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.F))
        {
            playercamera.cullingMask ^= 1 << 10;
            playercamera.cullingMask ^= 1 << 9;
        }
    }
}
