using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UpgradeTypeManager
{
    public static void LoadUpgradeType(GameData data, UpgradeType upgradeType, ref float upgrade, ref byte currentLevel, ref int upgradePrice)
    {
        switch (upgradeType)
        {
            case UpgradeType.MaxSpeed:
                {
                    upgrade = data.PlayerMaxSpeed;
                    currentLevel = data.PlayerMaxSpeedLevel;
                    upgradePrice = data.PlayerMaxSpeedUpgradePrice;
                    Debug.Log($"{upgrade} {currentLevel} {upgradePrice}");
                    break;
                }
            case UpgradeType.EnginePower:
                {
                    upgrade = data.PlayerAcceleration;
                    currentLevel = data.PlayerEngineLevel;
                    upgradePrice = data.PlayerEngineUpgradePrice;
                    Debug.Log($"{upgrade} {currentLevel} {upgradePrice}");
                    break;
                }
            case UpgradeType.BrakesPower:
                {
                    upgrade = data.PlayerDeceleration;
                    currentLevel = data.PlayerBrakesLevel;
                    upgradePrice = data.PlayerBrakesUpgradePrice;
                    Debug.Log($"{upgrade} {currentLevel} {upgradePrice}");
                    break;
                }
            case UpgradeType.EleronsPower:
                {
                    upgrade = data.PlayerRotationSpeed;
                    currentLevel = data.PlayerEleronsLevel;
                    upgradePrice = data.PlayerEleronsUpgradePrice;
                    Debug.Log($"{upgrade} {currentLevel} {upgradePrice}");
                    break;
                }
        }
    }

    public static void SaveUpgradeType(GameData data, UpgradeType upgradeType, ref float upgrade, ref byte currentLevel, ref int upgradePrice)
    {
        switch (upgradeType)
        {
            case UpgradeType.MaxSpeed:
                {
                    data.PlayerMaxSpeed = upgrade;
                    data.PlayerMaxSpeedLevel = currentLevel;
                    data.PlayerMaxSpeedUpgradePrice = upgradePrice;
                    Debug.Log($"{upgrade} {currentLevel} {upgradePrice}");
                    break;
                }
            case UpgradeType.EnginePower:
                {
                    data.PlayerAcceleration = upgrade;
                    data.PlayerEngineLevel = currentLevel;
                    data.PlayerEngineUpgradePrice = upgradePrice;
                    Debug.Log($"{upgrade} {currentLevel} {upgradePrice}");
                    break;
                }
            case UpgradeType.BrakesPower:
                {
                    data.PlayerDeceleration = upgrade;
                    data.PlayerBrakesLevel = currentLevel;
                    data.PlayerBrakesUpgradePrice = upgradePrice;
                    Debug.Log($"{upgrade} {currentLevel} {upgradePrice}");
                    break;
                }
            case UpgradeType.EleronsPower:
                {
                    data.PlayerRotationSpeed = upgrade;
                    data.PlayerEleronsLevel = currentLevel;
                    data.PlayerEleronsUpgradePrice = upgradePrice;
                    Debug.Log($"{upgrade} {currentLevel} {upgradePrice}");
                    break;
                }
        }
    }
}
