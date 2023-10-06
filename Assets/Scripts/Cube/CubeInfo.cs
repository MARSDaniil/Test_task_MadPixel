using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Cube {
    [CreateAssetMenu(menuName = "Cube state")]
    public class CubeInfo :ScriptableObject {
        public List<int> numOfCube = new List<int> { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048
        , 4096, 8192, 16384, 32768};

        public List<Material> colorsOfCube;

    }
}