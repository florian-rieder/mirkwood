using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private string promptText = "Interact";

    public virtual void Start(){
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public virtual void Interact()
    {
        // TODO: Implement interaction logic.
        Debug.Log("Interaction with " + name);
    }

    public void EnterFocus(){
        outline.enabled = true;
        // GameManager.Instance.prompt.gameObject.SetActive(true);
        // GameManager.Instance.prompt.SetText(promptText);
        // GameManager.Instance.prompt.SetKey("E");
    }

    public void ExitFocus(){
        outline.enabled = false;
        // GameManager.Instance.prompt.gameObject.SetActive(false);
    }
}