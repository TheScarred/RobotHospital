using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGenerator : MonoBehaviour
{
    [Range(0, 500f)]
    public float power = 300f;

    public Battery battery;

    public float consumeTime; 
    private float consumeRate;
    private float t = 0.0f;
    private static float batteryCap = 130f;

    // Start is called before the first frame update
    void Start()
    {
        //battery = new Battery();
        consumeRate = 1f / consumeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (battery != null && power <= 500f)
            Recharge();
    }

    public void Recharge()
    {
        if (t <= 1f)
        {
            t += Time.deltaTime * consumeRate;
            battery.charge = batteryCap * (1 - t);
            power += Time.deltaTime * consumeRate * batteryCap;
        }

        if (power > 500f)
            power = 500f;

        if (battery.charge <= 0)
            KillBattery();
    }

    public void KillBattery()
    {
        battery = null;
    }

}
