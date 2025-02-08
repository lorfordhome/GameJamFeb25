using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = player.currentHealth.ToString();
    }
}
