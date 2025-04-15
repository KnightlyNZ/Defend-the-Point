using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    //message displayed to player when looking at an interactable
    public string promptMessage;

    public void BaseInteract()
    {
        if (useEvents)
        GetComponent<InteractionEvents>().OnInteract.Invoke();
       Interact(); 
    }

    protected virtual void Interact()
    {

    }
}
