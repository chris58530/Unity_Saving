using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _.Scripts.Player;
using UniRx;

namespace _.Scripts.UI
{
    public class ContextModel : MonoBehaviour
    {
        public ReactiveProperty<float> hpValue = new ReactiveProperty<float>();
        public ReactiveProperty<float> abilityValue = new ReactiveProperty<float>();
        private void Awake()
        {
            //之後使用異步加仔讀取玩家資料
            // var player = FindObjectOfType<PlayerController>();
            

        }
    }
}