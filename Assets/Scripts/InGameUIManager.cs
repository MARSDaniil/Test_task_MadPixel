using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
namespace Game {
    public class InGameUIManager :MonoBehaviour {
        public InGameManager inGameManager;
        [Header("UI Managers")]
        public InputManager inputManager;
        public void Init() {
            inputManager.Init(this);
        }
    }
}