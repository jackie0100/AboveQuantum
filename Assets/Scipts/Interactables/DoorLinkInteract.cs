using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLinkInteract : QuantumLink
{
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float rotationLimit;

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
        while (this.transform.eulerAngles.y >= rotationLimit)
        {
            this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
}
