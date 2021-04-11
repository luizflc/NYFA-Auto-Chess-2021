using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public Text p1Text;
    public int p1Energy;
    public int p2Energy;
    public int maxEnergy;
    public float energyGain;
    public float energyGainMax;
    //these are for the interval of energy gains. Energy gain is the current number the timer is on, and energyGainMax is the maximum value of the timer.
    public static Economy instance;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        p1Energy = 4;
        p2Energy = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(energyGain > 0)
        {
            energyGain -= 1 * Time.deltaTime;
        }
        else
        {
            AddCorners(1);
            p2Energy++; 
            energyGain = energyGainMax;
        }
        p1Text.text ="Energy: " + p1Energy.ToString();
        
    }

    public void AddCorners(int energy)
    {
        if(p1Energy + energy < maxEnergy)
        {
            p1Energy += energy;
        }
        else
        {
            p1Energy = maxEnergy;
        }
    }

    public void SubtractCorners(int energy)
    {
        p1Energy -= energy;

    }
}
