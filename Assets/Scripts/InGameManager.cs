using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.CubeNS;
namespace Game {
    public class InGameManager :MonoBehaviour {

        public InGameUIManager inGameUIManager;

        public GameObject cube;
        public Cube cubeCube;
        private void Awake() {
            Init();
        }
        private void Init() {
            inGameUIManager.Init();
            cubeCube = cube.GetComponent<Cube>();
        }
        
    }
}