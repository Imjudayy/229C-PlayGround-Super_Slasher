using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] coins;
    public float xRange;
    public float zRange;
    
    void Start()
    {
        InvokeRepeating("Spawn", 15, 10);
    }

   
    void Update()
    {
        

    }

    private void Spawn()
    {
        Vector3 randomPos = new Vector3(Random.Range(-xRange, xRange), transform.position.y, Random.Range(-zRange, zRange));
        int coinIndex = Random.Range(0, coins.Length);
        Instantiate(coins[coinIndex], randomPos, coins[coinIndex].transform.rotation);
    }

}
