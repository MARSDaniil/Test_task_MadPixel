using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.CubeNS;
namespace Game {
    public class InGameManager :MonoBehaviour {

        public InGameUIManager inGameUIManager;
        [Header("MainCube")]
        [SerializeField] GameObject cubePrefab;
        [SerializeField] private Vector3 startPosition = new Vector3(0, 0.5f, 6.20f);
        
        public GameObject CubeGO {
            get { return cube; }
        }
        private GameObject cube;
        private Cube cubeCube;

        [SerializeField] private float timeBetweenChangeCube = 1f;
        [Header("Start Generation Prefabs")]
        [SerializeField] List<Vector3> startPositionCubes;

        [Header("Boards")]
        [SerializeField] Vector2 boards;

        [HideInInspector] public List<GameObject> collisionCube;

        //score

        public int Score {
            set { score += value; }
            get { return score; }
        }
        private int score;

        public Vector2 Boards {
            get { return boards; }
        }
        private void Awake() {
            Init();
        }
        private void Init() {
            inGameUIManager.Init();
            NewCube();
            GenerateOtherCubs();
        }
        
        public void NewCube() {
            cube = InstantiateGameObjects(cubePrefab, startPosition);
            cubeCube = cube.GetComponent<Cube>();
            cubeCube.Init(this);
        }

        private void GenerateOtherCubs() {
            int i = 0;
            while (i < startPositionCubes.Count) {
                if (RandomBool()) {
                    GameObject gameObject = InstantiateGameObjects(cubePrefab, startPositionCubes[i]);
                    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    gameObject.GetComponent<Cube>().Init(this);
                }
                i++;
            }
        }

        private GameObject InstantiateGameObjects(GameObject gameObject, Vector3 vector) {
            return Instantiate(gameObject, vector, Quaternion.identity);
        }

        public void RechargeCubeCoroutine() => StartCoroutine(RechargeCube()); 

        private IEnumerator RechargeCube() {
            inGameUIManager.inputManager.Waintig = true;
            yield return new WaitForSeconds(timeBetweenChangeCube);
            NewCube();
            inGameUIManager.inputManager.Waintig = false;
        }
        private bool RandomBool() { return Random.value > 0.5f;}

        private void Update() {
            if(collisionCube.Count > 0) {
                Cube localCub = collisionCube[0].GetComponent<Cube>();
                localCub.currIntOfArr++;
                localCub.SetNewParam();
                score += localCub.currNum;
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