using UnityEngine;

[System.Serializable]
public class ParallaxLayer 
{
    [SerializeField] private Transform background;
    [SerializeField] private float parallaxMultiplier;
    [SerializeField] private float imagerWithOffset = 10;

    private float imageFullWidth;
    private float imageHalfWidth;

    public void CalculateImageWidth()
    {
        imageFullWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        imageHalfWidth = imageFullWidth / 2;
    }

    public void Move(float distanceToMove)
    {
        background.position += Vector3.right * (distanceToMove * parallaxMultiplier);
    }

    public void LoopBackGround(float cameraLeftEdge, float cameraRightEdge)
    {
        float imageRightEdge = (background.position.x + imageHalfWidth) - imagerWithOffset;
        float imageLeftEdge = (background.position.x - imageHalfWidth) + imagerWithOffset;

        if(imageRightEdge < cameraLeftEdge)
        background.position += Vector3.right * imageFullWidth;
        else if (imageLeftEdge > cameraRightEdge)
        background.position += Vector3.right * -imageFullWidth;
    }
}
