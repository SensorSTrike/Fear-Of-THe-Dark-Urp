using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject[] weapons;
    public int WeaponIndex; 
    public Animator ItemAnimator;

    void Start()
    {

    }
    public void TakeItem(GameObject player)
    {
        string itemName = gameObject.tag;
        string InventoryName = itemName + "Inventory";
        ItemAnimator.SetBool(InventoryName, true);

        Debug.Log("Sinun inventoorin nimi on : " + InventoryName);
        Destroy(gameObject);
        player.GetComponent<PlayerController>().InstantiateWeapon(WeaponIndex);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("YOU COLLIDED");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You collided weapon picked up");
            TakeItem(other.gameObject);
        }

    }
}
