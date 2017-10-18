using UnityEditor;
using UnityEngine;

public class EnemyWizard : ScriptableWizard {

    public string filename;
    public GameObject prefab;
    public float coolDown;
    public int amountToSpawn;

    [MenuItem("Assets/Create/GAM250/Example/Create Enemy Wizard")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<EnemyWizard>("Create Enemy", "Create","Cancel");
    }

    private void OnWizardCreate()
    {
        var asset = ScriptableObject.CreateInstance<SpawnData>();
        asset.prefab = prefab;
        asset.coolDown = coolDown;
        asset.amountToSpawn = amountToSpawn;

        AssetDatabase.CreateAsset(asset, "Assets/Data/"+filename+".asset");
        AssetDatabase.SaveAssets();
        //Close();
    }

    private void OnWizardOtherButton()
    {
        Close();
    }
}
