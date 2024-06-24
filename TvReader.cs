using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TvReader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UiManager.instance.inputPanel.SetActive(true);
            UiManager.instance.SetCurser(true);
            FindObjectOfType<PlayerController>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            UiManager.instance.inputPanel.SetActive(false);
            UiManager.instance.SetCurser(false);
            FindObjectOfType<PlayerController>().enabled = true;
        }
    }
}
