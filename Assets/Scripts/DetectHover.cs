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
            GameObject currentObject = rayHit.collider.gameObject;

            if (currentObject != lastHovered) // If our current object is not the last hovered object
            {
                if (lastHovered != null)
                {
                    lastHovered.GetComponent<ScaleHover>()?.OnHoverExit(); // Call the OnHoverExit for our old object
                }

            }

            currentObject.GetComponent<ScaleHover>()?.OnHoverEnter(); // Call the OnHoverExit for our current object
            lastHovered = currentObject;

        }
        else
        {
            if (lastHovered != null)
            {
                lastHovered.GetComponent<ScaleHover>()?.OnHoverEnter();
                lastHovered = null;
            }
        }


    }
}
