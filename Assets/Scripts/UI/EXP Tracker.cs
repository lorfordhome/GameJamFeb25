using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EXPTracker : MonoBehaviour
{
    public Player player;
    private void Start()
    {
        player=FindAnyObjectByType<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = "EXP: "+player.currentHealth.ToString();
    }
}
