using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverviewCameraControl : MonoBehaviour
{
    [SerializeField]
    Camera overViewCamera;

    [SerializeField]
    Camera playerCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            overViewCamera.cullingMask ^= 1 << 9;
            overViewCamera.cullingMask ^= 1 << 8;
        }
    }
}
