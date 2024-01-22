using System.Collections;
using UnityEngine;

public class OutlineController : MonoBehaviour
{

    public bool EnableOutline = true;

    private Outline outline;
    private bool isMouseOver;
    private float outlineDelay = 0.1f; // Adjust this delay as needed
    private Coroutine outlineCoroutine;

    void Start()
    {
        // Get the Outline component attached to this GameObject
        outline = GetComponent<Outline>();

        // Disable the outline initially
        if (outline != null)
        {
            outline.enabled = false;
        }

        // Set the initial mouse-over state to false
        isMouseOver = false;
    }

    void OnMouseEnter()
    {
        // When the mouse pointer enters the GameObject
        if (EnableOutline && !isMouseOver && outline != null)
        {
            if (outlineCoroutine != null)
            {
                StopCoroutine(outlineCoroutine);
            }

            outline.enabled = true;
            isMouseOver = true;
        }
    }

    void OnMouseExit()
    {
        // When the mouse pointer exits the GameObject
        if (EnableOutline && isMouseOver && outline != null)
        {
            if (outlineCoroutine != null)
            {
                StopCoroutine(outlineCoroutine);
            }

            outlineCoroutine = StartCoroutine(DisableOutlineWithDelay());
        }
    }

    IEnumerator DisableOutlineWithDelay()
    {
        yield return new WaitForSeconds(outlineDelay);

        outline.enabled = false;
        isMouseOver = false;
    }

}
