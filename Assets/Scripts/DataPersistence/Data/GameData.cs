using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float PlayerMaxSpeed;
    public float PlayerAcceleration;
    public float PlayerDeceleration;
    public float PlayerIdleSpeed;
    public float PlayerRotationSpeed;
    public int PlayerMissileCount;
    public float PlayerMissileLaunchDelay;
    public int RocketSpeedIncrement;
    public float RocketReloadTime;

    public byte PlayerMaxSpeedLevel;
    public int PlayerMaxSpeedUpgradePrice;

    public byte PlayerEngineLevel;
    public int PlayerEngineUpgradePrice;

    public byte PlayerBrakesLevel;
    public int PlayerBrakesUpgradePrice;

    public byte PlayerEleronsLevel;
    public int PlayerEleronsUpgradePrice;

    public int MoneyAmount;

    public GameData()
    {
        PlayerMaxSpeed = 122.5f;
        PlayerAcceleration = 2f;
        PlayerDeceleration = 5f;
        PlayerIdleSpeed = 100f;
        PlayerRotationSpeed = 50f;
        PlayerMissileCount = 1;
        PlayerMissileLaunchDelay = 1f;
        RocketSpeedIncrement = 10;
        RocketReloadTime = 10;

        PlayerMaxSpeedLevel = 0;
        PlayerMaxSpeedUpgradePrice = 200;

        PlayerEngineLevel = 0;
        PlayerEngineUpgradePrice = 200;

        PlayerBrakesLevel = 0;
        PlayerBrakesUpgradePrice = 200;

        PlayerEleronsLevel = 0;
        PlayerEleronsUpgradePrice = 200;

        MoneyAmount = 0;
    }
}
