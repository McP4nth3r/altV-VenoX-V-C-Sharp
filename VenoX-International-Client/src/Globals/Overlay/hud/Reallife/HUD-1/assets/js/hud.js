document.addEventListener("keydown", function(event) {
    if (event.keyCode == 78) document.getElementById("mic").classList.add('micBG-style');
});

document.addEventListener("keyup", function(event) {
    if (event.keyCode == 78) document.getElementById("mic").classList.remove('micBG-style');
});

alt.on('update', (id, online) => {
	document.getElementById("id").innerHTML = `Ваш ID: ${id}`; 
	document.getElementById("online").innerHTML = `Онлайн: ${online}`; 
});

alt.on('updateOnline', (online) => {
	document.getElementById("online").innerHTML = `Онлайн: ${online}`; 
});

