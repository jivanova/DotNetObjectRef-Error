window.exampleJsFunctions = {
    SubscribeEvents: function (id, dotNetObjectRef) {
        const element = document.getElementById(id);
        debugger;
        element.addEventListener('click', function (e) {
            window.setTimeout(function () {
                dotNetObjectRef.invokeMethodAsync('Close');
            }, 3000);
        });
    },
};