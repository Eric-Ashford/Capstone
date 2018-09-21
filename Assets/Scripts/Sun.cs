using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    void Update()
    {
        // rotate main light in pseudo day/night cycle
        this.gameObject.GetComponent<Transform>().Rotate(Vector3.right * Time.deltaTime * 15, Space.Self);
    }

    // TODO: add an actual day/night cycle
}
