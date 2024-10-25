using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public string parameterName = "EquipmentSlot"; // The name of the parameter to change
    public int currentValue = 0; // Initial value of the parameter
    private float scrollCooldown = 1.0f; // Cooldown time between changes in seconds
    private float lastScrollTime; // To keep track of the last time the scroll input was registered

    public Vector3 targetPosition;
    public bool isMoving = false;
    public bool isHoldingWeapon = false;
    bool HammerPickedUp = false;
    bool AxePickedUp = false;
    bool KatanaPickedUp = false;
    bool ShotGunPickedUp = false;
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

    private void Start()
    {
        UI_Weapons.SetInteger(parameterName, currentValue); // Set initial value
        lastScrollTime = -scrollCooldown; // Ensures the first scroll is immediately allowed
    }
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

        // Check for mouse wheel scroll input and enforce cooldown
        if (Time.time - lastScrollTime >= scrollCooldown)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (HammerPickedUp && AxePickedUp && KatanaPickedUp && ShotGunPickedUp == true)
            {
                if (scroll > 0f)
                {
                    Debug.Log("Scrolling up");
                    // Scrolling up, increase the parameter
                    currentValue++;
                    if (currentValue > 4)
                    {
                        currentValue = 1; // Wrap back to 1 if going beyond 4
                    }
                    lastScrollTime = Time.time; // Reset the cooldown timer
                    UpdateWeapon();
                }
                else if (scroll < 0f)
                {
                    Debug.Log("Scrolling Down");
                    // Scrolling down, decrease the parameter
                    currentValue--;
                    if (currentValue < 1)
                    {
                        currentValue = 4; // Wrap back to 4 if going below 1
                    }
                    lastScrollTime = Time.time; // Reset the cooldown timer
                    UpdateWeapon();
                }
            }

            // Update the Animator parameter
            UI_Weapons.SetInteger(parameterName, currentValue);
        }
    }

    void UpdateWeapon()
    {

            Debug.Log("WEAPON CURRENT VALUE " + currentValue);
            InstantiateWeapon(currentValue - 1);
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
        GameObject newWeapon = Instantiate(Weapons[WeaponIndex], PlayerHands.transform.position, Quaternion.identity);
        newWeapon.transform.parent = PlayerHands.transform;

        // Determine EquipmentSlot value based on weapon tag
        currentValue = 0;
        if (newWeapon.CompareTag("Hammer"))
        {
            currentValue = 1;
            Debug.Log("Hammer Instantiated");
            HammerPickedUp = true;
            Debug.Log("HammerPickedUp " +  HammerPickedUp);
        }
        else if (newWeapon.CompareTag("Axe"))
        {
            currentValue = 2;
            Debug.Log("Axe Instantiated");
            AxePickedUp = true;
            Debug.Log("AxePickedUp " + AxePickedUp);
        }
        else if (newWeapon.CompareTag("Katana"))
        {
            currentValue = 3;
            Debug.Log("Katana Instantiated");
            KatanaPickedUp = true;
            Debug.Log("KatanaPickedUp " + KatanaPickedUp);
        }
        else if (newWeapon.CompareTag("Shotgun"))
        {
            currentValue = 4;
            Debug.Log("Shotgun Instantiated");
            ShotGunPickedUp = true;
            Debug.Log("ShotGunPickedUp " + ShotGunPickedUp);
        }

        // Update the UI_Weapons Animator parameter
        Debug.Log("Setting EquipmentSlot to " + currentValue);
        UI_Weapons.SetInteger(parameterName, currentValue); // Set the animator integer
        Debug.Log("Animator EquipmentSlot value after setting: " + UI_Weapons.GetInteger(parameterName));

        // Update weapon tracking variables
        isHoldingWeapon = true;
        currentWeaponIndex = WeaponIndex;
        currentWeapon = newWeapon;
        CurrentPlayerWeapon = newWeapon;
    }
}
