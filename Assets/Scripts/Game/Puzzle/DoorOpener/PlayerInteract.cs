using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject batteryCase;
    public GameObject button;

    private bool isNearBatteryCase = false;

    void Start() 
    {
        button.SetActive(false);
    }

    void Update()
    {
        if (isNearBatteryCase)
        {
            if (batteryCase != null)
            {
                Debug.Log("Near Battery");
                button.SetActive(true);
                // batteryCase.GetComponent<BatteryCase>().TaruhItem();
            }
        }
        else
        {
            button.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == batteryCase)
        {
            Debug.Log("Near Battery");
            isNearBatteryCase = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == batteryCase)
        {
            isNearBatteryCase = false;
        }
    }
}
