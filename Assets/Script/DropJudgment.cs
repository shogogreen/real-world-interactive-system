using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropJudgment : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "DropJudgment")
        {
            Debug.Log("Clear");
            Destroy(gameObject);
        }
    }
}
