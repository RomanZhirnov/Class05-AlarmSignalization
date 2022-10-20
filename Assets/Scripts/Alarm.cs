using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Alarm : MonoBehaviour
{
    public event Action Entered;
    public event Action Leaving;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            Entered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
           Leaving?.Invoke();
        }
    }
}


