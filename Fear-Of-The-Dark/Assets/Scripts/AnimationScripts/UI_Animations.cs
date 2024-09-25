using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Animations : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the UI element
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (animator != null)
        {
            animator.SetBool("HoverEnterBool", true);
        }
        Debug.Log("Hover Enter detected" + gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (animator != null)
        {
            animator.SetBool("HoverEnterBool", false);
        }
        Debug.Log("Hover Exit detected" + gameObject.name);
    }
}
