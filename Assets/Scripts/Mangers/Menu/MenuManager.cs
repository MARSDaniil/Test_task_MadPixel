using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.CubeNS;
namespace Menu {
    public class MenuManager :MonoBehaviour {
        [HideInInspector] public List<GameObject> collisionCube;

        private void Update() {
            if (collisionCube.Count > 0) {
                MenuCube localCub = collisionCube[0].GetComponent<MenuCube>();
                localCub.currIntOfArr++;
                localCub.SetNewParam();
                int i = 1;
                do {
                    collisionCube[i].gameObject.SetActive(false);
                    i++;
                }
                while (i < collisionCube.Count);
                collisionCube.Clear();
            }
        }
    }
}