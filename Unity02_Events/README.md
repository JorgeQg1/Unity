# UnityEvents

En esta ocasion nos adentramos a comprobar como funcionan los eventos en unity

* ### 1- Creamos una escena simple en Unity, con dos objetos: Notificador y Suscriptor y probamos el código de las transparencias.

  ![1o](https://user-images.githubusercontent.com/72491269/198439717-7e586f93-cb95-406d-96b9-149237d592cd.gif)

  Como podemos observar, nuestra esfera es la que actua como notificador y nuestro cilindro de respuesta. Una vez pasados 1000 frames, se lanza el evento que es capturado por el cilindro mostrando el numero de frames pasados y un mensaje por consola. Podemos verlo mas detalladamente en la siguiente foto:
  
  ![P3_Console](https://user-images.githubusercontent.com/72491269/198441182-14d7e299-f332-479c-b267-1cb547e6347e.PNG)
  
  Y tambien podemos observar como se le asigna un objeto como notificador en el inspector de elementos:
  
  ![P3_Inspector](https://user-images.githubusercontent.com/72491269/198443921-80f02467-135d-4369-9720-b9e7000d03a8.PNG)

  El codigo responsable de este funcionamiento se encuentra en los scripts llamados: Notificador.cs y Respuesta.cs
  
* ### 2- Creamos una escena en Unity, con objetos de tipo A (Esferas), B (Cilindros) y un único objeto C (Cubo) con los siguientes comportamientos:

  * #### 2.1- Cuando el jugador colisiona con un objeto de tipo B, los objetos A se acercan al objeto C. Cuando toca algún objeto A se incrementa el tamaño de cualquier objeto B
    ![2o](https://user-images.githubusercontent.com/72491269/198443444-459911e3-80f8-4fed-8187-3293eee233b4.gif)
  
    Ahora podemos ver como al colisionar con los cilindros, las esferas se acercan al cubo y cuando colisionamos con las esferas, los cilindros aumentan su tamaño.
    Los scripts encargados de dicho comportamiento son:
      * TypeACollition.cs: script asignado a los cilindro que se ejecuta cuando se colisiona con una esfera.
      * TypeBCollition.cs: script asignado a las esferas que se ejecuta cuando se colisiona con un cilindro
  
  * #### 2.2- Cuando el jugador se aproxima al objeto de tipo C, los objetos de tipo A cambian su color y saltan y los objetos de tipo B se orientan hacia un objetivo ubicado en la escena con ese propósito.
  
    ![3o](https://user-images.githubusercontent.com/72491269/198444637-a50ab717-10b6-47a8-9ce7-c547c9a05397.gif)

    Por ultimo comprobamos que al acercarnos al cubo, las esferas comienzan a cambiar de color y saltar y los cilindros apuntan a un GameObject Quad colocado a la izquierda de la escena.
    Los scripts encargados de dicho comportamiento son:
      * TypeACloseTo.cs: script asignado a las esferas que se ejecuta cuando se acerca al cubo.
      * TypeBCloseTo.cs: script asignado a los cilindros que se ejecuta cuando se acerca al cubo.
      
  El script encargado de lanzar dichos eventos se llama: PlayerNotifier
