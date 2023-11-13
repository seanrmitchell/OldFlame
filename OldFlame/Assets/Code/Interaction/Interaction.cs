using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Interaction : MonoBehaviour
{
    public Controls playerControls;

    [SerializeField] private Transform interactPoint;
    [SerializeField] private LayerMask interactMask;
    [SerializeField] private float interactPointRadius;
    [SerializeField] private GameObject interactIcon;
    private readonly Collider[] cols = new Collider[3];
    [SerializeReference] private int numFound;
    private void Awake()
    {
        playerControls = new Controls();
        interactIcon.SetActive(false);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactPoint.position, interactPointRadius, cols, interactMask);

        if (numFound > 0)
        {
            interactIcon.SetActive(true);
            var interactable = cols[0].GetComponent<IInteractable>();
            if (interactable != null && playerControls.Interaction.Interact.WasPerformedThisFrame())
            {
                interactable.Interact(this);
            }
        }
        else
        {
            interactIcon.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactPoint.position, interactPointRadius);
    }
}
