$(function () {
    //debugger
    obtenerDatos();
});

function obtenerDatos() {
    var datos = getProducto();
    listarProductos(datos);
};

function getProducto() {
    var result;
    $.ajax({
        url: 'https://localhost:44308/api/producto',
        type: 'GET',
        async: false,
    }).done(function (data) {
        result = data;
    });
    return result;
};

function listarProductos(data) {
    for (d in data) {
        $("#tabla").append(
            "<tr class='seleccionarElemento'><td>" + data[d].IDProducto + "</td>" +
            "<td>" + data[d].Nombre + "</td>" +
            "<td>" + data[d].Descripcion + "</td>" +
            "<td>" + data[d].Precio + "</td>" +
            "<td>" + data[d].Stock + "</td></tr>");
        //console.log(data)
    };
    $('.seleccionarElemento').click(function () {
        seleccionar($(this));
    });
};

function seleccionar(producto) {
    //debugger
    sessionStorage.setItem("IDProducto", producto.children().eq(0).text());
    $("#nombre").val(producto.children().eq(1).text());
    $("#desc").val(producto.children().eq(2).text());
    $("#precio").val(producto.children().eq(3).text());
    $("#stock").val(producto.children().eq(4).text());
};

//agregar
function postProducto() {
    var result;
    var items = obtenerProducto();
    $.ajax({
        url: 'https://localhost:44308/api/producto',
        type: 'POST',
        async: false,
        data: {
            "IDProducto": items.IDProducto,
            "Nombre": items.Nombre,
            "Descripcion": items.Descripcion,
            "Precio": items.Precio,
            "Stock": items.Stock,
        }
    }).done(function (data) {
        result = data;
    });
    return result;
};

function putProducto() {
    var result;
    var producto = obtenerProducto();
    $.ajax({
        url: 'https://localhost:44308/api/producto',
        type: 'PUT',
        async: false,
        data: producto,
    }).done(function (data) {
            result = data;
    });
    return result;
};

function guardar() {
    //debugger
    if (sessionStorage.getItem("IDProducto") == 0) {
        postProducto();
    }
    else
    {
        putProducto();
    }
    obtenerDatos();
    limpiarForm();
};

function obtenerProducto() {
    //debugger
    var producto = {};
    producto.IDProducto = sessionStorage.getItem("IDProducto");
    producto.Nombre = $("#nombre").val();
    producto.Descripcion = $("#desc").val();
    producto.Precio = $("#precio").val();
    producto.Stock = $("#stock").val();

    return producto;
};

//eliminar
function deleteProducto(id) {
    var result;
    $.ajax({
        url: 'https://localhost:44308/api/producto/' + id,
        type: 'DELETE',
        async: false,
    }).done(function (data) {
        result = data;
    });
    return result;
}

function eliminar() {
    //debugger
    deleteProducto(sessionStorage.getItem("IDProducto"));
    limpiarForm();
}

function limpiarForm() {
    sessionStorage.setItem("IDProducto", 0);
    $("#nombre").val("");
    $("#desc").val("");
    $("#precio").val("");
    $("#stock").val("");
}