using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player

    public Vector3 targetPosition;
    public bool isMoving = false;
    public bool isHoldingWeapon = false;
    [SerializeField]
    GameObject PlayerHands;
    [SerializeField]
    Animator UI_Weapons;
    [SerializeField]
    GameObject[] Weapons;
    [SerializeField]
    GameObject CurrentPlayerWeapon;

    private GameObject currentWeapon;
    private int currentWeaponIndex;



    void Update()
    {
        // Start moving when the move button (e.g., left mouse button) is pressed
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }

        // Move the player towards the target position
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    // Method to set the target position when the move button is pressed
    void SetTargetPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        isMoving = true;
    }

    // Method to move the player towards the target position
    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Stop moving if the player reaches the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
    }

    public void InstantiateWeapon(int WeaponIndex)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }
        Debug.Log(WeaponIndex);
        GameObject newWeapon = Instantiate(Weapons[WeaponIndex], PlayerHands.transform.position, Quaternion.identity);
        newWeapon.transform.parent = PlayerHands.transform;
        float slotvalue = UI_Weapons.GetFloat("EquipmentSlot");
        Debug.Log("SlotValue "+slotvalue);
        UI_Weapons.SetFloat("EquipmentSlot", slotvalue +1 );
        isHoldingWeapon = true;
        currentWeaponIndex = WeaponIndex;
        currentWeapon = newWeapon;
        CurrentPlayerWeapon = newWeapon;
    }
}
