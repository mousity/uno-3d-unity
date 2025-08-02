using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectHover : MonoBehaviour
{
    private GameObject lastHovered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Physics.Raycast(ray, out Raycast, maxDistance)
        if (Physics.Raycast(ray, out RaycastHit rayHit, 20f))
        {
            GameObject currentObject = rayHit.collider.gameObject; // Get the current hovered gameObject

            if (currentObject != lastHovered) // If our current object is not the last hovered object
            {
                if (lastHovered != null) // If our lastHovered is null
                {
                    lastHovered.GetComponent<ScaleHover>()?.OnHoverExit(); // Call the OnHoverExit for our old object
                }

            }

            currentObject.GetComponent<ScaleHover>()?.OnHoverEnter(); // Call the OnHoverExit for our current object
            lastHovered = currentObject; // Set lastHovered to our current object

        }
        else
        {
            if (lastHovered != null) // If our lasthovered is not null and our ray didn't hit anything
            {
                lastHovered.GetComponent<ScaleHover>()?.OnHoverExit(); // Make sure to exit the lastHovered
                lastHovered = null; // Set our last hovered to null
            }
        }


    }
}
