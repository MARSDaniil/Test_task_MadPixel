using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Game.Cube {
    public class Cube :MonoBehaviour {
        Rigidbody rigidbody;

        [SerializeField] List<TextMeshProUGUI> cubeNum;
        [SerializeField] MeshRenderer meshRenderer;
        [SerializeField] CubeInfo cubeInfo;

        public int currNum;
        public int currIntOfArr;

        public int maxRandomStartInt = 4;
        private void Awake() {
            rigidbody = GetComponent<Rigidbody>();
            Init();
        }
        public void Init() {

            if (meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();
            GenerateNum();
            SetNewParam();
        }

        private void GenerateNum() => 
            currIntOfArr = Random.Range(0, maxRandomStartInt);

        private void SetNewParam() {
            currNum = cubeInfo.numOfCube[currIntOfArr];
            int i = 0;
            while (i < cubeNum.Count) {
                cubeNum[i].text = currNum.ToString();
                i++;
            }
            meshRenderer.material = cubeInfo.colorsOfCube[currIntOfArr];
        }
    }
}