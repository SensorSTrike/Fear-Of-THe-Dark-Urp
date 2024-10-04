using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    [SerializeField]
    GameObject Inventory;
    public bool InventoryPanelIsActive = false;

    void Awake()
    {
        Inventory.SetActive(false);
    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryPanelIsActive == false)
            {
                Inventory.SetActive(true);
                InventoryPanelIsActive = true;
            }
            else
            {
                Inventory.SetActive(false);
                InventoryPanelIsActive = false;
            }
        }
    }
}