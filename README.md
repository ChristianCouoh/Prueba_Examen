# Prueba_Examen
Examen Christian Couoh
Prueba_TP_Mex
Proyecto de Examen Se Adjunta proyecto desarrollado en Vs 2015, Usando MVC y Entity Framework como administrador de datos. 
Se usa el modelo Code First. 
Se debe crear un usuario (Se puso publico), ya que los menus aparecen solo si esta logueado. 
Se implemento un CRUD de profesores.
Pasos utilizados en el desarrollo: 
1.-Crear Modelo Profesores. (Use DataAnnotations para definir llaves, valores en text y mensajes en campos obligatorios. 
2.-Cree una carpeta llamada Context, en el cual se agrego una clase, llamada DataStoreZ, la cual hereda de DbContext, 
para ello agrego la refencia de Entity. En el Constructor agrego una propiedad, que devuelve un DbSet del modelo Profesores. 
3.-En el webConfig, agregue una cadena de conexion que se refencía a mi clase DataStoreZ.
4.-En la carpeta controllers, agrego un controlador para Profesores, y agrego los metodos para el CRUD,
un metodo que devuelve un Json, que me sirve para cargar la información en el plugIn Datatables.Net,
un metodo para realizar la carga de datos por medio de un layOut y un metodo para descargar un ejemplo del Layout. 
5.-En la vista Index de Profesroes, se agrega la estructura de Datable.net, se agregan los metodos para el CRUD que se llaman
por medio de un Modal.(Previamente se generan las vistas)
