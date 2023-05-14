using UnityEngine;
public class BatteryCase : MonoBehaviour    
{
    public GameObject door;

    void Start() 
    {
        door.SetActive(true);
    }
    public void OnClick() 
    {
        if(door != null) {
            OpenSesame();
        }
    }

    public void OpenSesame() 
    {
        Debug.Log("Open Sesame !");
        door.SetActive(false);
    }
}
