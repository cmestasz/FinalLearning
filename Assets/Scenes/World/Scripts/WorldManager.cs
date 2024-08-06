using TMPro;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] courseBackWarps;
    [SerializeField] private TMP_Text[] towerTexts;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("Music"));
        if (TowerData.course != -1)
        {
            Vector2 pos = courseBackWarps[TowerData.course].position;
            player.transform.position = new Vector3(pos.x, pos.y, player.transform.position.z);
            Camera.main.transform.position = new Vector3(pos.x, pos.y, Camera.main.transform.position.z);
        }

        for (int i = 0; i < towerTexts.Length; i++)
        {
            towerTexts[i].text = GlobalStorage.GetCourse(i).name;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
