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
            animator.SetBool("HoverEnterBool", true);
        }
        Debug.Log("Hower Enter detected" + gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (animator != null)
        {
            animator.SetBool("HoverEnterBool", false);
        }
        Debug.Log("Hower Exit detected" + gameObject.name);
    }
     public void OnPointerClick(PointerEventData eventData)
    {
        if ( transform.name == "UI-EquipmentBack1")
        {
            animator.SetTrigger("SelectCard1");
        }
		else if ( transform.name == "UI-EquipmentBack2")
        {
            animator.SetTrigger("SelectCard2");
        }
		else if ( transform.name == "UI-EquipmentBack3")
        {
            animator.SetTrigger("SelectCard3");
        }
		else if ( transform.name == "UI-EquipmentBack4")
        {
            animator.SetTrigger("SelectCard4");
        }
        Debug.Log("Player clicked card: " + transform.name);
    }
}
