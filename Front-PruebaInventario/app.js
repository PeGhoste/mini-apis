// API
const API = 'https://localhost:7242/api/categorias';

// ID
const ID = document.getElementById('id').value;

// Mostrar todas
async function mostrar() {
    const r = await fetch(API);
    const cats = await r.json();
    let html = '';
    cats.forEach(c => html += `${c.idCategoria}: ${c.categoria}<br>`);
    document.getElementById('lista').innerHTML = html;
}

// Buscar
async function buscar() {
    const r = await fetch(API + '/' + ID);
    const c = await r.json();
    document.getElementById('nombre').value = c.categoria;
}

// Crear
async function crear() {
    const nombre = document.getElementById('nombre').value;
    await fetch(API + '/crear', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({categoria: nombre, estado: 'Activo'})
    });
    mostrar();
}

// Actualizar
async function actualizar() {
    const nombre = document.getElementById('nombre').value;
    await fetch(API + '/' + ID, {
        method: 'PUT',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({categoria: nombre, estado: 'Activo'})
    });
    mostrar();
}

// Eliminar
async function eliminar() {
    await fetch(API + '/' + ID, {method: 'DELETE'});
    mostrar();
}

// Asignar eventos
document.getElementById('btnMostrar').onclick = mostrar;
document.getElementById('btnBuscar').onclick = buscar;
document.getElementById('btnCrear').onclick = crear;
document.getElementById('btnActualizar').onclick = actualizar;
document.getElementById('btnEliminar').onclick = eliminar;

// Cargar al inicio
mostrar();