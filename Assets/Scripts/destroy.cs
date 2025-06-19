using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy")
        {
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log(other.gameObject.tag);
        }
    }

}
