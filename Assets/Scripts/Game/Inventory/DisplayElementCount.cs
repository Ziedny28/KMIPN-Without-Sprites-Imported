using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayElementCount : MonoBehaviour
{
    public TextMeshProUGUI fireElemetCount;
    public TextMeshProUGUI waterElementCount;

    private void Start()
    {
        fireElemetCount =  transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        waterElementCount = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        fireElemetCount.text = "000000";
        waterElementCount.text = "9999999";
    }
}
