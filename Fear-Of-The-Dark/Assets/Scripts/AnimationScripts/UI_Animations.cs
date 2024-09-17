using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Animations : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;

    // Start is called before the first frame update
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
}
