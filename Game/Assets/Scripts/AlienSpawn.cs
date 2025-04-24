using UnityEngine;

public class alienSpawn : MonoBehaviour
{
  // Alien model and number that is spawned.
  [SerializeField] private GameObject alien;
  [SerializeField] private int numberOfAliens = 20;
  // Range of alien model positions, based off of locations in the living room. (Spawn points of windows unknown at this time.)
  [SerializeField] private Vector3 minSpawnPosition = new Vector3(1.3f, -.6f, -3.5f);
  [SerializeField] private Vector3 maxSpawnPosition = new Vector3(.03f, -.6f, .3f);
  // Range of spawn times.
  [SerializeField] private float minSpawnInterval = 1f;
  [SerializeField] private float maxSpawnInterval = 5f;

  private void Start()
  {
      StartCoroutine(SpawnAliens());
  }
  // Alien spawner, loops through different positions at spawn random spawn time.
  private IEnumerator SpawnAliens()
  {
      for (int i = 0; i < numberOfAliens; i++)
      {
          float delay = Random.Range(minSpawnInterval, maxSpawnInterval);
          yield return new WaitForSeconds(delay);

          Vector3 position = new Vector3(
              Random.Range(minSpawnPosition.x, maxSpawnPosition.x),
              Random.Range(minSpawnPosition.y, maxSpawnPosition.y),
              Random.Range(minSpawnPosition.z, maxSpawnPosition.z)
          );

          Instantiate(alien, position, Quaternion.identity);
      }
  }
}
