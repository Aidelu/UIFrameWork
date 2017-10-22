using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
    private GameObject panda;
    private Vector3 offsetPos;//相对位置
    private Vector3 offsetRot;//相对旋转
    private float speed;

    private Vector3 targetPos;
	void Start () {
        panda = GameObject.Find(GlobalVar.ObjectName.pandaName);
        offsetPos = new Vector3(0, 2.273f, -3.73f);
        offsetRot = new Vector3(12, 0, 0);
        speed = 10.0f;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        cameraFollow();
	}

    private void cameraFollow()
    {
        targetPos = panda.transform.position + offsetPos;
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, speed * Time.deltaTime);//调整相机与玩家之间的距离
        Quaternion angel = Quaternion.Euler(offsetRot);//获取旋转角度
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, angel, speed * Time.deltaTime);
    }
}
