using System;
using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using DG.Tweening;
using UnityEngine;

public class Virus : MonoBehaviour
{
    private int _id;
    private int _hp;
    private bool _boss;
    private bool _isDestroy;

    public void Init(int ID)
    {
        _id = ID;

        var info = GameDataManager.Instance.VirusSo.GetInfo(_id);

        if (info != null)
        {
            _icon.sprite = info.Icon;
            _fx.sprite = info.FX;
            _hp = info.HP;
            _trans.localScale = info.Scale * Vector3.one;
            _fxTrans.localScale = Vector3.zero;

            if (info.IsBoss)
            {
                _boss = true;
                Manager.InGame.ShowBoss();
            }

            _trans.gameObject.AddComponent<PolygonCollider2D>();

            transform.DOMoveY(-6, 8).SetEase(Ease.Linear).OnComplete(() =>
            {
                Manager.InGame.Hp -= _hp * 2;
                DestroyE();
            });
        }
    }

    public void MinusHP()
    {
        _hp--;

        if (_hp <= 0)
        {
            DestroyE();
        }
    }

    private void DestroyE()
    {
        if (_isDestroy)
        {
            return;
        }

        if (_boss)
        {
            Manager.InGame.HideBoss();
        }

        _isDestroy = true;

        transform.DOKill();

        var info = GameDataManager.Instance.VirusSo.GetInfo(_id);

        if (info != null)
        {
            ScoreManager.Score += info.Point;
        }

        _fxTrans.DOScale(1, 0.5f).From(0).OnComplete(() => { Destroy(gameObject); });
    }

    public void Gem()
    {
        MasterAudioManager.Play2DSfx(AudioConst.Kill);
        _fxTrans.DOScale(1, 0.2f).From(0).OnComplete(() => { _fxTrans.localScale = Vector3.zero; });
        MinusHP();
    }

    public void Coin()
    {
        MasterAudioManager.Play2DSfx(AudioConst.Kill);
        DestroyE();
    }

    [SerializeField] private SpriteRenderer _icon;
    [SerializeField] private SpriteRenderer _fx;
    [SerializeField] private Transform _fxTrans;
    [SerializeField] private Transform _trans;
}