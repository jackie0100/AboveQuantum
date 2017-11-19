using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuantumLink : Interactable
{
    [SerializeField]
    public List<QuantumLink> linkedObject;
    [SerializeField]
    public int linkID;

    // Use this for initialization
    protected override void Start ()
    {
  //      if (linkedObject == null || linkedObject.Count == 0)
  //      {
  //          Debug.LogError(this.name + " Have no link.");
  //      }
		//if (linkedObject.Contains(this))
  //      {
  //          Debug.LogWarning(this.name + " is not linked correctly check IDs and trye again.");
  //      }
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
        for (int i = 0; i < linkedObject.Count; i++)
        {
            linkedObject[i].ExecuteLocalQuantumAction();
        }
    }
}
