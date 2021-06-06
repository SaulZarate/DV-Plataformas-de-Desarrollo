# Trabajo Practico 2 - Grupo 4

## 🏨 Agencia de Viajes 🏨

Mediante la implementeacion del apartado visual tenemos como primer form una interfaz de logeo y de registro en el que se muestran estos 2 apartados:

* Login :
En la interfaz de logeo tenemos la opción de ingresar con nuestro DNI y una contraseña que previamente habremos puesto en el registro. El usuario registrado tendra 3 intentos para realizar un login de manera correcta, si estos 3 intentos no se realizan de manera satisfactoria el usuario con el que se esta intentando ingresar sera bloqueado y solo un administrador podra realizar el desbloqueo. 
En caso de no recordar la contraseña debajo del boton LOGIN se encuentra una opción de recuperación que nos permitira cambiarla colocando los datos de usuario, nombre, mail y la nueva contraseña que queremos asignar.

* Registro :
En la interfaz de Registro tenemos 4 campos a completar:
  * Dni (En este campo solo se aceptan valores numericos)
  * Nombre
  * Contraseña
  * Mail
Dentro de este apartado se encuentra un checkbox (¿Es Admin?) que nos permite a los administradores crear un usuario admin desde la interfaz de registro.

## 👤 Vista Usuario 👤:
Una vez logeados: 
- En la parte superior se podra ver el nombre de la persona conectada.
- En la parte inferior izquierda tenemos un boton para cerrar sesion. 
- En la parte izquierda de la aplicación Se pueden ver 2 opciones, la opción de buscar alojamientos y mis reservaciones:

En buscar Alojamientos dentro de esta opción podremos elegir los distintos tipos de alojamientos que nos ofrece la aplicacion. Tenemos distintas herramientas para realizar filtrados para nuestras preferencias, entre estos filtrados estan: 
  
  * Tipo: Hoteles, Cabañas o las dos opciones juntas.
  * Ciudad: Las diferentes ciudades a elegir.
  * Barrio: Los diferentes barrios a elegir.
  * Precio min: Se puede colocar un precio minimo para el filtrado.
  * Precio max: Se puede colocar un precio maximo para el filtrado.
  * Estrella: La cantidad de estrellas de los hoteles.
  * Personas: La cantidad de personas para el alojamiento.

  Una vez completadas estas opciones a la derecha se encuentra un boton filtrar que ejecuta estas preferencias y nos lo muestra en un grid view en la parte inferior de la app.

  Debajo de las opciones de filtrado encontramos el apartado fechas que nos permite elegir la cantidad de dias que queremos reservar el alojamiento. Hay 2 opciones:
  
  * Fecha de ida: En la fecha de ida colocaremos el dia en el que llegaremos al alojamiento 
  * Fecha de vuelta: En la fecha de vuelta colocaremos el dia en el que nos iremos del alojamiento
  Para esto se nos va a abrir un panel tipo calendario en donde podremos marcar dia,mes y año.

  En la parte derecha del apartado Fechas se encuentra la opcion de Ordenar por. Aqui podremos ordernar la busquedad ya sea por: 
   * Por defecto
   * Por codigo
   * Personas
   * Estrellas
  
  Este ordenamiento se realiza de menor a mayor

  Por ultimo tenemos el Grid View en donde se nos muestra todas las opciones que tenemos para reservar con la informacion de cada una de ellas:
   * Codigo
   * Ciudad
   * Barrio 
   * Estrellas
   * Cantidad de personas
   * TV
   * Precio 

   Al lado de estas opciones se encuentra un boton de color verde que dice Reservar para realizar la reservación de la misma. 

  Una vez terminada la Reservación, la otra opción antes mencionada, Mis reservaciones, Nos mostrara las reservaciones realizadas por el usuario que este conectado detallandose en un Grid los siguientes datos: 
  * Codigo de Reservación
  * Fecha de inicio
  * Fecha de fin
  * Precio

  En caso de querer cancelar una o algunas de las reservaciones, en la parte derecha de cada una se encuentra un boton en color rojo con la palabra Cancelar que nos permitira cancelar la misma.
 
 ## 👑 Vista Admin 👑:
En el caso de la vista del administrador tenemos las mismas opciones en la parte izquierda de la aplicacion nada mas que se le agrega otra opción que es la de usuarios y se cambian ciertas funciones de las opciones Alojamientos y Reservas.

- En la opcion Alojamientos ahora se nos despliegan 2 opciones mas que estas son:
  * Hoteles
  * Cabañas

Dentro de estas opciones nos podemos encontrar con los alojamientos registrados en cada una de ellas y tenemos la posibilidad de Agregar, Modificar o Eliminar dichos alojamientos.

Para realizar alguna de estas tres opciones se debe realizar lo siguiente:

 * Agregar: 
   En la parte superior media se encuentran unos campos para completar con la informacion del alojamiento que queremos agregar, estos campos son:
   * Codigo
   * Ciudad
   * Barrio
   * Cantidad de personas
   * Estrellas
   * ¿Tiene tv?
   * Precio por dia
   * Habitaciones
   * Baños

   Una vez completado dicho formulario se debe presionar el boton Agregar para incluirlo en el listado de alojamientos a reservar

 * Modificar:
   Para modificar un alojamiento ya registrado se debe seleccionar cual es el que se quiere modificar y en la parte derecha en el grid se encuentra un boton con el nombre Modificar, una vez presionado aparecera un cartel para confirmar si realmente queremos modificar dicho alojamiento, si la respuesta es si, los datos de ese alojamiento se cargaran al formulario de la parte de arriba en donde se hara dicha modificacion (el unico de dato que no se puede modicar es el codigo de alojamiento), una vez terminado el cambio, se debera pulsar el boton Modificar para cargar los nuevos datos al alojamiento que se quizo modificar.

 * Eliminar:
   Muy parecido al boton modificar, el boton borrar se encuentra en el Grid de los alojamientos con un color rojo, este nos servira para eliminar el alojamiento seleccionado del registro de alojamientos.

 En el apartado Reservas:
 Se muestran todas las reservas hechas por los usuarios registrados en la aplicación. En este mismo vamos a tener la posibilidad de Modificar o Borrar dichas reservas de la misma manera que se hace con los alojamientos. En el apartado modificar el unico dato que se puede cambiar es la fecha de reserva.

 En la opcion Usuarios:
 Aparecen todos los usuarios registrados en la aplicacion y tendremos las mismas opciones antes mencionadas, Modificar y Borrar.
  En la opción Modificar, en este caso, podremos cambiar todos los datos y a su vez se podra realizar el cambio de tipo de usuario de Usuario comun a Usuario administrador, ademas, desde esta opcion es donde se podra realizar el desbloqueo de los usuarios que hayan sido bloqueados por haberse logeado de manera incorrecta mas de 3 veces seguidas. 

 ##Update:
 - La aplicación ahora se conecta a una base de datos para obtener la información que antes se obtenia de archivos TXT.
 - Se agrego un boton para cambiar de ingles a español
 - Se agrego un buscador 


## Integrantes ✒️

* **Zarate Miranda Saul Denis** - *Desarrollador*
* **Bossio Alberto Federico** - *Desarrollador*
* **Toyama Rodrigo** - *Desarrollador*
* **Mandirola Gabriel Nicolas** - *Desarrollador*
* **Fornes Ezequiel Christian** - *Desarrollador*
* **Ramos Lautaro Agustin** - *Desarrollador*
