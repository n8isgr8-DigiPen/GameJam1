using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyDeleter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject, 3);
    }
}

