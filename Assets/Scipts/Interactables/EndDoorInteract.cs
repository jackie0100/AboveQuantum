using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoorInteract : Interactable
{
    [SerializeField]
    string nextLevelName;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
