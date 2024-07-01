using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    // system
    public int dayLeft = 33;

    // daily
    public int battery = 100;
    public float time = 7.5f; // 24h, 0.5 == 30 minutes

    // perminant
    public int money = 100;
    public int art = 10;

    [SerializeField] private TextMeshProUGUI batteryText;
    [SerializeField] private TextMeshProUGUI dayLeftText;
    [SerializeField] private TextMeshProUGUI artText;

    private void Start()
    {
        UpdateUITexts();
    }

    public void DoArt(int art, int energy)
    {
        this.art += art;
        battery -= energy;

        UpdateUITexts();
    }

    public void GoToBed()
    {
        battery = 100;
        dayLeft -= 1;

        UpdateUITexts();
    }

    private void UpdateUITexts()
    {
        batteryText.text = battery.ToString() + "%";
        dayLeftText.text = "D-" + dayLeft.ToString();
        artText.text = art.ToString();
    }
}
