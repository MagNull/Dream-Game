using UnityEngine;

public class BackgroundHelper : MonoBehaviour {
    private float startPosX, lengthX,startPosY, lengthY;
    public GameObject camera;
    public float paralaxEffect;
 
    void Start() {
        startPosX = transform.position.x;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosY = transform.position.y;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }
 
    void FixedUpdate() {
        float tempX = camera.transform.position.x * (1 - paralaxEffect);
        float distX = camera.transform.position.x * paralaxEffect;
        float tempY = camera.transform.position.y * (1 - paralaxEffect);
        float distY = camera.transform.position.y * paralaxEffect;
        // двигаем фон с поправкой на paralaxEffect
        transform.position = new Vector3(startPosX + distX, startPosY + distY, transform.position.z);
 
        // если камера перескочила спрайт, то меняем startPos
        if (tempX > startPosX + lengthX)
            startPosX += lengthX;
        else if (tempX < startPosX - lengthX)
            startPosX -= lengthX;
        
        if (tempY > startPosY + lengthY)
            startPosY += lengthY;
        else if (tempY < startPosY - lengthY)
            startPosY -= lengthY;
    }
}

