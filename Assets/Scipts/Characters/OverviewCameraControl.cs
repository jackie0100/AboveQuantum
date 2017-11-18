using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverviewCameraControl : MonoBehaviour
{
    [SerializeField]
    Camera overViewCamera;

    [SerializeField]
    Camera playerCamera;

    [SerializeField]
    RenderTexture rt;

    [SerializeField]
    float height = 10;

    // Use this for initialization
    void Start()
    {
        if ((overViewCamera.cullingMask & (1 << 9)) == (1 << 9))
        {
            Physics.IgnoreLayerCollision(0, 9, true);
            Physics.IgnoreLayerCollision(0, 8, false);
        }
        else
        {
            Physics.IgnoreLayerCollision(0, 9, false);
            Physics.IgnoreLayerCollision(0, 8, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        overViewCamera.RenderToCubemap(rt);
        playerCamera.GetComponent<Skybox>().material.SetTextureOffset("_Tex", new Vector2(0.5f, 0.5f));
        overViewCamera.transform.position = new Vector3(playerCamera.transform.position.x, height - playerCamera.transform.position.y, playerCamera.transform.position.z);
        overViewCamera.transform.eulerAngles = new Vector3(-playerCamera.transform.eulerAngles.x, 0,0);
    }

    public void SwapWorlds()
    {
        overViewCamera.cullingMask ^= 1 << 9;
        overViewCamera.cullingMask ^= 1 << 8;

        if ((overViewCamera.cullingMask & (1 << 9)) == (1 << 9))
        {
            Physics.IgnoreLayerCollision(0, 9, true);
            Physics.IgnoreLayerCollision(0, 8, false);
        }
        else
        {
            Physics.IgnoreLayerCollision(0, 9, false);
            Physics.IgnoreLayerCollision(0, 8, true);
        }
    }
}
