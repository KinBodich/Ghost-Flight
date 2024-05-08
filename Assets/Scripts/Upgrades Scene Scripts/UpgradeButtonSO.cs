using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu]
public class UpgradeButtonSO : ScriptableObject
{
    [field: SerializeField] public string UpgradeName { get; private set; }
    [field: SerializeField] public int UpgradeIncrement { get; private set; }
}
