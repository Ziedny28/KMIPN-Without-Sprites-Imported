using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public GameObject myPlayer;
    private SpriteRenderer myPlayerSprite;
    public Transform left_hand,right_hand;

    private void Start()
    {
         myPlayerSprite = myPlayer.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        myPlayerSprite.flipX = false;
        transform.position = right_hand.position;

        if (rotationZ < -90 || rotationZ > 90)
        {
            transform.position = left_hand.position;
            myPlayerSprite.flipX = true;

            if (myPlayer.transform.eulerAngles.y == 0)
            {

                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);


            }
            else if (myPlayer.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);

            }
        }
    }
}
