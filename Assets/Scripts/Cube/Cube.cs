using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.CubeNS {
    public class Cube :MonoBehaviour {
        Rigidbody rigidbody;

        [SerializeField] CubeView cubeView;
 
        public int currNum;
        public int currIntOfArr;

        public int maxRandomStartInt = 4;
        [Space]
        [Header("Move")]
        private float horizontalSpeed = 1300;
        private float verticalSpeed = 300;
        private void Awake() {
            rigidbody = GetComponent<Rigidbody>();
            Init();
        }
        public void Init() {

            cubeView.Init();

            GenerateNum();
            SetNewParam();
        }

        private void GenerateNum() => 
            currIntOfArr = Random.Range(0, maxRandomStartInt);

        private void SetNewParam() {
            cubeView.SetNewParam(currIntOfArr);
            currNum = (int)Mathf.Pow(2, currIntOfArr + 1);
        }

        public void MoveForward() => Move(Vector3.forward, horizontalSpeed);
        public void MoveToSide(Vector3 vector) => rigidbody.velocity = vector;
        public Vector3 Position {
            get {return transform.position; }
        }
        private void MoveUp() => Move(Vector3.up, verticalSpeed);

        private void Move(Vector3 vector, float speed) => rigidbody.AddForce(vector * speed);

        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.TryGetComponent<Cube>(out Cube otherCube)) {
                if (otherCube.currIntOfArr == currIntOfArr) Debug.Log("similar num");
            }
        }
    }
}