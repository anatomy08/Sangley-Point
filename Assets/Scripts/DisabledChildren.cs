using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledChildren : MonoBehaviour
{
    [SerializeField] GameObject MachineGunright;
    [SerializeField] GameObject MachineGunleft;

    // Call this method to disable the specified child GameObjects
    public void DisableSpecificChildren()
    {
        MachineGunright.SetActive(false);
        MachineGunleft.SetActive(false);
    }
}
