using UnityEngine;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public GameObject winText;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has reached the goal");

            winText.SetActive(true);
        }
    }
}