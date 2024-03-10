using UnityEngine;

public class ShowCursorOnOpen : MonoBehaviour {
    public void Show(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Hide(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
