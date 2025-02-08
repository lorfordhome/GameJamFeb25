using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    public Player player;
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = player.currentHealth.ToString();
    }
}
