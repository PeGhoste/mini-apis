// Definimos la URL base de la API 
const API_BASE = 'https://localhost:7045/api/clientes';

// Función para mostrar los datos del cliente
async function mostrar(){
	const resp = await fetch(API_BASE);
	const clientes = await resp.json();
    
    const tbody = document.getElementById('respClientes');
    tbody.innerHTML = '';

    clientes.forEach(cliente => {
        tbody.innerHTML += `
            <tr>
                <td>${cliente.idCliente}</td>
                <td>${cliente.nombres}</td>
                <td>${cliente.apellidos}</td>
                <td>${cliente.edad}</td>
                <td>${cliente.estado}</td>
            </tr>
        `;
    });
    
	console.log(clientes);
}

// Función para obtener un cliente
async function obtenerCliente(){
	const ID = document.getElementById('idCliente').value;
	const resp = await fetch(API_BASE + '/' + ID);
	const cliente = await resp.json();
	
	const tbody = document.getElementById('respClientes');  
	tbody.innerHTML = '';
	
	tbody.innerHTML += `
            <tr>
                <td>${cliente.idCliente}</td>
                <td>${cliente.nombres}</td>
                <td>${cliente.apellidos}</td>
                <td>${cliente.edad}</td>
                <td>${cliente.estado}</td>
            </tr>
        `;		
	
	console.log(cliente);
}

// Función para crear un nuevo cliente
async function crear(){
    const nombres = document.getElementById('nombres').value ?? '';
    const apellidos = document.getElementById('apellidos').value ?? '';
    const edad = document.getElementById('edad').value ?? 0;
    const estado = document.getElementById('estado').value ?? 'Activo';

	const resp = await fetch(API_BASE + '/crear',{
			method: 'POST',
			headers: {'content-type': 'application/json'},
			body: JSON.stringify({
				nombres: nombres,
                apellidos: apellidos,
				edad: parseInt(edad),
				estado: estado
			})
	});

	console.log(resp);
	mostrar();
}

// Función para actualizar un cliente
async function actualizar(){
    const ID =  document.getElementById('idCliente').value;
    const nombres = document.getElementById('nombres').value;
    const apellidos = document.getElementById('apellidos').value;
    const edad = document.getElementById('edad').value;
    const estado = document.getElementById('estado').value;

    const resp = await fetch(API_BASE + '/actualizar/' + ID, {
        method: 'PUT',
        headers: {'content-type': 'application/json'},
        body: JSON.stringify({
            nombres: nombres,
            apellidos: apellidos,
            edad: parseInt(edad),
            estado: estado
        })
    });

    if(!resp.ok) {
        alert('Error al actualizar: ' + resp.status);
        return;
    } else{
        alert('Cliente actualizado exitosamente');
    }

    mostrar();
}

// Función para eliminar un cliente
async function eliminar(){
    const ID =  document.getElementById('idCliente').value;
	const resp = await fetch(API_BASE + '/eliminar/' + ID, {
		method: 'DELETE'
	});

    if(!resp.ok) {
        alert('Error al eliminar: ' + resp.status);
        return;
    } else{
        alert('Cliente eliminado exitosamente');
    }

	mostrar();
}

// Asignar eventos para los botones y que se ejecute la función mostrar al cargar la página
document.getElementById('btnMostrar').onclick = mostrar;
document.getElementById('btnCliente').onclick = obtenerCliente;
document.getElementById('btnCrear').onclick = crear;
document.getElementById('btnActualizar').onclick = actualizar;
document.getElementById('btnEliminar').onclick = eliminar;

// Cargar al inicio de la página para mostrar los datos
mostrar();