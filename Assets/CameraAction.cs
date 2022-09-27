using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class CameraAction : MonoBehaviour
{
    [SerializeField] private Camera photoCamera;
    
    [SerializeField] private bool isGrab;

    //[SerializeField] private Image photograph;

    [SerializeField] private GameObject photograph;

    [SerializeField] private Transform createPhotoPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [Button]
    public void TakePhoto()
    {
        if (isGrab)
        {
            var takePhoto = RTImage(photoCamera);

            //photograph.sprite = Sprite.Create(takePhoto , new Rect(0 , 0 , takePhoto.width , takePhoto.height) , new Vector2(0,0));
            GameObject photo = Instantiate(photograph, createPhotoPos.position, createPhotoPos.transform.rotation);
            GameObject photoImage = photo.transform.GetChild(0).gameObject;

            var image = photoImage.GetComponent<MeshRenderer>();
        
            image.material.SetTexture("_BaseMap", takePhoto);
        }
    }
    
    Texture2D RTImage(Camera camera)
    {
        var currentRT = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;
        
        camera.Render();
        
        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();
        
        RenderTexture.active = currentRT;
        return image;
    }
    


    public void SetGrabbable(bool _isGrab)
    {
        isGrab = _isGrab;
    }
}
