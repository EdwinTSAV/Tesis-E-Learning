function checkOffset() {
    if ($('#deslizable').offset().top + $('#deslizable').height() >=
        $('#footer').offset().top - 10)
        $('#deslizable').css('position', 'absolute');
    if ($(document).scrollTop() + window.innerHeight < $('#footer').offset().top)
        $('#deslizable').css('position', 'fixed');
}
$(document).scroll(function () {
    checkOffset();
});

function video(idClase) {
    var $videoSeccion = $('div#video');
    var $logged = $('#logged');
    $.ajax({
        'url': '/Curso/Video?idClase=' + idClase,
        'type': 'get'
    }).done(function (items) {
        var options = `<iframe width="1018" height="600" src="${items.video}" 
        title = "YouTube video player" frameborder="0" allow="accelerometer;
        autoplay; clipboard-write; encrypted-media; gyroscope;
        picture-in-picture" allowfullscreen></iframe>
            <h1>${items.nombre}</h1>
            <p>${items.descripcion}</p>`;
            
            options += `<h1>Recursos</h1>`
            for (var i = 0; i < items.recursos.length; i++) {
                options += `<ul>
                                <li>
                                    <i class="fa fa-download" aria-hidden="true"></i><a href="${items.recursos[i].archivo}"> ${items.recursos[i].archivo}</a>
                                </li>
                            </ul>`
            }
        $videoSeccion.html(options);
    })
}

function favorite(id) {
    var $favorite = $('a#favorite_' + id);
    var $idCurso = id;
    $.ajax({
        'url': '/Curso/Favoritos?idCurso=' + id,
        'type': 'get'
    })
    var options = `<i onclick="nofavorite(${$idCurso})" class="fa fa-heart" aria-hidden="true"></i>`
    $favorite.html(options);
};

function nofavorite(id) {
    var $favorite = $('a#favorite_' + id);
    var $idCurso = id;
    $.ajax({
        'url': '/Curso/Favoritos?idCurso=' + id,
        'type': 'get'
    })
    var options = `<i onclick="favorite(${$idCurso})" class="fa fa-heart-o" aria-hidden="true"></i>`
    $favorite.html(options);
};

function Comprar(id) {
    Swal.fire({
        title: 'Agregar a la cesta?',
        text: "Este curso se agregar a tu cesta",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, agregar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Curso/Compras?idCurso=" + id,
                type: "get"
            });
            Swal.fire({
                title: 'Agregado!',
                text: 'Este curso esta en tu cesta',
                icon: 'success',
                confirmButtonText: 'ok'
            }).then((result) => {
                if (result.isConfirmed) {
                    location.reload();
                }
            })
        }
    });
};

function noComprar(id) {
    Swal.fire({
        title: 'Quitar de la cesta?',
        text: "Este curso se quitara de tu cesta",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, quitar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Curso/Compras?idCurso=" + id,
                type: "get"
            });
            Swal.fire({
                title: 'Eliminado!',
                text: 'Este curso ya no esta en tu cesta',
                icon: 'success',
                confirmButtonText: 'ok'
            }).then((result) => {
                if (result.isConfirmed) {
                    location.reload();
                }
            })
        }
    });
};
