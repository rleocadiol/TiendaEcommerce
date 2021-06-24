const slider = document.querySelector('.slider');
const boton = document.querySelectorAll('.btn-s');
const opcion = document.querySelectorAll('.option');
const imagenSlider = document.querySelectorAll('.img-slider');

var index = 1;
var opIndex = 0;
var size = imagenSlider[index].clientWidth;

accionSilder();

function accionSilder (){
	slider.style.transform = "translateX("+ (-size * index) +"px)";
	opcion.forEach(op => op.classList.remove('colored'));
	opcion[opIndex].classList.add('colored');
}

function accionSilde () {
	slider.style.transition = "transform .5s ease-in-out";
	accionSilder();
}

function accionBoton () {
	if (this.id === "previo") {
		index--;
		if (opIndex == 0) {
			opIndex = 4;
		} else {
			opIndex--;
		}
	} else if (this.id === "siguiente") {
		index++;
		if (opIndex == 4) {
			opIndex = 0;
		} else {
			opIndex++;
		}
	}
	accionSilde();
}

function accionOpcion () {
	let i = Number(this.getAttribute('option-index'));
	index = i + 1;
	opIndex = i;
	accionSilde();
}


slider.addEventListener('transitionend', () =>{
	if (imagenSlider[index].id === "ultimo") {
		slider.style.transition = "none";
		index = imagenSlider.length - 2;
		slider.style.transform = "translateX("+ (-size * index) +"px)";
	}else if (imagenSlider[index].id === "primero") {
		slider.style.transition = "none";
		index = 1;
		slider.style.transform = "translateX("+ (-size * index) +"px)";
	}
})

boton.forEach(btn => btn.addEventListener('click', accionBoton));
opcion.forEach(option => option.addEventListener('click', accionOpcion));



