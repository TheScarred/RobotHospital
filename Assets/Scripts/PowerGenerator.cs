using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGenerator : MonoBehaviour
{
    [Range(0, 500f)]
    public float power = 500f;

    public Battery battery;

    public float batteryConsumeTime, powerConsumeTime; 
    private float powerConsumeRate, batteryConsumeRate;
    private float u = 0.0f, v = 0.0f;
    private static float batteryCap = 130f, powerCap = 500f;

    [SerializeField]
    Material batterySprite;
    // Start is called before the first frame update
    void Start()
    {
        battery = ScriptableObject.CreateInstance<Battery>();
        batteryConsumeRate = 1f / batteryConsumeTime;
        powerConsumeRate = 1f / powerConsumeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (battery != null && power <= 500f)
            Recharge();
        else if (power > 0)
            Spend();
        
        UpdateSprite();
    }

    public void Recharge()
    {
        if (u <= 1f)
        {
            u += Time.deltaTime * batteryConsumeRate;
            battery.charge = batteryCap * (1 - u);
            power += Time.deltaTime * batteryConsumeRate * batteryCap;
        }

        PowerCheck();

        if (battery.charge <= 0)
            KillBattery();
    }

    public void Spend()
    {
        if (v <= 1f)
        {
            v += Time.deltaTime * powerConsumeRate;
            power -= Time.deltaTime * powerConsumeRate * powerCap;
        }

        PowerCheck();
    }

    public void PowerCheck()
    {
        if (power > 500f)
            power = 500f;

        else if (power <= 0)
            power = 0;
        
    }

    public void UpdateSprite()
    {
        batterySprite.SetFloat("_amount", power / 500.0f);
    }

    public void KillBattery()
    {
        battery = null;
        v = 0;
    }

}
