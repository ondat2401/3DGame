using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Border : MonoBehaviour
{
    public GameObject[] borderImages;

    public void ActiveBorder(GameObject border){
        foreach (GameObject obj in borderImages)
        {
            obj.SetActive(false);
        }

        border.SetActive(true);
    }
}
