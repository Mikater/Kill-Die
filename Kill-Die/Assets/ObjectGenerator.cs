using UnityEngine;

[System.Serializable]
public class ObjectParameters
{
    public GameObject prefab;
    public int numObjects = 5;
    public float maxDistance = 5f;
}

public class ObjectGenerator : MonoBehaviour
{
    public ObjectParameters[] objectParams;

    void Start()
    {
        GenerateObjects();
    }

    void GenerateObjects()
    {
        foreach (var param in objectParams)
        {
            Vector3 basePosition = transform.position;

            for (int i = 0; i < param.numObjects; i++)
            {
                float angle = i * 2f * Mathf.PI / param.numObjects;
                float distance = Random.Range(0f, param.maxDistance);

                float newX = basePosition.x + distance * Mathf.Cos(angle);
                float newY = basePosition.y + distance * Mathf.Sin(angle);

                Vector3 newPosition = new Vector3(newX, newY, basePosition.z);
                Instantiate(param.prefab, newPosition, Quaternion.identity);
            }
        }
    }
}
