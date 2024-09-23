# UnityPhysics

En esta ocasion nos adentramos a comprobar como funciona el motor de fisicas

* ### Comprobamos el comportamiento de dos objetos sin fisicas:

  ![1o](https://user-images.githubusercontent.com/72491269/195809518-134d085c-31ff-4f58-b7c7-5b178a1b07ca.gif)

  Como podemos observar, al no ponerle fisicas a los objetos, los objetos se quedan inmoviles en su posicion inicial, sin que les afecte la gravedad.

* ### Luego le colocamos fisicas solo a la esfera:

  ![2o](https://user-images.githubusercontent.com/72491269/195812995-dc421b82-0d7f-4b3e-af76-17402b16559c.gif)

  Ahora al colocarle fisicas a la esfera comprobamos que la esfera cuenta con gravedad y todas las propiedades fisicas posibles.

* ### Ahora le colocamos fisicas a ambos objetos:

  ![3o](https://user-images.githubusercontent.com/72491269/195813946-06d27f08-7df6-4c61-a5aa-0992cc64257a.gif)

  Ahora al colocarle fisicas a ambos comprobamos que la esfera y el cubo cuentan con gravedad y todas las propiedades fisicas posibles.

* ### Lo siguiente será modificar el peso de la esfera para que pese 10 veces mas que el cubo.

  ![4o](https://user-images.githubusercontent.com/72491269/195816017-564ab10a-6968-41dd-8bfc-60947da88605.gif)

  Comprobamos que al pesar mas que antes la fuerza que ejerce sobre el cubo al caer es mucho mayor y por ello el cubo modifica su trayectoria.

* ### A continuacion la esfera tiene físicas y el cubo es de tipo IsTrigger.

  ![5o](https://user-images.githubusercontent.com/72491269/196044281-a2fb60c0-8ee9-48e1-8da4-6b0609bc8741.gif)
  
  Podemos observar como al chocar la esfera con el cubo, se detecta dentro de un metodo llamado OnTriggerEnter, el cual cambia su posicion a la inicial y le baja su velocidad a 0. Esto ocurre ya que nuestro cubo ahora mismo no actua como colisionador si no que deja pasar a traves suya cualquier objeto que pase por su posicion. Al poseer esta propiedad podemos hacer uso de tres fases que contiene dicho objeto: OnTriggerEnter, OnTriggerStay y OnTriggerExit.
  
  El codigo del script creado para dicho ejemplo se puede ver en el fichero: TriggerTry.cs

* ### Ahora la esfera tiene físicas, el cubo es de tipo IsTrigger y tambien tiene físicas.

  ![6o](https://user-images.githubusercontent.com/72491269/196044950-16526634-b70e-425d-b74a-60a071df9cac.gif)
  
  Ahora el cubo cae porque tiene fisicas pero como sigue actuando como objeto que no colisiona, si no que detecta si algo lo atraviesa, entonces traspasa el suelo y sigue cayendo.
  
* ### Por ultimo, la esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo, se impide la rotación del cubo sobre el plano XZ.

  ![7o](https://user-images.githubusercontent.com/72491269/196045850-f76b8130-a541-4940-bce7-f4f1c95547f3.gif)
  
  Ahora al colocarle fisicas a ambos comprobamos que la esfera y el cubo cuentan con gravedad y todas las propiedades fisicas posibles. Ademas, comprobamos como ejerce mas fuerza la esfera sobre el cubo al pesar 10 veces mas que el cubo aunque al impedir la rotacion sobre el plano X y Z podemos ver como el cubo no se tumba sobre sus lados al caer aun siendo golpeado por la esfera.

* ### Para el ejercicio dos, se nos pide hacer un script que haga que nuestro jugador pueda moverse por los ejes ya creados, horizontal y vertical.

  ![8o](https://user-images.githubusercontent.com/72491269/199381299-c985f496-7a35-4477-8668-42117f03f40d.gif)
  
  Podemos ver que si se presiona algun boton del eje vertical (w, s, flecha arriba o flecha abajo) nuestro cubo se movera al frente (w o flecha arriba) o de espaldas (s o flecha abajo) en base a una velocidad establecida y la cual se puede modificar en el inspector ya que es publica. Tambien si es presionado algun boton del eje horizontal (a, d, flecha izquierda o flecha derecha) nuestro cubo rotara en el eje OY tanto hacia la izquierda (valores negativos) como a la derecha (valores positivos).
  
* ### Para finalizar en el ultimo apartado se nos pide que creemos una escena que cumpla diferentes requisitos:
  
  * #### Se deben incluir varios cilindros sobre la escena. Cada vez que el objeto jugador colisione con alguno de ellos, deben aumentar su tamaño y el jugador aumentar puntuación. Agregar cilindros de tipo A, en los que además, si el jugador pulsa la barra espaciadora lo mueve hacia fuera de él y cilindros tipo B, que se alejen del jugador cuando esté próximo.
    
    ![9o](https://user-images.githubusercontent.com/72491269/199408036-9d8f98b9-c0d4-4ec4-a044-02d3dc802918.gif)
    
    TODO:COMENTAR

  * #### Ubicar un tercer objeto que sea capaz de detectar colisiones y que se mueva con las teclas: I, L, J, M. Debes ubicar cubos que que aumentan de tamaño cuando se le acerca una esfera y que disminuye cuando se le acerca el jugador.
    
    ![10o](https://user-images.githubusercontent.com/72491269/199408717-ea927b3e-ab3e-4425-89c1-bf0c6e8db7df.gif)
    
    TODO:COMENTAR
