using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickGun : MonoBehaviour
{
    public UnityEvent changeFocus;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            changeFocus?.Invoke();
        }
    }
}
