using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCubeTest : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().DamagePlayer(15);

            this.gameObject.SetActive(false);
        }
    }
}
