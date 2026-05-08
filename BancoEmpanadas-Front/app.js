const API = 'https://localhost:7045/api/cuentas';

// Función para mostrar todas las cuentas
async function mostrar() {
    const r = await fetch(API);
    const cuentas = await r.json();
    let html = '';
    cuentas.forEach(c => {
            html += `<tr>
                <td>${c.idCuenta}</td>
                <td>${c.tipoCuenta}</td>
                <td>${c.numeroCuenta}</td>
                <td>Q${c.saldo?.toFixed(2)}</td>
            </tr>`;
        });
        document.getElementById('cuerpoLista').innerHTML = html;
}

// Función para crear una cuenta nueva
async function crear() {
    try {
        const numeroCuenta = document.getElementById('numeroCuenta').value;
        const tipoCuenta = document.getElementById('tipoCuenta').value;
        const saldo = parseFloat(document.getElementById('saldo').value);
        const idCliente = parseInt(document.getElementById('idCliente').value);

        if (!numeroCuenta || !tipoCuenta || !saldo || !idCliente) {
            alert('Completa todos los campos');
            return;
        }

        const r = await fetch(API + '/crear', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({numeroCuenta, tipoCuenta, saldo, idCliente})
        });

        if (!r.ok) throw new Error(`Error ${r.status}`);
        alert('Cuenta creada exitosamente');
        mostrar();
        // Limpiar formulario
        document.getElementById('numeroCuenta').value = '';
        document.getElementById('tipoCuenta').value = '';
        document.getElementById('saldo').value = '';
        document.getElementById('idCliente').value = '';
    } catch (error) {
        console.error('Error al crear:', error);
        alert('Error: ' + error.message);
    }
}

// Asignar eventos
document.addEventListener('DOMContentLoaded', () => {
    const btnRefrescar = document.getElementById('btnRefrescar');
    const btnCrear = document.getElementById('btnCrear');
    
    if (btnRefrescar) btnRefrescar.onclick = mostrar;
    if (btnCrear) btnCrear.onclick = crear;
    
    // Cargar al inicio
    mostrar();
});
