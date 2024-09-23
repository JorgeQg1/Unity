# UnityAR

## Creacion de aplicacion de Realidad Aumentada

  Lo primero será instalar el paquete de Vuforia Engine en nuestro proyecto y tras ello, crear la base de datos con nuestras fotos que actuaran como targets.
  Una vez hecho esto debemos añadir a nuestra escena una cámara AR del paquete Vuforia y tantos Image Targets como imágenes queramos reconocer.

  Yo he añadido cuatro ImageTargets diferentes, uno para cada tipo de dragón que aparecerá en nuestra aplicación de realidad aumentada.

![Captura](https://user-images.githubusercontent.com/72491269/206723983-13aa7484-bdaa-49df-bf9e-49250e44bbaa.PNG)

  En esta imagen vemos como los cuatro dragones están en la misma posición y con una escala bastante pequeña, esto es asi porque una vez iniciada la escena, los scripts invisibilizan dichos dragones para solo visualizarlos cuando es reconocido su target específico y la escala es debido a la escala propia del propio target.

  A continuación se muestran ejemplos de funcionamiento de la propia aplicación con todos los tipos de dragones añadidos:

  * Dragon Azul
  
    ![blue](https://user-images.githubusercontent.com/72491269/206726250-950c863b-395e-4bd6-9e82-2f78aaba173d.gif)

  * Dragon Rojo
  
    ![red](https://user-images.githubusercontent.com/72491269/206726766-9728c259-f7e8-4d87-96e8-7be6724af50d.gif)

  * Dragon Morado
  
    ![purple](https://user-images.githubusercontent.com/72491269/206726942-0510d01f-c72e-4855-9d84-665479705057.gif)

  * Dragon Verde
  
    ![green](https://user-images.githubusercontent.com/72491269/206726835-45fd9b52-b36f-48c5-b9d0-156f804956a2.gif)
