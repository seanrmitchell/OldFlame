using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string CorPrompt;
    [SerializeField] private string[] NonPrompts = new string[5];
    string IInteractable.InteractionPrompt => CorPrompt;
    void IInteractable.Interact(Interaction interact)
    {
        Debug.Log("Interacting with Object");
    }
}
