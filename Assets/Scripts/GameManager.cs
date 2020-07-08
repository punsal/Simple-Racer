using Car;
using Controllers;
using Road.Generator;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RoadGenerator roadGenerator;
    [SerializeField] private CarController carController;
    [SerializeField] private CameraFollowController cameraFollowController;

    private void Start()
    {
        roadGenerator.Generate();
        //carController.gameObject.SetActive(true);
        //cameraFollowController.enabled = true;
    }
}
