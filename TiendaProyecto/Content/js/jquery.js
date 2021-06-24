//Codigo para realizar el preloader en cada cambio de la pag.
window.onload = function (){
alert('Holiwi');
  $('#onload').fadeOut();//Llamamos a id onload que esta en encabezado
  $('body').removeClass('hidden');//Removemos la clase hidden que es la que nos impide movernos con la barra de desplazamiento
  document.getElementsByTagName("nav")[0].style.position = "fixed";//Agregamos a la etiqueta nav su posicion fiex para que se pueda desplazar con la pag. Se encuentra en style.css
  document.querySelectorAll(".social")[0].style.position = "fixed";//Agregamos a la etiqueta .social su posicion fiex para que se pueda desplazar con la pag. Se encuentra en estilo.css
}

//Codigo para el menu
let ubicacionPrincipal = window.pageYOffset;//Traemos las posicion de la pagina que se estara actualizando constantemente

window.addEventListener("scroll", function () {//Cada que se hace scroll ya sea hacia arriba o abajo
	let desplazamientoActual = window.pageYOffset;//Se trae el nuevo valor del lugar donde se encuentra la pag.
	if (ubicacionPrincipal >= desplazamientoActual) {
		document.getElementsByTagName("nav")[0].style.top = "0px";//Si subio en la pag. el menu se muestra poniendolo en su posicion original
	} else {
		document.getElementsByTagName("nav")[0].style.top = "-100px";//Si bajo en la pag. el menu se oculta poniendolo en su posicion fuera de la vista
	}
	ubicacionPrincipal= desplazamientoActual;//Se actualiza la variable para que cuando se haga otravez scroll se pueda compara nuevamente
})

// Codigo responsivo del menu (vista de celular o minimizacion de la pag.)
let enlacesHeader = document.querySelectorAll(".enlaces-header")[0];//Traemos el objeto que se ocupara
let bandera = true;//Una bandera que ayude a realizar los cambios

//Si se da click en el icono de inicio se ejecutara la siguiente funcion que se ejecuta a la par del codigo css para dar vista a la pag.
document.querySelectorAll(".hamburger")[0].addEventListener("click", function () {
	if (bandera) {
		document.querySelectorAll(".hamburger")[0].style.color ="#FFF";//Cambia el color del icono a blanco
		bandera = false;
	} else {
		document.querySelectorAll(".hamburger")[0].style.color ="#000";//Cambia el color del icono a negro
		bandera = true;
	}
	enlacesHeader.classList.toggle("menudos")//Hace llamado al codigo que esta en css para realizar la animacion
})