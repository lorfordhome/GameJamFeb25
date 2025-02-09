using PlasticBand.Devices;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public enum Colours { green,red,blue};
    public enum Upgrades
    {
        speed, bulletCount, bulletSize, barrier
    }
    Upgrades upgradeType = Upgrades.speed;
    public Colours buttonCol=Colours.green;
    public string upgradeText = "Raccoon time";
    public GameObject textBox;
    TextMeshProUGUI upgradeTextBox;
    Turntable turntable;


    void OnEnable()
    {
        upgradeTextBox=textBox.GetComponent<TextMeshProUGUI>();
        turntable = Turntable.current;

        switch (buttonCol)
        {
            case Colours.blue:
                {
                    upgradeType = Upgrades.speed;
                    upgradeText = "Increase bullet speed";
                    
                    return;
                }
            case Colours.green:
                {
                    upgradeType = Upgrades.bulletCount;
                    upgradeText = "More bullets per shot";
                    return;
                }
            case Colours.red:
                {
                    upgradeType = Upgrades.bulletSize;
                    upgradeText = "Bigger bullets";
                    
                    return;
                }
        }
        upgradeTextBox.text = upgradeText;
    }

    void ApplyUpgrade()
    {
        GunController gunController=FindAnyObjectByType<GunController>();
        if (upgradeType == Upgrades.speed)
        {
            gunController.bulletSpeed++;
            gunController.fireRate -= 0.1f;
        }
        else if (upgradeType == Upgrades.bulletCount)
        {
            gunController.shotsBeforeReload++;
        }
        else if (upgradeType == Upgrades.bulletSize)
        {
            gunController.bulletScale += 0.1f;
        }

        GameManager.instance.EndLevelUp();
    }


    void Update()
    {
        switch (buttonCol)
        {
            case Colours.blue:
                {
                  
                    if (turntable.rightTableBlue.wasReleasedThisFrame)
                    {
                        ApplyUpgrade();
                    }
                    return;
                }
            case Colours.green:
                {
                    
                    if (turntable.rightTableGreen.wasReleasedThisFrame)
                    {
                        ApplyUpgrade();
                    }
                    return;
                }
            case Colours.red:
                {
                    
                    if (turntable.rightTableRed.wasReleasedThisFrame)
                    {
                        ApplyUpgrade();
                    }
                    return;
                }
        }
    }
}
