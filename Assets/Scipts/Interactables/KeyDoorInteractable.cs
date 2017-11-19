using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorInteractable : QuantumLink
{
    [SerializeField]
    public int keyLinkID;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float rotationLimit;
    [SerializeField]
    Transform rotationObject;

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
    }

    public override void ExecuteLocalQuantumAction()
    {
        base.ExecuteLocalQuantumAction();

        StartCoroutine(RotateDoor());
    }

    public IEnumerator RotateDoor()
    {
        while (rotationObject.localEulerAngles.y <= rotationLimit)
        {
            rotationObject.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
}
