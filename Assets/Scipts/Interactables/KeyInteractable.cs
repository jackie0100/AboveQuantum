using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : Interactable
{
    [SerializeField]
    public int linkID;

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
        base.Interact();
        TextNotifier.instance.SetTextMessage("You Got a key!");
        Destroy(this.gameObject);
    }

}
