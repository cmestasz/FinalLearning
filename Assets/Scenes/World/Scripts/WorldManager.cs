using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] courseBackWarps;

    // Start is called before the first frame update
    void Start()
    {
        if (TowerData.course != -1)
        {
            Vector2 pos = courseBackWarps[TowerData.course].position;
            player.transform.position = new Vector3(pos.x, pos.y, player.transform.position.z);
            Camera.main.transform.position = new Vector3(pos.x, pos.y, Camera.main.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
