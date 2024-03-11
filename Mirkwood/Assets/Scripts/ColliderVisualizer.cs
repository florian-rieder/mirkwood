using UnityEngine;

[ExecuteInEditMode]
public class ColliderVisualizer : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // Loop through all child GameObjects and draw the wireframes of their BoxColliders
        foreach (Transform child in transform)
        {
            BoxCollider collider = child.GetComponent<BoxCollider>();
            if (collider != null && collider.enabled)
            {
                // Draw the wireframe of the BoxCollider
                Gizmos.color = Color.yellow;
                Gizmos.matrix = child.localToWorldMatrix; // Transform Gizmos to match child's position and rotation
                Gizmos.DrawWireCube(collider.center, collider.size);
            }
        }
    }
}
