using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuantumLink : Interactable
{
    [SerializeField]
    QuantumLink linkedObject;

    // Use this for initialization
    protected override void Start ()
    {
        if (linkedObject == null)
        {
            Debug.LogError(this.name + " Have no link.");
        }
		if (linkedObject.linkedObject != this)
        {
            Debug.LogWarning(this.name + " is not linked correctly with " + linkedObject.name + " add this object to the object " + linkedObject.name);
        }
	}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    //Make sure to call base in sub classes if overridden
    public override void Interact()
    {
        base.Interact();
        ExecuteLocalQuantumAction();
        InteractWithLink();
    }

    //Override in sub classes for specified actions
    public virtual void ExecuteLocalQuantumAction()
    {
        
    }

    void InteractWithLink()
    {
        linkedObject.ExecuteLocalQuantumAction();
    }
}
