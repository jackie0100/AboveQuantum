using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool Swapping
    {
        get; private set;
    }

    [SerializeField]
    private Vingette vingette;
    [SerializeField]
    private AnimationCurve innerVingette;
    [SerializeField]
    private AnimationCurve outerVingette;
    [SerializeField]
    private AnimationCurve saturation;
    [SerializeField]
    Camera playercamera;

    [SerializeField]
    private AnimationCurve fov;
    [SerializeField]
    private AnimationCurve timeScale;

    private AudioSource warpAudio;
    [SerializeField]
    private AudioClip warpSound;
    private bool swapTiggered;
    private readonly float swapTime = 0.85f;

    [SerializeField]
    OverviewCameraControl overviewCamera;

    // Use this for initialization
    void Start()
    {
        warpAudio = this.gameObject.AddComponent<AudioSource>();

        warpAudio.clip = warpSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(SwapAsync());

        }
    }

    IEnumerator SwapAsync()
    {
        Swapping = true;
        swapTiggered = false;

        warpAudio.PlayOneShot(warpSound);

        for (float t = 0; t < 1.0f; t += Time.unscaledDeltaTime * 1.2f)
        {

            playercamera.fieldOfView = fov.Evaluate(t);
            
            vingette.MinRadius = innerVingette.Evaluate(t);
            vingette.MaxRadius = outerVingette.Evaluate(t);
            vingette.Saturation = saturation.Evaluate(t);
            Time.timeScale = timeScale.Evaluate(t);

            if (t > swapTime && !swapTiggered)
            {
                playercamera.cullingMask ^= 1 << 9;
                playercamera.cullingMask ^= 1 << 8;

                overviewCamera.SwapWorlds();
                swapTiggered = true;
            }

            yield return null;
        }

        // technically a huge lag spike could cause this to be missed in the coroutine so double check it here.
        if (!swapTiggered)
        {
            playercamera.cullingMask ^= 1 << 9;
            playercamera.cullingMask ^= 1 << 8;

            overviewCamera.SwapWorlds();
            swapTiggered = true;
        }


        playercamera.fieldOfView = fov.Evaluate(1.0f);

        vingette.MinRadius = innerVingette.Evaluate(1.0f);
        vingette.MaxRadius = outerVingette.Evaluate(1.0f);
        vingette.Saturation = 1.0f;

        Time.timeScale = 1.0f;

        Swapping = false;
    }

    public void SwapWorlds()
    {
        playercamera.cullingMask ^= 1 << 9;
        playercamera.cullingMask ^= 1 << 8;
        overviewCamera.SwapWorlds();
    }
}
