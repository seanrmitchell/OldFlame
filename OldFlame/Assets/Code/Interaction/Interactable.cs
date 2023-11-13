using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IInteractable
{
    string InteractionPrompt { get; }
    void Interact(Interaction interact);
}
