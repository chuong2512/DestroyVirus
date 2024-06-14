using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class UseGemButton : AButton
{
    protected override void OnClickButton()
    {
        if (Data.Player.Gem > 0)
        {
            Data.Player.Gem--;
            Use();
        }
    }

    private void Use()
    {
        
        Manager.InGame.UseGem();
    }

    protected override void OnStart()
    {
    }
}