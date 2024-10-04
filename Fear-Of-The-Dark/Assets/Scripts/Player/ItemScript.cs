using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject playerHand;

    public GameObject[] weapons;
    public int WeaponIndex; 

    public Animator ItemAnimator;
    [SerializeField]
    GameObject UIinventory;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void TakeItem()
    {
        //Instantiate(weapons[WeaponIndex], playerHand.transform.position , Quaternion.identity);
        string itemName = gameObject.tag;
        string InventoryName = itemName + "Inventory";
        ItemAnimator.SetBool(InventoryName, true);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("YOU COLLIDED");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You collided hammer picked up");
            TakeItem();
        }

    }
}
