/*!
 * site.js - JavaScript del Sistema de Facturación.
 *
 * Descripción general:
 *   Este archivo contiene la lógica de interacción del lado del cliente para
 *   la página de Mantenimiento (MaintenancePage.aspx). No depende de jQuery
 *   ni de ninguna otra librería externa.
 *
 * Responsabilidades (todas opcionales y tolerantes a fallos):
 *   1. Desplazamiento suave (scroll) hacia las secciones de MaintenancePage.aspx
 *      cuando el usuario hace clic en un enlace del menú contextual.
 *   2. Resaltar visualmente la opción activa del menú contextual y de la barra
 *      superior según la página o sección que se está viendo.
 *   3. Actualizar la URL del navegador con el hash (#id) de la sección activa
 *      sin recargar la página.
 *
 * Sin dependencias: no requiere jQuery. Se carga al final del <body> desde
 * LOGIN/MainMaster.master mediante Scripts.Render("~/bundles/site").
 */

/* Inicio de IIFE (Función Inmediatamente Invocada): encapsula todo el código
   para evitar crear variables globales que pudieran entrar en conflicto con
   otros scripts de la página. */
(function () {
    /* "use strict" activa el modo estricto de JavaScript, lo que impide
       asignaciones accidentales a variables no declaradas y detecta errores
       comunes de programación en tiempo de ejecución. */
    "use strict";

    /* ------------------------------------------------------------------
       Selectores CSS: cadenas de texto que identifican los elementos del DOM
       que este script manipula. Se definen como constantes para facilitar su
       mantenimiento si cambian los IDs en el HTML.
       ------------------------------------------------------------------ */

    // Selector de los enlaces (<a>) dentro del menú contextual (#contextMenu).
    var CONTEXT_MENU_SELECTOR = "#contextMenu a";

    // Selector de los enlaces (<a>) dentro de la barra superior (#topBar).
    var TOP_BAR_SELECTOR = "#topBar a";

    // Selector de todas las secciones (<section>) que tengan un atributo id.
    var SECTIONS_SELECTOR = "section[id]";

    // Nombre de la clase CSS que se agrega al enlace activo para resaltarlo.
    var ACTIVE_CLASS = "active";

    /* ------------------------------------------------------------------
       Funciones de utilidad para obtener información de la URL actual.
       ------------------------------------------------------------------ */

    /* Devuelve la ruta de la página actual (solo el nombre del archivo, en
       minúsculas). Ejemplo: si la URL es ".../Default.aspx", devuelve
       "default.aspx". Sirve para saber en qué página está el usuario. */
    function getCurrentPagePath() {
        // window.location.pathname contiene la ruta del servidor (ej: /Default.aspx)
        // split("/") divide por barras, pop() toma el último segmento.
        return (window.location.pathname.split("/").pop() || "").toLowerCase();
    }

    /* Devuelve el valor del hash de la URL actual sin el símbolo #.
       Ejemplo: si la URL termina en "#empresa", devuelve "empresa".
       Se usa para saber qué sección está seleccionada. */
    function getCurrentHash() {
        // window.location.hash incluye el #, por lo que lo eliminamos con replace.
        return window.location.hash.replace("#", "");
    }

    /* Indica si un href apunta a la página que se está viendo actualmente.
       Se usa para ignorar clics en enlaces que llevan a otra página y solo
       procesar los que son anclas dentro de la misma página. */
    function isSamePage(href) {
        // Divide el href por # para separar la ruta del ancla.
        var parts = href.split("#");
        var path = parts[0];

        // Si no hay ruta (solo hay #algunId), es un ancla de la misma página.
        if (!path) {
            return true;
        }

        // Extrae solo el nombre de archivo y lo compara con la página actual.
        var fileName = path.split("/").pop().toLowerCase();
        return fileName === getCurrentPagePath();
    }

    /* ------------------------------------------------------------------
       Funciones de resaltado (highlight) de enlaces activos.
       ------------------------------------------------------------------ */

    /* Elimina la clase CSS "active" de todos los enlaces que coincidan con
       el selector recibido. Se llama antes de marcar un nuevo enlace como
       activo, para que solo uno tenga la clase a la vez. */
    function removeActiveClasses(selector) {
        // querySelectorAll devuelve una lista de nodos que coinciden con el selector.
        var links = document.querySelectorAll(selector);
        // Recorre cada enlace y le quita la clase active.
        for (var i = 0; i < links.length; i++) {
            links[i].classList.remove(ACTIVE_CLASS);
        }
    }

    /* Resalta el enlace del menú contextual (#contextMenu) que apunta a la
       sección actualmente visible (según el hash de la URL). */
    function highlightActiveSection() {
        // Obtiene el hash actual o, si no hay, el id de la primera sección.
        var hash = getCurrentHash() || getFirstSectionId();
        // Selecciona todos los enlaces del menú contextual.
        var links = document.querySelectorAll(CONTEXT_MENU_SELECTOR);

        // Recorre cada enlace y compara su href con el hash actual.
        for (var i = 0; i < links.length; i++) {
            // Extrae la parte después del # del href del enlace.
            var target = (links[i].getAttribute("href") || "").split("#")[1];
            // Si coincide con el hash, agrega la clase active.
            if (target === hash) {
                links[i].classList.add(ACTIVE_CLASS);
            }
        }
    }

    /* Devuelve el id de la primera <section> de la página. Se usa como
       valor por defecto cuando no hay hash en la URL. */
    function getFirstSectionId() {
        // Busca la primera sección que tenga atributo id.
        var section = document.querySelector(SECTIONS_SELECTOR);
        // Si existe, devuelve su id; si no, devuelve cadena vacía.
        return section ? section.id : "";
    }

    /* Resalta el enlace de la barra superior (#topBar) que corresponde a la
       página actual (por ejemplo, "Mantenimiento" cuando se ve MaintenancePage). */
    function highlightCurrentPage() {
        // Obtiene el nombre del archivo de la página actual.
        var current = getCurrentPagePath();
        // Selecciona todos los enlaces de la barra superior.
        var links = document.querySelectorAll(TOP_BAR_SELECTOR);

        // Recorre cada enlace y compara su ruta con la página actual.
        for (var i = 0; i < links.length; i++) {
            // Elimina el ancla (#...) si existe, dejando solo la ruta.
            var href = (links[i].getAttribute("href") || "").split("#")[0];

            // Si el href existe y su nombre de archivo coincide con la página actual,
            // marca ese enlace como activo.
            if (href && href.toLowerCase().split("/").pop() === current) {
                links[i].classList.add(ACTIVE_CLASS);
            }
        }
    }

    /* ------------------------------------------------------------------
       Función de desplazamiento suave (smooth scroll).
       ------------------------------------------------------------------ */

    /* Hace que al hacer clic en un enlace de ancla (#id) de la misma página,
       el navegador se desplace suavemente hasta esa sección en lugar de saltar
       de inmediato. También actualiza la URL y el resaltado del menú. */
    function enableSmoothScroll() {
        // Escucha cualquier clic en el documento.
        document.addEventListener("click", function (event) {
            // Busca el elemento <a> más cercano que contenga # en su href.
            var link = event.target.closest ? event.target.closest("a[href*='#']") : null;

            // Si no es un enlace de ancla o apunta a otra página, ignora el clic.
            if (!link || !isSamePage(link.getAttribute("href") || "")) {
                return;
            }

            // Extrae el id de la sección destino (después del #).
            var id = (link.getAttribute("href") || "").split("#")[1];
            // Busca el elemento del DOM con ese id.
            var target = id ? document.getElementById(id) : null;

            // Si no se encontró el elemento destino, no hace nada.
            if (!target) {
                return;
            }

            // Evita el comportamiento por defecto del navegador (salto inmediato).
            event.preventDefault();

            // Desplaza la página suavemente hasta el elemento destino.
            target.scrollIntoView({ behavior: "smooth", block: "start" });

            // Actualiza la URL del navegador con el nuevo hash sin recargar.
            if (history.pushState) {
                history.pushState(null, "", "#" + id);
            } else {
                // Fallback para navegadores muy antiguos que no soportan pushState.
                window.location.hash = id;
            }

            // Vuelve a calcular qué enlace debe estar resaltado.
            removeActiveClasses(CONTEXT_MENU_SELECTOR);
            highlightActiveSection();
        });
    }

    /* ------------------------------------------------------------------
       Inicialización del script.
       ------------------------------------------------------------------ */

    /* Ejecuta todas las funciones de configuración cuando el DOM está listo:
       resalta la página actual, resalta la sección activa y habilita el
       scroll suave. También vuelve a resaltar si el usuario cambia el hash
       con los botones adelante/atrás del navegador. */
    function initialize() {
        highlightCurrentPage();
        highlightActiveSection();
        enableSmoothScroll();

        // Cuando cambia el hash (navegación por anclas), vuelve a resaltar.
        window.addEventListener("hashchange", function () {
            removeActiveClasses(CONTEXT_MENU_SELECTOR);
            highlightActiveSection();
        });
    }

    // Si el navegador todavía está cargando el DOM, espera al evento
    // DOMContentLoaded antes de inicializar. Si ya está listo, inicia ya.
    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", initialize);
    } else {
        initialize();
    }

/* Fin de la IIFE. El código queda encapsulado y no contamina el ámbito global. */
})();
