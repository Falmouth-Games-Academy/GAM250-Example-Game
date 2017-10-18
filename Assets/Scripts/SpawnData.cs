using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "GAM250/Example/Spawn", order = 1)]
public class SpawnData : ScriptableObject
{
    [SerializeField]
    public GameObject prefab;
    [SerializeField]
    public float coolDown;
    [SerializeField]
    public int amountToSpawn;
}