using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class UseCoinButton : AButton
{
    protected override void OnClickButton()
    {
        if (Data.Player.Coin > 0)
        {
            Data.Player.Coin--;
            Use();
        }
    }

    private void Use()
    {
        Manager.InGame.UseCoin();
    }

    protected override void OnStart()
    {
    }
}