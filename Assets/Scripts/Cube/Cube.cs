using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.CubeNS {
    public class Cube :BaseCube {
        [SerializeField] InGameManager inGameManager;

        protected override void SetValueToManagerList() {
            inGameManager.collisionCube.Add(this.gameObject);
        }

        private void Update() {
            if(transform.position.x > inGameManager.Boards.x) transform.position
                = new Vector3(inGameManager.Boards.x, transform.position.y, transform.position.z);
            else if(transform.position.x < -inGameManager.Boards.x) transform.position
                 = new Vector3(-inGameManager.Boards.x, transform.position.y, transform.position.z);
            if(transform.position.z > inGameManager.Boards.y) transform.position
                 = new Vector3(transform.position.x, transform.position.y, inGameManager.Boards.y);
        }

        protected override void FoundManager() {
            GameObject gameObject = GameObject.Find("InGameManager");
            inGameManager = gameObject.GetComponent<InGameManager>();
        }

       
    }
}