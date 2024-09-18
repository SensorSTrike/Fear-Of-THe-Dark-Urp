using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSwap : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;

    // Call this function when you want to swap the cards' order in the UI
    public void SwapCards()
    {
        // Get the current sibling indices
        int card1Index = card1.transform.GetSiblingIndex();
        int card2Index = card2.transform.GetSiblingIndex();

        // Swap their indices
        card1.transform.SetSiblingIndex(card2Index);
        card2.transform.SetSiblingIndex(card1Index);
    }
}