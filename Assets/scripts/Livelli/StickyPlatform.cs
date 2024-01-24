using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Personaggio")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Personaggio")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
