using System.Collections; // Required for Arrays & other Collections
using System.Collections.Generic; // Required to use Lists or Dictionaries
using UnityEngine; // Required for Unity
using UnityEngine.SceneManagement; // For loading & reloading of scenes

public class Main : MonoBehaviour {

static public Main S;
[Header("Set in Inspector")]
public GameObject[] prefabEnemies;
public float enemySpawnPerSecond = 0.5f;
public float enemyDefaultPadding = 1.5f;


private BoundsCheck bndCheck;
void Awake() {
S = this;
bndCheck = GetComponent<BoundsCheck>();
Invoke( "SpawnEnemy", 1f/enemySpawnPerSecond );
}

public void SpawnEnemy() {

int ndx = Random.Range(0, prefabEnemies.Length);
GameObject go = Instantiate<GameObject>( prefabEnemies[ ndx ] );

float enemyPadding = enemyDefaultPadding;
if (go.GetComponent<BoundsCheck>() != null) {

enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius );
}

Vector3 pos = Vector3.zero;
float xMin = -bndCheck.camWidth + enemyPadding;
float xMax = bndCheck.camWidth - enemyPadding;
pos.x = Random.Range( xMin, xMax );
pos.y = bndCheck.camHeight + enemyPadding;
go.transform.position = pos;
Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
}
}