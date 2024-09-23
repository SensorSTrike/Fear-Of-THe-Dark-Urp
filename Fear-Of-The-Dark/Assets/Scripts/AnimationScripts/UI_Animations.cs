using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Animations : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
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
            animator.SetTrigger("HoverEnter");
        }
        Debug.Log("Hower Enter detected" + gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (animator != null)
        {
            animator.SetTrigger("HoverExit");
        }
        Debug.Log("Hower Exit detected" + gameObject.name);
    }
     public void OnPointerClick(PointerEventData eventData)
    {
        if ( transform.name == "UI-EquipmentBack1")
        {
            animator.SetTrigger("SelectCard1");
        }
        Debug.Log("Player clicked card: " + transform.name);
    }
}
