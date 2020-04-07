// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// A $( document ).ready() block.
$(document).ready(function () {
    console.log("ready!");

    $("#print").on("click", function () { 
        let print_text = $("#print-text").val();
        printFunction(print_text);
    })


    function printFunction(printStr) {
        var websockets;
        var state;
        websockets = new WebSocket('ws://127.0.0.1:1660');
        websockets.addEventListener('message', ws_recv, false);
        websockets.addEventListener('open', ws_open(printStr), false);
        function ws_open(text) {
            // alert("Are you sure to print?");
            console.log("print called");
            websockets.onopen = () => {
                console.log("Connection Opened");
                websockets.send(text)
                console.log("Print Request sent"); 
            }
            // ws.send(text);
        }
        function ws_recv() {
            console.log("ws_recv");
        }
    }


});
