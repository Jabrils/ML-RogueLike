using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walker : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {
        Destroy(other.gameObject);
    }
}
