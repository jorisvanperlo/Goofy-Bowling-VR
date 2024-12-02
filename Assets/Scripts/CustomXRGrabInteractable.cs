using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomXRGrabInteractable : XRGrabInteractable
{
    // The boolean to track when the object is released
    public bool isReleased = false;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        // Set isReleased to false when the object is grabbed
        isReleased = false;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        // Check if any interactors are still holding the object
        if (interactorsSelecting.Count == 0)
        {
            // If no hands are grabbing the object, set isReleased to true
            isReleased = true;
        }
    }
}
