using System;
using System.Collections;
using ChuongCustom;
using CI.WSANative.Common;
using CI.WSANative.Store;
using UnityEngine;

public static class IAPKey
{
    public const string C_PACK1 = "mua_vang_goi_1";
    public const string C_PACK2 = "mua_vang_goi_2";
    public const string C_PACK3 = "mua_vang_goi_3";
    public const string C_PACK4 = "mua_vang_goi_4";
}

public class IAPManager : PersistentSingleton<IAPManager>
{
    public static Action OnPurchaseSuccess;

    private bool _isBuyFromShop;

    void Awake()
    {
        WSANativeCore.Initialise();
    }

    //store id get from microsoft partner 
    public void BuyProductID(string storeid, int points = 0)
    {
        string id = String.Empty;

        switch (storeid)
        {
            case IA.C_PACK1:
                id = IAPKey.C_PACK1;
                break;
            case IA.C_PACK2:
                id = IAPKey.C_PACK2;
                break;
            case IA.C_PACK3:
                id = IAPKey.C_PACK3;
                break;
            case IA.C_PACK4:
                id = IAPKey.C_PACK4;
                break;
        }

        Debug.LogError($"Click + {id}");
        WSANativeStore.RequestPurchase(id, result =>
        {
            UnityEngine.Debug.Log(result.Status);
            if (result.Status == WSAStorePurchaseStatus.Succeeded)
            {
                // do something here to add point value
                OnPurchaseSuccess?.Invoke();
            }
        });
    }
}