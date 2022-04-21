using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera: MonoBehaviour

{

    public Transform target; //Объект, вокруг которого вращаем

    public float distance = 5.0f; // Дистанция вращения

    public float xSpeed = 125.0f; // Чувствительность по оси X

    public float ySpeed = 50.0f; // Чувствительность по оси Y

    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки

    public float zoomMax = 10; // макс. увеличение

    public float zoomMin = 3; // мин. увеличение

 

    private float x = 0.0f; // угол по y

    private float y = 0.0f; // угол по x

 

    void Start()

    {

        //Инициализация начальных углов

        var angles = transform.eulerAngles;

        x = angles.y;

        y = angles.x;

    }

 

    void LateUpdate()

    {

        //Выполняем каждый кадр

        if (target)

        {

            if (Input.GetAxis("Mouse ScrollWheel") > 0) distance += zoom;

            else if (Input.GetAxis("Mouse ScrollWheel") < 0) distance -= zoom;

            distance = Mathf.Clamp(distance, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

 

            if (Input.GetKey(KeyCode.Mouse2))

            {

                //Преобразование перемещения мыши в угол поворота

                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;

                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

 

            }

 

            //Вращение камеры

            var rotation = Quaternion.Euler(y, x, 0);

            transform.rotation = rotation;

 

            //Перемещение приближение/отдаление камеры

            var position = rotation * new Vector3(0.0f, 0.0f, distance) + target.position;

            transform.position = position;

        }

    }

}
