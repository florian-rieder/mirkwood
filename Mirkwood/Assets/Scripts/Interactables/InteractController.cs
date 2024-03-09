using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class InteractController : MonoBehaviour
{
    public float interactDistance = 3f;
    private PlayerInput _input;
    private Interactable focusedInteractable = null;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        // Cast a ray directly pointing out of the center of the screen
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactDistance))
        {
            // If we hit an interactable object
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable && interactable.enabled)
            {
                if (focusedInteractable == null){
                    focusedInteractable = interactable;
                    interactable.EnterFocus();
                }

                // If the player pressed the interact button (E)
                if (_input.actions["Interact"].WasPressedThisFrame())
                {
                    interactable.Interact();
                }

            } else if (interactable == null && focusedInteractable){
                focusedInteractable.ExitFocus();
                focusedInteractable = null;
            }
        } else if (focusedInteractable){
            focusedInteractable.ExitFocus();
            focusedInteractable = null;
        }
    }
}