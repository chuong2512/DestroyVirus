using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChuongCustom
{
    public static class InGameAction
    {
        public static Action<int> ChangeHP;
    }

    public class InGameManager : Singleton<InGameManager>
    {
        [SerializeField] private GameObject _bossIcon;
        [SerializeField] private DOTweenAnimation _coin;
        [SerializeField] private DOTweenAnimation _gem;
        private int _hp = 100;

        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                InGameAction.ChangeHP?.Invoke(_hp);

                if (_hp <= 0 && isPlay)
                {
                    Lose();
                }
            }
        }

        [SerializeField] public int PriceToPrice = 1;
        public bool isPlay;

        private void Start()
        {
            ScoreManager.Reset();

            ContinueGame();
            isPlay = true;
        }

        [Button]
        public void Win()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.Result);
            //todo:
        }

        [Button]
        public void Lose()
        {
            Stop();
            isPlay = false;
            MasterAudioManager.Play2DSfx(AudioConst.Lose);
            Manager.ScreenManager.OpenScreen(ScreenType.Lose);
            //todo:
        }

        public void Stop()
        {
            Time.timeScale = 0;
        }

        public void ContinueGame()
        {
            Time.timeScale = 1;
        }

        public void UseGem()
        {
            _gem.gameObject.SetActive(true);
            _gem.DOPlay();

            var virus = FindObjectsOfType<Virus>();

            foreach (var v in virus)
            {
                v.Gem();
            }
        }

        public void UseCoin()
        {
            _coin.gameObject.SetActive(true);
            _coin.DOPlay();

            var virus = FindObjectsOfType<Virus>();

            foreach (var v in virus)
            {
                v.Coin();
            }
        }

        public void ShowBoss()
        {
            _bossIcon.SetActive(true);
        }

        public void HideBoss()
        {
            _bossIcon.SetActive(false);
        }

        public void Continue()
        {
        }
    }
}